using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TSDAL;
using TSEntity;
using TSUtility;
using System.Drawing;
using System.DirectoryServices;


namespace TSTracker.RM.TS_Hardware
{
    public partial class register_complaints : System.Web.UI.Page
    {
        TSBO objTSBO;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            if (!Page.IsPostBack)
            {
                get_griddata();
                get_companydata();
                get_employeeData();
                get_issue_type();
                get_priority();
                get_current_status();
                if (ddl_department.SelectedIndex == -1)
                {
                    ddl_department.Items.Insert(0, new ListItem("-- Select One --", "0"));
                }
                else
                {
                   // get_departmentdata();
                }
            }
        }

        #region pageload data
        public void get_companydata()
        {
            ts_hardware ts = new ts_hardware();
            DataTable dt = ts.get_company();
            ddl_company.DataSource = dt;
            ddl_company.DataValueField = "c_sid";
            ddl_company.DataTextField = "c_company";
            ddl_company.DataBind();
            ddl_company.Items.Insert(0, new ListItem("-- Select One --", "0"));
        }
        public void get_issue_type()
        {
            ts_hardware ts = new ts_hardware();
            DataTable dt = ts.get_issue_type();
            ddl_issue_type.DataSource = dt;
            ddl_issue_type.DataValueField = "iss_id";
            ddl_issue_type.DataTextField = "iss_type";
            ddl_issue_type.DataBind();
            ddl_issue_type.Items.Insert(0, new ListItem("-- Select One --", "0"));
        }
        private void get_current_status()
        {
            ts_hardware ts = new ts_hardware();
            DataTable dt = ts.get_current_status();
            ddl_current_status.DataSource = dt;
            ddl_current_status.DataValueField = "cs_id";
            ddl_current_status.DataTextField = "cs_status";
            ddl_current_status.DataBind();
            ddl_current_status.Items.Insert(0, new ListItem("-- Select One --", "0"));
        }
        private void get_priority()
        {
            ts_hardware ts = new ts_hardware();
            DataTable dt = ts.get_priority();
            ddl_priority.DataSource = dt;
            ddl_priority.DataValueField = "pr_id";
            ddl_priority.DataTextField = "pr_priority";
            ddl_priority.DataBind();
            ddl_priority.Items.Insert(0, new ListItem("-- Select One --", "0"));
        }               
        public void get_employeeData()
        {

            ts_hardware ts = new ts_hardware();
            DataTable dt = ts.get_employee();
            ddl_assigned_to_engineer.DataSource = dt;
            ddl_assigned_to_engineer.DataValueField = "e_id";
            ddl_assigned_to_engineer.DataTextField = "e_Name";
            ddl_assigned_to_engineer.DataBind();
            ddl_assigned_to_engineer.Items.Insert(0, new ListItem("--Select One--", "0"));

            ddl_closed_engineer.DataSource = dt;
            ddl_closed_engineer.DataValueField = "e_id";
            ddl_closed_engineer.DataTextField = "e_Name";
            ddl_closed_engineer.DataBind();
            ddl_closed_engineer.Items.Insert(0, new ListItem("--Select One--", "0"));
        }
        public void get_griddata()
        {
            ts_hardware ts = new ts_hardware();
            DataTable dt = ts.get_gv1data();

            if (dt.Rows.Count > 0)
            {
                gv1.DataSource = dt;
                gv1.DataBind();
                lblNoRec.Visible = false;
                gv1.Visible = true;
            }
            else {
                lblNoRec.Visible = true;
                gv1.Visible = false;
            }

            
            
        } 
        #endregion

        protected void btn_submit_onclick(object sender, EventArgs e)
        {
            if (btn_submit.Text == "Submit")
            {
                if (string.IsNullOrEmpty(txt_sysnumber.Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "txtrequired();", true);
                }
                else if (ddl_company.SelectedIndex == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "txtrequired();", true);
                }              
                else
                {
                    dbcomplaintentites dbc = new dbcomplaintentites();
                    dbc.System_number = txt_sysnumber.Text.ToString();
                   // dbc.Department = Convert.ToInt32(ddl_department.SelectedItem.Value);
                    dbc.Department = Convert.ToInt32(ddl_department.SelectedItem.Value);
                    dbc.Company = Convert.ToInt32(ddl_company.SelectedItem.Value);
                    dbc.Issue_type = Convert.ToInt32(ddl_issue_type.SelectedItem.Value);
                    dbc.Priority = Convert.ToInt32(ddl_priority.SelectedItem.Value);
                    dbc.Current_status = Convert.ToInt32(ddl_current_status.SelectedItem.Value);
                    dbc.Assigned_to_engineer = Convert.ToInt32(ddl_assigned_to_engineer.SelectedItem.Value);
                    dbc.Issue_desc = txt_issuedesc.Text.ToString();
                    if (string.IsNullOrEmpty(txt_Commited_time.Text))
                    {
                        dbc.Commited_time = Convert.ToDateTime(null);
                    }
                    else
                    {
                        dbc.Commited_time = Convert.ToDateTime(txt_Commited_time.Text.ToString());
                    }
                    if (string.IsNullOrEmpty(txt_resolution_time.Text))
                    {
                        dbc.Resolution_time = Convert.ToDateTime(null);
                    }
                    else
                    {
                        dbc.Resolution_time = Convert.ToDateTime(txt_resolution_time.Text.ToString());
                    }
                    dbc.Escalation_required = ddl_escalation_required.SelectedItem.Text.ToString();
                    dbc.Action_steps = txt_action_steps.Text.ToString();
                    dbc.Impact_summary = txt_impact_summary.Text.ToString();
                    dbc.Asset_deatils = txt_asset_deatils.Text.ToString();
                    if (string.IsNullOrEmpty(txt_issue_closed_time.Text))
                    {
                        dbc.Issue_closed_time = Convert.ToDateTime(null);
                    }
                    else
                    {
                        dbc.Issue_closed_time = Convert.ToDateTime(txt_issue_closed_time.Text.ToString());
                    }
                    dbc.Closed_engineer = ddl_closed_engineer.SelectedIndex;

                    objTSBO = new TSBO();                    
                    dbc.Entered_by = SessionVariables.UserName ;
                   
                    ts_hardware tsh = new ts_hardware();
                    int i = tsh.insert_complaintdata(dbc);
                    if (i > 0)
                    {
                        get_griddata();                        
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "inserted();", true);
                        textclear();
                    }
                    else
                    {
                        get_griddata();
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "noinserted();", true);
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txt_sysnumber.Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "txtrequired();", true);
                }
                else if (ddl_company.SelectedItem.Text == "-- select One --")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "txtrequired();", true);
                }

                else
                {
                    dbcomplaintentites dbc = new dbcomplaintentites();
                    dbc.Issue_type = Convert.ToInt32(ddl_issue_type.SelectedValue);
                    dbc.Priority = Convert.ToInt32(ddl_priority.SelectedValue);
                    dbc.Current_status = Convert.ToInt32(ddl_current_status.SelectedValue);
                    dbc.Assigned_to_engineer = Convert.ToInt32(ddl_assigned_to_engineer.SelectedValue);
                    dbc.Issue_desc = txt_issuedesc.Text.ToString();
                    if (string.IsNullOrEmpty(txt_Commited_time.Text))
                    {
                        dbc.Commited_time = Convert.ToDateTime(null);
                    }
                    else
                    {
                        dbc.Commited_time = Convert.ToDateTime(txt_Commited_time.Text.ToString());
                    }

                    if (string.IsNullOrEmpty(txt_resolution_time.Text))
                    {
                        dbc.Resolution_time = Convert.ToDateTime(null);
                    }
                    else
                    {
                        dbc.Resolution_time = Convert.ToDateTime(txt_resolution_time.Text.ToString());
                    }
                    dbc.Escalation_required = ddl_escalation_required.SelectedItem.Text.ToString();
                    dbc.Action_steps = txt_action_steps.Text.ToString();
                    dbc.Impact_summary = txt_impact_summary.Text.ToString();
                    dbc.Asset_deatils = txt_asset_deatils.Text.ToString();
                    if (string.IsNullOrEmpty(txt_issue_closed_time.Text))
                    {
                        dbc.Issue_closed_time = Convert.ToDateTime(null);
                    }
                    else
                    {
                        dbc.Issue_closed_time = Convert.ToDateTime(txt_issue_closed_time.Text.ToString());
                    }

                    dbc.Closed_engineer = Convert.ToInt32(ddl_closed_engineer.SelectedValue);
                    ts_hardware tsh = new ts_hardware();
                    int i = tsh.Update_complaintdata(dbc, hfieldupd.Value);
                    if (i == 1)
                    {
                       
                        if (ddl_current_status.SelectedItem.Text == "Closed")
                        {
                            dbcomplaintentites dc = new dbcomplaintentites();
                            ts_hardware ts = new ts_hardware();
                            int ii = ts.delete_complaint(dc, hfieldupd.Value);
                            if (ii == 1)
                            {
                                get_griddata();
                               // Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "deleted();", true);
                            }
                        }
                       
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "Updated();", true);
                        Response.Redirect("register_complaints.aspx");
                    }
                    else
                    {
                        get_griddata();
                        // Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "noinserted();", true);
                    }
                }
            }
           
        }
        protected void btn_grid_edit_OnClick(object sender, EventArgs e)
        {
            btn_submit.Text = "Update";
            txt_sysnumber.Enabled = false;   
            //ddl_assigned_to_engineer.Enabled = false;
            ddl_company.Enabled = false;
            ddl_department.Enabled = false;
            ImageButton btn = (ImageButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            HiddenField hiduno = (HiddenField)gvr.FindControl("hfield");
            hfieldupd.Value = hiduno.Value;
            dbcomplaintentites dbc = new dbcomplaintentites();
            ts_hardware tsh = new ts_hardware();
            tsh.showgriddata(dbc, hiduno.Value);                                  
            txt_sysnumber.Text = dbc.System_number;          
            ddl_company.SelectedValue = dbc.Company.ToString();             
            if (ddl_department.SelectedIndex == -1)
            {
                ddl_department.Items.Insert(0, new ListItem("-- Select One --", "0"));

            }
            else 
            { 
             
               
            }
          
            ddl_issue_type.SelectedValue  = (dbc.Issue_type).ToString();
            ddl_priority.SelectedValue = dbc.Priority.ToString();
            ddl_current_status.SelectedValue = dbc.Current_status.ToString();

            ddl_assigned_to_engineer.SelectedValue = dbc.Assigned_to_engineer.ToString();
            
            txt_issuedesc.Text = dbc.Issue_desc;
            txt_Commited_time.Text = dbc.Commited_time.ToString();
            txt_resolution_time.Text = dbc.Resolution_time.ToString();
            ddl_escalation_required.SelectedIndex = Convert.ToSByte(dbc.Escalation_required);
            txt_action_steps.Text = dbc.Action_steps;
            txt_impact_summary.Text = dbc.Impact_summary;
            txt_asset_deatils.Text = dbc.Asset_deatils;

            ddl_closed_engineer.SelectedValue = dbc.Closed_engineer.ToString();
            
            txt_issue_closed_time.Text = dbc.Issue_closed_time.ToString();

       //     string dtts = dbc.Created_time.ToString();

        }
        protected void btn_grid_del_OnClick(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            HiddenField hiduno = (HiddenField)gvr.FindControl("hfield");        
            dbcomplaintentites dc = new dbcomplaintentites();
            ts_hardware ts = new ts_hardware();
            int i = ts.delete_complaint(dc, hiduno.Value);
            if (i == 1)
            {
                get_griddata();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "deleted();", true);               
            }
          
        }
        protected void btn_search_OnClick(object sender, EventArgs e)
        {
            ts_hardware ts = new ts_hardware();
            DataTable dt = ts.search_complaint_reg(txt_search.Text.ToString());

            if (dt.Rows.Count > 0)
            {
                gv1.DataSource = dt;
                gv1.DataBind();
                lblNoRec.Visible = false;
                gv1.Visible = true;
            }
            else {
                lblNoRec.Visible = true;
                gv1.Visible = false;            
            }


            
        }
        protected void gv1indexchanging(object sender, GridViewPageEventArgs e)
        {
            gv1.PageIndex = e.NewPageIndex;
            gv1.DataBind();
        }        

        #region to_clear_text_box
        protected void btn_reset_OnClick(object sender, EventArgs e)
        {
            textclear();
        }
        private void textclear()
        {
            txt_sysnumber.Text = string.Empty;
            txt_issuedesc.Text = string.Empty;
            txt_impact_summary.Text = string.Empty;
            txt_Commited_time.Text = string.Empty;
            txt_asset_deatils.Text = string.Empty;
            txt_action_steps.Text = string.Empty;
            txt_issue_closed_time.Text = string.Empty;
            txt_resolution_time.Text = string.Empty;

        }
        #endregion

        protected void ddl_company_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_departmentdata();
        }
        public void get_departmentdata()
        {
            ts_hardware ts = new ts_hardware();
            int dpid = Convert.ToInt32(ddl_company.SelectedItem.Value);
            DataTable dt = ts.get_department(dpid);
            ddl_department.DataSource = dt;
            ddl_department.DataValueField = "d_id";
            ddl_department.DataTextField = "d_department";
            ddl_department.DataBind();
            ddl_department.Items.Insert(0, new ListItem("-- Select One-- ", "0"));
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gv=e.Row;
                HiddenField hdn = (HiddenField)e.Row.FindControl("hfstatus");
                string status = hdn.Value;

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    if (status == "Open")
                    {
                        e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;
                    }
                    else if (status == "Work In Progress")
                    {
                        e.Row.Cells[4].ForeColor = System.Drawing.Color.DarkGreen;
                    }
                    else
                    {
                        e.Row.Cells[4].ForeColor = System.Drawing.Color.Black;
                    }

                }
             
            }
        }



       
    }
}



