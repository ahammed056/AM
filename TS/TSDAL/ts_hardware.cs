using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;




namespace TSDAL
{
    #region object of helpdesk
    public class dbcomplaintentites
    {
        private int s_id, company, department, issue_type, priority, current_status, assigned_to_engineer, closed_engineer;

        public int Issue_type
        {
            get { return issue_type; }
            set { issue_type = value; }
        }

        public int Closed_engineer
        {
            get { return closed_engineer; }
            set { closed_engineer = value; }
        }

        public int Assigned_to_engineer
        {
            get { return assigned_to_engineer; }
            set { assigned_to_engineer = value; }
        }

        public int Current_status
        {
            get { return current_status; }
            set { current_status = value; }
        }

        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        public int Department
        {
            get { return department; }
            set { department = value; }
        }

        public int Company
        {
            get { return company; }
            set { company = value; }
        }

        public int S_id
        {
            get { return s_id; }
            set { s_id = value; }
        }
        private string complaintIdinfo, system_number, issue_desc, escalation_required;

        public string ComplaintIdinfo
        {
            get { return complaintIdinfo; }
            set { complaintIdinfo = value; }
        }



        public string Escalation_required
        {
            get { return escalation_required; }
            set { escalation_required = value; }
        }
        private string action_steps, impact_summary, asset_deatils, entered_by, created_by;

        public string Created_by
        {
            get { return created_by; }
            set { created_by = value; }
        }


        public string Entered_by
        {
            get { return entered_by; }
            set { entered_by = value; }
        }

        public string Asset_deatils
        {
            get { return asset_deatils; }
            set { asset_deatils = value; }
        }

        public string Impact_summary
        {
            get { return impact_summary; }
            set { impact_summary = value; }
        }

        public string Action_steps
        {
            get { return action_steps; }
            set { action_steps = value; }
        }
        private DateTime commited_time, resolution_time, issue_closed_time, created_time;

        public DateTime Created_time
        {
            get { return created_time; }
            set { created_time = value; }
        }

        public DateTime Issue_closed_time
        {
            get { return issue_closed_time; }
            set { issue_closed_time = value; }
        }

        public DateTime Resolution_time
        {
            get { return resolution_time; }
            set { resolution_time = value; }
        }

        public DateTime Commited_time
        {
            get { return commited_time; }
            set { commited_time = value; }
        }

        public string Issue_desc
        {
            get { return issue_desc; }
            set { issue_desc = value; }
        }

        public string System_number
        {
            get { return system_number; }
            set { system_number = value; }
        }

    }
    #endregion

    public class ts_hardware
    {
        MySqlConnection con = new MySqlConnection(SQLHelper.GetsqlConnectionString());

        #region to get the dorpdown and grid data
        public DataTable get_company()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM tbl_company ORDER by c_company ASC", con);
                msc.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(msc);
                da.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {

                con.Close();
            }
            return dt;
        }

        public DataTable get_department(int comp_id)
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM `tbl_departments` WHERE d_did = @did", con);
                msc.Parameters.Add(new MySqlParameter("@did", comp_id));
                msc.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(msc);

                da.Fill(dt);

            }
            catch (Exception ex)
            {

            }
            finally
            {

                con.Close();
            }
            return dt;
        }
        public DataTable get_departments_full()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                MySqlCommand msc = new MySqlCommand("SELECT c_company as Company ,d_department as Department ,d_created_time as CreatedTime FROM `tbl_company` as t1 INNER JOIN tbl_departments as t2 ON t1.c_did = t2.d_did  where t2.d_isactive = 1", con);              
                msc.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(msc);

                da.Fill(dt);

            }
            catch (Exception ex)
            {

            }
            finally
            {

                con.Close();
            }
            return dt;
        }

        public DataTable get_employee()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                MySqlCommand msc = new MySqlCommand("SELECT * FROM tbl_employee", con);
                msc.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(msc);
                da.Fill(dt);

            }
            catch (Exception ex)
            {

            }
            finally
            {

                con.Close();
            }
            return dt;
        }

        public DataTable get_current_status()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                MySqlCommand msc = new MySqlCommand("SELECT `cs_id`, `cs_status` FROM `tbl_current_status` WHERE `isactive`= 1", con);
                msc.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(msc);
                da.Fill(dt);

            }
            catch (Exception ex)
            {

            }
            finally
            {

                con.Close();
            }
            return dt;
        }

        public DataTable get_priority()
        {
            DataTable dt = new DataTable();
            try
            {

                con.Open();
                MySqlCommand msc = new MySqlCommand("SELECT `pr_id`, `pr_priority`  FROM `tbl_priority` WHERE `isactive`= 1", con);
                msc.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(msc);
                da.Fill(dt);

            }
            catch (Exception ex)
            {

            }
            finally
            {

                con.Close();
            }
            return dt;
        }

        public DataTable get_issue_type()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                MySqlCommand msc = new MySqlCommand("SELECT `iss_id`, `iss_type` FROM `tbl_issue_type` WHERE `iss_isactive`= 1", con);
                msc.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(msc);
                da.Fill(dt);

            }
            catch (Exception ex)
            {

            }
            finally
            {

                con.Close();
            }
            return dt;
        }

        public DataTable get_gv1data()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();

                String str = "SELECT *,CONCAT(if(TIMESTAMPDIFF(day,`LogCreatedTime`,`ResolutionTime`)=0,'',concat(TIMESTAMPDIFF(day,LogCreatedTime,`ResolutionTime`),' d ')) ,if(MOD( TIMESTAMPDIFF(hour,`LogCreatedTime`,`ResolutionTime`), 24)=0,'',concat(MOD( TIMESTAMPDIFF(hour,`LogCreatedTime`,`ResolutionTime`), 24), ' hrs ')),MOD( TIMESTAMPDIFF(minute,`LogCreatedTime`,`ResolutionTime`), 60), ' min ') as Resolution,CONCAT(if(TIMESTAMPDIFF(day,`LogCreatedTime`,`CommitedTime`)=0,'',concat(TIMESTAMPDIFF(day,LogCreatedTime,`CommitedTime`),' d ')) ,if(MOD( TIMESTAMPDIFF(hour,`LogCreatedTime`,`CommitedTime`), 24)=0,'',concat(MOD( TIMESTAMPDIFF(hour,`LogCreatedTime`,`CommitedTime`), 24), ' hrs ')),MOD( TIMESTAMPDIFF(minute,`LogCreatedTime`,`CommitedTime`), 60), ' min ') as Commited_time, CONCAT(if(TIMESTAMPDIFF(day,`LogCreatedTime`,`ComplaintClosedTime`)=0,'',concat(TIMESTAMPDIFF(day,LogCreatedTime,`ComplaintClosedTime`),' d ')) ,if(MOD( TIMESTAMPDIFF(hour,`LogCreatedTime`,`ComplaintClosedTime`), 24)=0,'',concat(MOD( TIMESTAMPDIFF(hour,`LogCreatedTime`,`ComplaintClosedTime`), 24), ' hrs ')),MOD( TIMESTAMPDIFF(minute,`LogCreatedTime`,`ComplaintClosedTime`), 60), ' min ') as ClosedTimeHH FROM tbl_complaints_info as t1 left outer join " +
                            "(Select s.* from tbl_complaints_log_summary s inner join " +
                            "(SELECT ComplaintIdlog,max(`LogCreatedTime`) LogCreatedTime FROM `tbl_complaints_log_summary` GROUP by ComplaintIdlog) X on " +
                            "S.ComplaintIdlog=X.ComplaintIdlog and S.LogCreatedTime=X.LogCreatedTime) FIN on t1.ci_ComplaintIdinfo = FIN.ComplaintIdlog " +
                            "LEFT OUTER JOIN tbl_company as t3 ON t1.ci_Company = t3.c_sid  " +
                            "LEFT OUTER JOIN tbl_departments as t4 on t1.ci_Department = t4.d_id " +
                            "LEFT OUTER JOIN tbl_employee t5 ON FIN.AssignedTo = t5.e_id " +
                            "LEFT OUTER JOIN tbl_priority as t6 on FIN.Priority = t6.pr_id " +
                            "LEFT OUTER JOIN tbl_issue_type as t7 ON FIN.IssueType = t7.iss_id " +
                            "LEFT OUTER JOIN tbl_current_status as t8 on FIN.CurrentStatus = t8.cs_id  where `ci_isactive` = 1 ORDER BY  FIN.ComInfoId DESC";
                MySqlCommand msc = new MySqlCommand(str, con);
                msc.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(msc);
                da.Fill(dt);

            }
            catch (Exception ex)
            {

            }
            finally
            {

                con.Close();
            }
            return dt;
        }


        public DataTable get_Complaintdata2_for_search(string infoid)
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();

                String str = "SELECT * FROM tbl_complaints_log_summary T1 INNER JOIN tbl_complaints_info T2  ON  T1.ComplaintIdlog = T2.ci_ComplaintIdinfo WHERE `ci_ComplaintIdinfo` = @cidinfo";
                MySqlCommand msc = new MySqlCommand(str, con);
                msc.Parameters.Add(new MySqlParameter("@cidinfo", infoid));
                msc.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(msc);
                da.Fill(dt);

            }
            catch (Exception ex)
            {

            }
            finally
            {

                con.Close();
            }
            return dt;
        }

        #endregion

        #region ipconfig of systemd
        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);

        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);

        private static string GetClientMAC(string strClientIP)
        {
            string mac_dest = "";
            try
            {
                Int32 ldest = inet_addr(strClientIP);
                Int32 lhost = inet_addr("");
                Int64 macinfo = new Int64();
                Int32 len = 6;
                int res = SendARP(ldest, 0, ref macinfo, ref len);
                string mac_src = macinfo.ToString("X");

                while (mac_src.Length < 12)
                {
                    mac_src = mac_src.Insert(0, "0");
                }

                for (int i = 0; i < 11; i++)
                {
                    if (0 == (i % 2))
                    {
                        if (i == 10)
                        {
                            mac_dest = mac_dest.Insert(0, mac_src.Substring(i, 2));
                        }
                        else
                        {
                            mac_dest = "-" + mac_dest.Insert(0, mac_src.Substring(i, 2));
                        }
                    }
                }
            }
            catch (Exception err)
            {
                throw new Exception("Lỗi " + err.Message);
            }
            return mac_dest;
        }
        #endregion
        public int insert_complaintdata(dbcomplaintentites dcu)
        {
            int result = 0;
            {
                string sqlstr1 = "INSERT INTO `tbl_complaints_info`(`ci_ComplaintIdinfo`, `ci_ProductName`, `ci_ProductIp`, `ci_Company`, `ci_Department`, `ci_ComplaintGivenBy`, `ci_CreatedBy`, `ci_CreatedTime`, `ci_IsActive`)VALUES(replace(replace(replace(CAST(sysdate() AS char),'-',''),':',''),' ',''), @system_number, @pip, @company, @department, @entered_by, @created_by, sysdate(), @isactive_log)";
                string sqlstr2 = "INSERT INTO `tbl_complaints_log_summary`(`ComplaintIdlog`,`IssueType`,`Priority`,`CurrentStatus`,`AssignedTo`,`IssueDescription`,`CommitedTime`,`ResolutionTime`,`EscalationRequired`,`ActionSteps`,`ImpactSummary`, `AssetDeatils`, `ComplaintClosedTime`, `ClosedEngineer`, `LogCreatedTime`, `LogCreatedBy`, `LogIsactiveLog`,`ResolutionInHours`, `CommitedInHours`, `ClosedInHours`) VALUES (replace(replace(replace(CAST(sysdate() AS char),'-',''),':',''),' ',''),@issue_type, @priority, @current_status, @assigned_to_engineer, @issue_desc, @commited_time, @resolution_time, @escalation_required,  @action_steps, @impact_summary, @asset_deatils, @issue_closed_time, @closed_engineer,sysdate(),@created2_by, @isactive2_log, TIMESTAMPDIFF(HOUR, `LogCreatedTime`,`ResolutionTime`), TIMESTAMPDIFF(HOUR,`LogCreatedTime`,`CommitedTime`), TIMESTAMPDIFF(HOUR,`LogCreatedTime`,`ComplaintClosedTime`))";



                string sqlstr = sqlstr1 + ";" + sqlstr2;
                MySqlCommand cmd = new MySqlCommand(sqlstr, con);
                cmd.Parameters.Add(new MySqlParameter("@system_number", dcu.System_number));
                cmd.Parameters.Add(new MySqlParameter("@pip", null));
                cmd.Parameters.Add(new MySqlParameter("@company", dcu.Company));
                cmd.Parameters.Add(new MySqlParameter("@department", dcu.Department));
                cmd.Parameters.Add(new MySqlParameter("@entered_by", dcu.Entered_by));
                cmd.Parameters.Add(new MySqlParameter("@created_time", dcu.Created_time));
                cmd.Parameters.Add(new MySqlParameter("@created_by", dcu.Created_by));
                cmd.Parameters.Add(new MySqlParameter("@isactive_log", 1));




                // has to pick up the row filed form tbl_complaints info

                cmd.Parameters.Add(new MySqlParameter("@issue_type", dcu.Issue_type));
                cmd.Parameters.Add(new MySqlParameter("@priority", dcu.Priority));
                cmd.Parameters.Add(new MySqlParameter("@current_status", dcu.Current_status));
                cmd.Parameters.Add(new MySqlParameter("@assigned_to_engineer", dcu.Assigned_to_engineer));
                cmd.Parameters.Add(new MySqlParameter("@issue_desc", dcu.Issue_desc));
                cmd.Parameters.Add(new MySqlParameter("@commited_time", dcu.Commited_time));
                cmd.Parameters.Add(new MySqlParameter("@resolution_time", dcu.Resolution_time));
                cmd.Parameters.Add(new MySqlParameter("@escalation_required", dcu.Escalation_required));
                cmd.Parameters.Add(new MySqlParameter("@action_steps", dcu.Action_steps));
                cmd.Parameters.Add(new MySqlParameter("@impact_summary", dcu.Impact_summary));
                cmd.Parameters.Add(new MySqlParameter("@asset_deatils", dcu.Asset_deatils));
                cmd.Parameters.Add(new MySqlParameter("@issue_closed_time", dcu.Issue_closed_time));
                cmd.Parameters.Add(new MySqlParameter("@closed_engineer", dcu.Closed_engineer));
                cmd.Parameters.Add(new MySqlParameter("@created2_time", dcu.Created_time));
                cmd.Parameters.Add(new MySqlParameter("@created2_by", dcu.Created_by));
                cmd.Parameters.Add(new MySqlParameter("@isactive2_log", 1));
                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();

            }
            return result;
        }

        public int Update_complaintdata(dbcomplaintentites dcu, string hidup)
        {
            int result = 0;
            {
                string sqlstr = "INSERT INTO `tbl_complaints_log_summary`(`ComplaintIdlog`,`IssueType`,`Priority`,`CurrentStatus`,`AssignedTo`," +
                    "`IssueDescription`,`CommitedTime`,`ResolutionTime`,`EscalationRequired`,`ActionSteps`,`ImpactSummary`, `AssetDeatils`," +
                    "`ComplaintClosedTime`, `ClosedEngineer`, `LogCreatedTime`, `LogCreatedBy`, `LogIsactiveLog`,`ResolutionInHours`, " +
                    "`CommitedInHours`, `ClosedInHours`) VALUES (@ComplaintIdlog, @issue_type, @priority, @current_status, @assigned_to_engineer," +
                    "@issue_desc, @commited_time, @resolution_time, @escalation_required,  @action_steps, @impact_summary, @asset_deatils," +
                    "@issue_closed_time, @closed_engineer,@createdtime,@created2_by, @isactive2_log, TIMESTAMPDIFF(HOUR, `LogCreatedTime`," +
                    "`ResolutionTime`), TIMESTAMPDIFF(HOUR,`LogCreatedTime`,`CommitedTime`), TIMESTAMPDIFF(HOUR,`LogCreatedTime`,`ComplaintClosedTime`))";
                MySqlCommand cmd = new MySqlCommand(sqlstr, con);
                cmd.Parameters.Add(new MySqlParameter("@ComplaintIdlog", hidup));
                cmd.Parameters.Add(new MySqlParameter("@issue_type", dcu.Issue_type));
                cmd.Parameters.Add(new MySqlParameter("@priority", dcu.Priority));
                cmd.Parameters.Add(new MySqlParameter("@current_status", dcu.Current_status));
                cmd.Parameters.Add(new MySqlParameter("@assigned_to_engineer", dcu.Assigned_to_engineer));
                cmd.Parameters.Add(new MySqlParameter("@issue_desc", dcu.Issue_desc));
                cmd.Parameters.Add(new MySqlParameter("@commited_time", dcu.Commited_time));
                cmd.Parameters.Add(new MySqlParameter("@resolution_time", dcu.Resolution_time));
                cmd.Parameters.Add(new MySqlParameter("@escalation_required", dcu.Escalation_required));
                cmd.Parameters.Add(new MySqlParameter("@action_steps", dcu.Action_steps));
                cmd.Parameters.Add(new MySqlParameter("@impact_summary", dcu.Impact_summary));
                cmd.Parameters.Add(new MySqlParameter("@asset_deatils", dcu.Asset_deatils));
                cmd.Parameters.Add(new MySqlParameter("@issue_closed_time", dcu.Issue_closed_time));
                cmd.Parameters.Add(new MySqlParameter("@closed_engineer", dcu.Closed_engineer));
                cmd.Parameters.Add(new MySqlParameter("@created2_by", dcu.Closed_engineer));
                cmd.Parameters.Add(new MySqlParameter("@createdtime", System.DateTime.Now));
                cmd.Parameters.Add(new MySqlParameter("@isactive2_log", 1));
                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();
            }
            return result;
        }

        public void showgriddata(dbcomplaintentites dcu, string hid)
        {
            MySqlCommand msc = new MySqlCommand("SELECT * FROM tbl_complaints_info as t1 left outer join (Select s.* from tbl_complaints_log_summary s inner join (SELECT ComplaintIdlog,max(`LogCreatedTime`) LogCreatedTime FROM `tbl_complaints_log_summary` GROUP by ComplaintIdlog) X on S.ComplaintIdlog=X.ComplaintIdlog and S.LogCreatedTime=X.LogCreatedTime) FIN on t1.ci_ComplaintIdinfo = FIN.ComplaintIdlog LEFT OUTER JOIN tbl_company as t3 ON t1.ci_Company = t3.c_sid LEFT OUTER JOIN tbl_departments as t4 on t1.ci_Department = t4.d_id LEFT OUTER JOIN tbl_employee t5 ON FIN.AssignedTo = t5.e_id LEFT OUTER JOIN tbl_priority as t6 on FIN.Priority = t6.pr_id LEFT OUTER JOIN tbl_issue_type as t7 ON FIN.IssueType = t7.iss_id LEFT OUTER JOIN tbl_current_status as t8 on FIN.CurrentStatus = t8.cs_id where `ci_ComplaintIdinfo` = @sid AND `ci_isactive` = 1 ORDER BY FIN.ComInfoId DESC LIMIT 1", con);
            msc.Parameters.Add(new MySqlParameter("@sid", hid));
            MySqlDataAdapter da = new MySqlDataAdapter(msc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dcu.ComplaintIdinfo = dt.Rows[0]["ci_ComplaintIdinfo"].ToString();
                dcu.System_number = dt.Rows[0]["ci_ProductName"].ToString();
                dcu.Company = Convert.ToInt32(dt.Rows[0]["ci_Company"].ToString());
                dcu.Department = Convert.ToInt32(dt.Rows[0]["ci_department"].ToString());
                dcu.Issue_type = Convert.ToInt32(dt.Rows[0]["IssueType"].ToString());
                dcu.Priority = Convert.ToInt32(dt.Rows[0]["priority"].ToString());
                dcu.Current_status = Convert.ToInt32(dt.Rows[0]["CurrentStatus"].ToString());
                dcu.Assigned_to_engineer = Convert.ToInt32(dt.Rows[0]["AssignedTo"].ToString());
                dcu.Issue_desc = dt.Rows[0]["IssueDescription"].ToString();
                dcu.Commited_time = Convert.ToDateTime(dt.Rows[0]["CommitedTime"].ToString());
                dcu.Resolution_time = Convert.ToDateTime(dt.Rows[0]["ResolutionTime"].ToString());
                dcu.Escalation_required = dt.Rows[0]["EscalationRequired"].ToString();
                dcu.Action_steps = dt.Rows[0]["ActionSteps"].ToString();
                dcu.Impact_summary = dt.Rows[0]["ImpactSummary"].ToString();
                dcu.Asset_deatils = dt.Rows[0]["AssetDeatils"].ToString();
                dcu.Entered_by = dt.Rows[0]["entered_by"].ToString();
                dcu.Closed_engineer = Convert.ToInt32(dt.Rows[0]["ClosedEngineer"].ToString());
                dcu.Issue_closed_time = Convert.ToDateTime(dt.Rows[0]["ComplaintClosedTime"].ToString());


                //   SELECT `ComInfoId`, `ComplaintIdlog`, `IssueType`, `Priority`, `CurrentStatus`, `AssignedTo`, `IssueDescription`, 
                //`CommitedTime`, `ResolutionTime`, `EscalationRequired`, `ActionSteps`, `ImpactSummary`, `AssetDeatils`, `ComplaintClosedTime`,
                //  `ClosedEngineer`, `Entered_By`, `LogCreatedTime`, `LogCreatedBy`, `LogIsactiveLog`, `ResolutionInHours`, `CommitedInHours`, 
                //  `ClosedInHours` FROM `tbl_complaints_log_summary` WHERE 1


            }
        }

        public int delete_complaint(dbcomplaintentites dc, string hid)
        {
            int result = 0;
            MySqlCommand cmd = new MySqlCommand("UPDATE `tbl_complaints_info` SET `ci_isactive`= 0 WHERE `ci_ComplaintIdinfo`= @sid", con);
            cmd.Parameters.Add(new MySqlParameter("@sid", hid));
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public DataTable search_complaint(string ser)
        {
            MySqlCommand msc = new MySqlCommand("SELECT ci_ProductName AS SystemName,c_company AS Company,iss_type As Complaint,pr_priority as Priority,cs_status as Status,e_Name as AssignedTo,IssueDescription As Description,ci_CreatedTime AS CreatedTime,CommitedTime,ResolutionTime,ComplaintClosedTime as ClosedTime,ActionSteps,ImpactSummary as Summary,AssetDeatils, ci_ComplaintGivenBy as GivenBy,e_Name AS ClosedEngineer FROM tbl_complaints_info as t1 left outer join (Select s.* from tbl_complaints_log_summary s inner join (SELECT ComplaintIdlog,max(`LogCreatedTime`) LogCreatedTime FROM `tbl_complaints_log_summary` GROUP by ComplaintIdlog) X on S.ComplaintIdlog=X.ComplaintIdlog and S.LogCreatedTime=X.LogCreatedTime) FIN on t1.ci_ComplaintIdinfo = FIN.ComplaintIdlog LEFT OUTER JOIN tbl_company as t3 ON t1.ci_Company = t3.c_sid LEFT OUTER JOIN tbl_departments as t4 on t1.ci_Department = t4.d_id LEFT OUTER JOIN tbl_employee t5 ON FIN.AssignedTo = t5.e_id LEFT OUTER JOIN tbl_priority as t6 on FIN.Priority = t6.pr_id LEFT OUTER JOIN tbl_issue_type as t7 ON FIN.IssueType = t7.iss_id LEFT OUTER JOIN tbl_current_status as t8 on FIN.CurrentStatus = t8.cs_id  WHERE ci_isactive = 1 and (`ci_ProductName` like '%" + ser + "%' or `c_Company` like '%" + ser + "%' OR  `d_Department` like '%" + ser + "%'or Iss_Type like  '%" + ser + "%' OR pr_Priority like '%" + ser + "%' OR cs_status like '%" + ser + "%' or e_name like '%" + ser + "%')", con);
            msc.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(msc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable search_complaint_reg(string ser)
        {
            MySqlCommand msc = new MySqlCommand("SELECT *,CONCAT(if(TIMESTAMPDIFF(day,`LogCreatedTime`,`ResolutionTime`)=0,'',concat(TIMESTAMPDIFF(day,LogCreatedTime,`ResolutionTime`),' d ')) ,if(MOD( TIMESTAMPDIFF(hour,`LogCreatedTime`,`ResolutionTime`), 24)=0,'',concat(MOD( TIMESTAMPDIFF(hour,`LogCreatedTime`,`ResolutionTime`), 24), ' hrs ')),MOD( TIMESTAMPDIFF(minute,`LogCreatedTime`,`ResolutionTime`), 60), ' min ') as Resolution,CONCAT(if(TIMESTAMPDIFF(day,`LogCreatedTime`,`CommitedTime`)=0,'',concat(TIMESTAMPDIFF(day,LogCreatedTime,`CommitedTime`),' d ')) ,if(MOD( TIMESTAMPDIFF(hour,`LogCreatedTime`,`CommitedTime`), 24)=0,'',concat(MOD( TIMESTAMPDIFF(hour,`LogCreatedTime`,`CommitedTime`), 24), ' hrs ')),MOD( TIMESTAMPDIFF(minute,`LogCreatedTime`,`CommitedTime`), 60), ' min ') as Commited_time, CONCAT(if(TIMESTAMPDIFF(day,`LogCreatedTime`,`ComplaintClosedTime`)=0,'',concat(TIMESTAMPDIFF(day,LogCreatedTime,`ComplaintClosedTime`),' d ')) ,if(MOD( TIMESTAMPDIFF(hour,`LogCreatedTime`,`ComplaintClosedTime`), 24)=0,'',concat(MOD( TIMESTAMPDIFF(hour,`LogCreatedTime`,`ComplaintClosedTime`), 24), ' hrs ')),MOD( TIMESTAMPDIFF(minute,`LogCreatedTime`,`ComplaintClosedTime`), 60), ' min ') as ClosedTimeHH, ci_ProductName AS SystemName,c_company AS Company,iss_type As Complaint,pr_priority as Priority,cs_status as Status,e_Name as AssignedTo,IssueDescription As Description,ci_CreatedTime AS CreatedTime,CommitedTime,ResolutionTime,ComplaintClosedTime as ClosedTime,ActionSteps,ImpactSummary as Summary,AssetDeatils, ci_ComplaintGivenBy as GivenBy,e_Name AS ClosedEngineer FROM tbl_complaints_info as t1 left outer join (Select s.* from tbl_complaints_log_summary s inner join (SELECT ComplaintIdlog,max(`LogCreatedTime`) LogCreatedTime FROM `tbl_complaints_log_summary` GROUP by ComplaintIdlog) X on S.ComplaintIdlog=X.ComplaintIdlog and S.LogCreatedTime=X.LogCreatedTime) FIN on t1.ci_ComplaintIdinfo = FIN.ComplaintIdlog LEFT OUTER JOIN tbl_company as t3 ON t1.ci_Company = t3.c_sid LEFT OUTER JOIN tbl_departments as t4 on t1.ci_Department = t4.d_id LEFT OUTER JOIN tbl_employee t5 ON FIN.AssignedTo = t5.e_id LEFT OUTER JOIN tbl_priority as t6 on FIN.Priority = t6.pr_id LEFT OUTER JOIN tbl_issue_type as t7 ON FIN.IssueType = t7.iss_id LEFT OUTER JOIN tbl_current_status as t8 on FIN.CurrentStatus = t8.cs_id  WHERE ci_isactive = 1 and (`ci_ProductName` like '%" + ser + "%' or `c_Company` like '%" + ser + "%' OR  `d_Department` like '%" + ser + "%'or Iss_Type like  '%" + ser + "%' OR pr_Priority like '%" + ser + "%' OR cs_status like '%" + ser + "%' or e_name like '%" + ser + "%')", con);
            msc.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(msc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable search_complaint_date(DateTime sfrom, DateTime sto)
        {
           // MySqlCommand msc = new MySqlCommand("SELECT * FROM tbl_complaints_info as t1 left outer join (Select s.* from tbl_complaints_log_summary s inner join (SELECT ComplaintIdlog,max(`LogCreatedTime`) LogCreatedTime FROM `tbl_complaints_log_summary` GROUP by ComplaintIdlog) X on S.ComplaintIdlog=X.ComplaintIdlog and S.LogCreatedTime=X.LogCreatedTime) FIN on t1.ci_ComplaintIdinfo = FIN.ComplaintIdlog LEFT OUTER JOIN tbl_company as t3 ON t1.ci_Company = t3.c_sid LEFT OUTER JOIN tbl_departments as t4 on t1.ci_Department = t4.d_id LEFT OUTER JOIN tbl_employee t5 ON FIN.AssignedTo = t5.e_id LEFT OUTER JOIN tbl_priority as t6 on FIN.Priority = t6.pr_id LEFT OUTER JOIN tbl_issue_type as t7 ON FIN.IssueType = t7.iss_id LEFT OUTER JOIN tbl_current_status as t8 on FIN.CurrentStatus = t8.cs_id  WHERE ci_isactive = 1 and (`ci_CreatedTime` BETWEEN @t1 AND @t2)", con);

            MySqlCommand msc = new MySqlCommand("SELECT ci_ProductName AS SystemName,c_company AS Company,iss_type As Complaint,pr_priority as Priority,cs_status as Status,e_Name as AssignedTo,IssueDescription As Description,ci_CreatedTime AS CreatedTime,CommitedTime,ResolutionTime,ComplaintClosedTime as ClosedTime,ActionSteps,ImpactSummary as Summary,AssetDeatils, ci_ComplaintGivenBy as GivenBy,e_Name AS ClosedEngineer FROM tbl_complaints_info as t1 left outer join (Select s.* from tbl_complaints_log_summary s inner join (SELECT ComplaintIdlog,max(`LogCreatedTime`) LogCreatedTime FROM `tbl_complaints_log_summary` GROUP by ComplaintIdlog) X on S.ComplaintIdlog=X.ComplaintIdlog and S.LogCreatedTime=X.LogCreatedTime) FIN on t1.ci_ComplaintIdinfo = FIN.ComplaintIdlog LEFT OUTER JOIN tbl_company as t3 ON t1.ci_Company = t3.c_sid LEFT OUTER JOIN tbl_departments as t4 on t1.ci_Department = t4.d_id LEFT OUTER JOIN tbl_employee t5 ON FIN.AssignedTo = t5.e_id LEFT OUTER JOIN tbl_priority as t6 on FIN.Priority = t6.pr_id LEFT OUTER JOIN tbl_issue_type as t7 ON FIN.IssueType = t7.iss_id LEFT OUTER JOIN tbl_current_status as t8 on FIN.CurrentStatus = t8.cs_id  WHERE ci_isactive = 1 and (`ci_CreatedTime` BETWEEN @t1 AND @t2)", con);
           
//            ci_ProductName AS SystemName,ci_Company AS Company, ci_Department as Department, ci_ComplaintGivenBy as GivenBy, IssueType As Complaint, Priority, CurrentStatus as Status, AssignedTo, IssueDescription as Description,ci_CreatedTime as CreatedTime,CommitedTime as commitedTime,ResolutionTime, ComplaintClosedTime as ClosedTime, ActionSteps, ImpactSummary,AssetDeatils, ClosedEngineer
            
            msc.CommandType = CommandType.Text;
            msc.Parameters.Add(new MySqlParameter("@t1", sfrom));
            msc.Parameters.Add(new MySqlParameter("@t2", sto));
            MySqlDataAdapter da = new MySqlDataAdapter(msc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable search_complaint_bystatus(int sstatus, int act)
        {          
            //MySqlCommand msc = new MySqlCommand("SELECT ci_ProductName AS SystemName,c_company AS Company,iss_type As Complaint,pr_priority as Priority,cs_status as Status,e_Name as AssignedTo,IssueDescription As Description,ci_CreatedTime AS CreatedTime,CommitedTime,ResolutionTime,ComplaintClosedTime as ClosedTime,ActionSteps,ImpactSummary as Summary,AssetDeatils, ci_ComplaintGivenBy as GivenBy, e_Name AS ClosedEngineer FROM tbl_complaints_info as t1 left outer join (Select s.* from tbl_complaints_log_summary s inner join (SELECT ComplaintIdlog,max(`LogCreatedTime`) LogCreatedTime FROM `tbl_complaints_log_summary` GROUP by ComplaintIdlog) X on S.ComplaintIdlog=X.ComplaintIdlog and S.LogCreatedTime=X.LogCreatedTime) FIN on t1.ci_ComplaintIdinfo = FIN.ComplaintIdlog LEFT OUTER JOIN tbl_company as t3 ON t1.ci_Company = t3.c_sid LEFT OUTER JOIN tbl_departments as t4 on t1.ci_Department = t4.d_id LEFT OUTER JOIN tbl_employee t5 ON FIN.AssignedTo = t5.e_id LEFT OUTER JOIN tbl_priority as t6 on FIN.Priority = t6.pr_id LEFT OUTER JOIN tbl_issue_type as t7 ON FIN.IssueType = t7.iss_id LEFT OUTER JOIN tbl_current_status as t8 on FIN.CurrentStatus = t8.cs_id  WHERE ci_isactive = 1 and CurrentStatus = @CTS", con);            

            MySqlCommand msc = new MySqlCommand("SELECT ci_ProductName AS SystemName,c_company AS Company,iss_type As Complaint,pr_priority as Priority,cs_status as Status,e_Name as AssignedTo,IssueDescription As Description,ci_CreatedTime AS CreatedTime,CommitedTime,ResolutionTime,ComplaintClosedTime as ClosedTime,ActionSteps,ImpactSummary as Summary,AssetDeatils, ci_ComplaintGivenBy as GivenBy, e_Name AS ClosedEngineer FROM tbl_complaints_info as t1 left outer join (Select s.* from tbl_complaints_log_summary s inner join (SELECT ComplaintIdlog,max(`LogCreatedTime`) LogCreatedTime FROM `tbl_complaints_log_summary` GROUP by ComplaintIdlog) X on S.ComplaintIdlog=X.ComplaintIdlog and S.LogCreatedTime=X.LogCreatedTime) FIN on t1.ci_ComplaintIdinfo = FIN.ComplaintIdlog LEFT OUTER JOIN tbl_company as t3 ON t1.ci_Company = t3.c_sid LEFT OUTER JOIN tbl_departments as t4 on t1.ci_Department = t4.d_id LEFT OUTER JOIN tbl_employee t5 ON FIN.AssignedTo = t5.e_id LEFT OUTER JOIN tbl_priority as t6 on FIN.Priority = t6.pr_id LEFT OUTER JOIN tbl_issue_type as t7 ON FIN.IssueType = t7.iss_id LEFT OUTER JOIN tbl_current_status as t8 on FIN.CurrentStatus = t8.cs_id  WHERE (ci_isactive = @act and CurrentStatus =  @CTS) or (ci_isactive = @act and CurrentStatus = @CTS)", con);                                    
            msc.CommandType = CommandType.Text;           
            msc.Parameters.Add(new MySqlParameter("@CTS", sstatus));
            msc.Parameters.Add(new MySqlParameter("@act", act));
            
            MySqlDataAdapter da = new MySqlDataAdapter(msc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable search_complaint_bypriority(int spriority)
        {           
            MySqlCommand msc = new MySqlCommand("SELECT ci_ProductName AS SystemName,c_company AS Company,iss_type As Complaint,pr_priority as Priority,cs_status as Status,e_Name as AssignedTo,IssueDescription As Description,ci_CreatedTime AS CreatedTime,CommitedTime,ResolutionTime,ComplaintClosedTime as ClosedTime,ActionSteps,ImpactSummary as Summary,AssetDeatils, ci_ComplaintGivenBy as GivenBy, e_Name AS ClosedEngineer FROM tbl_complaints_info as t1 left outer join (Select s.* from tbl_complaints_log_summary s inner join (SELECT ComplaintIdlog,max(`LogCreatedTime`) LogCreatedTime FROM `tbl_complaints_log_summary` GROUP by ComplaintIdlog) X on S.ComplaintIdlog=X.ComplaintIdlog and S.LogCreatedTime=X.LogCreatedTime) FIN on t1.ci_ComplaintIdinfo = FIN.ComplaintIdlog LEFT OUTER JOIN tbl_company as t3 ON t1.ci_Company = t3.c_sid LEFT OUTER JOIN tbl_departments as t4 on t1.ci_Department = t4.d_id LEFT OUTER JOIN tbl_employee t5 ON FIN.AssignedTo = t5.e_id LEFT OUTER JOIN tbl_priority as t6 on FIN.Priority = t6.pr_id LEFT OUTER JOIN tbl_issue_type as t7 ON FIN.IssueType = t7.iss_id LEFT OUTER JOIN tbl_current_status as t8 on FIN.CurrentStatus = t8.cs_id  WHERE ci_isactive = 1 and Priority = @pty", con);
            msc.CommandType = CommandType.Text;            
            msc.Parameters.Add(new MySqlParameter("@pty", spriority));
            MySqlDataAdapter da = new MySqlDataAdapter(msc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable search_complaint_byassigned2(int assito)
        {
            //MySqlCommand msc = new MySqlCommand("SELECT * FROM tbl_complaints_info as t1 left outer join (Select s.* from tbl_complaints_log_summary s inner join (SELECT ComplaintIdlog,max(`LogCreatedTime`) LogCreatedTime FROM `tbl_complaints_log_summary` GROUP by ComplaintIdlog) X on S.ComplaintIdlog=X.ComplaintIdlog and S.LogCreatedTime=X.LogCreatedTime) FIN on t1.ci_ComplaintIdinfo = FIN.ComplaintIdlog LEFT OUTER JOIN tbl_company as t3 ON t1.ci_Company = t3.c_sid LEFT OUTER JOIN tbl_departments as t4 on t1.ci_Department = t4.d_id LEFT OUTER JOIN tbl_employee t5 ON FIN.AssignedTo = t5.e_id LEFT OUTER JOIN tbl_priority as t6 on FIN.Priority = t6.pr_id LEFT OUTER JOIN tbl_issue_type as t7 ON FIN.IssueType = t7.iss_id LEFT OUTER JOIN tbl_current_status as t8 on FIN.CurrentStatus = t8.cs_id  WHERE ci_isactive = 1 and AssignedTo = @ATe", con);

            MySqlCommand msc = new MySqlCommand("SELECT ci_ProductName AS SystemName,c_company AS Company,iss_type As Complaint,pr_priority as Priority,cs_status as Status,e_Name as AssignedTo,IssueDescription As Description,ci_CreatedTime AS CreatedTime,CommitedTime,ResolutionTime,ComplaintClosedTime as ClosedTime,ActionSteps,ImpactSummary as Summary,AssetDeatils, ci_ComplaintGivenBy as GivenBy, e_Name AS ClosedEngineer FROM tbl_complaints_info as t1 left outer join (Select s.* from tbl_complaints_log_summary s inner join (SELECT ComplaintIdlog,max(`LogCreatedTime`) LogCreatedTime FROM `tbl_complaints_log_summary` GROUP by ComplaintIdlog) X on S.ComplaintIdlog=X.ComplaintIdlog and S.LogCreatedTime=X.LogCreatedTime) FIN on t1.ci_ComplaintIdinfo = FIN.ComplaintIdlog LEFT OUTER JOIN tbl_company as t3 ON t1.ci_Company = t3.c_sid LEFT OUTER JOIN tbl_departments as t4 on t1.ci_Department = t4.d_id LEFT OUTER JOIN tbl_employee t5 ON FIN.AssignedTo = t5.e_id LEFT OUTER JOIN tbl_priority as t6 on FIN.Priority = t6.pr_id LEFT OUTER JOIN tbl_issue_type as t7 ON FIN.IssueType = t7.iss_id LEFT OUTER JOIN tbl_current_status as t8 on FIN.CurrentStatus = t8.cs_id  WHERE ci_isactive = 1 and AssignedTo = @ATe", con);
            msc.CommandType = CommandType.Text;
            msc.Parameters.Add(new MySqlParameter("@ATe", assito));
            MySqlDataAdapter da = new MySqlDataAdapter(msc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

    }
}




//   SELECT `ComInfoId`, `ComplaintIdlog`, `IssueType`, `Priority`, `CurrentStatus`, `AssignedTo`, `IssueDescription`, 
//`CommitedTime`, `ResolutionTime`, `EscalationRequired`, `ActionSteps`, `ImpactSummary`, `AssetDeatils`, `ComplaintClosedTime`,
//  `ClosedEngineer`, `Entered_By`, `LogCreatedTime`, `LogCreatedBy`, `LogIsactiveLog`, `ResolutionInHours`, `CommitedInHours`, 
//  `ClosedInHours` FROM `tbl_complaints_log_summary` WHERE 1