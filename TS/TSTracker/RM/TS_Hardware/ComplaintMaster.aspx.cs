using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSDAL;
using System.Data;
using System.Drawing;

namespace TSTracker.RM.TS_Hardware
{
    public partial class ComplaintMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                get_cm_ddl_company();
                getemployee_grid();
                getcompany_grid();
                get_gv_cm_department_grid();
                get_id_Complaint();
                
            }
        }
        public void getemployee_grid()
        {
            ts_hardware ts = new ts_hardware();
            DataTable dt = ts.get_employee();
            gv_employee.DataSource = dt;           
            gv_employee.DataBind();
        }
        public void get_cm_ddl_company()
        {
            ts_hardware ts = new ts_hardware();
            DataTable dt = ts.get_company();
            cm_dll_comapny_name.DataSource = dt;
            cm_dll_comapny_name.DataTextField = "c_company";
            cm_dll_comapny_name.DataValueField = "c_did";
            cm_dll_comapny_name.DataBind();
            cm_dll_comapny_name.Items.Insert(0, new ListItem("--Select One --", "0"));
        }
        public void get_gv_cm_department_grid()
        {
            ts_hardware ts = new ts_hardware();
            DataTable dt = ts.get_departments_full();
            gv_cm_department.DataSource = dt;
            gv_cm_department.DataBind();                       
        }
        protected void gv_cm_employee_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gv = e.Row;
                HiddenField hdnstatus = (HiddenField)e.Row.FindControl("hfempstatus");
                string status = hdnstatus.Value;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (status == "0")
                    {
                        e.Row.Cells[4].Text = "Existing";
                        e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        e.Row.Cells[4].Text = "Working";
                    }

                }

            }
        }
        protected void gvcm_employee_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_employee.PageIndex = e.NewPageIndex;
            gv_employee.DataBind();
        }
        public void getcompany_grid()
        {
            ts_hardware ts = new ts_hardware();
            DataTable dt = ts.get_company();
            cm_gv_companydetails.DataSource = dt;
            cm_gv_companydetails.DataBind();
        }


        public void get_id_Complaint()
        {
            ts_hardware ts = new ts_hardware();
            DataTable dt = ts.get_gv1data();
            gv_cm_id_complaint_history.DataSource = dt;
            gv_cm_id_complaint_history.DataBind();
        }




        protected void OnRowDataBound_id_complaint_history(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gv_cm_id_complaint_history, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }
        protected void gv_id_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Label txtTotal = (Label)gv_cm_id_complaint_history.Rows[gv_cm_id_complaint_history.SelectedIndex].Cells[0].FindControl("Label2");
            string value = txtTotal.Text;
           // Response.Write(value);

            ts_hardware ts = new ts_hardware();
            DataTable dt = ts.get_Complaintdata2_for_search(value);
            gv_cm_full_complaint_history.DataSource = dt;
            gv_cm_full_complaint_history.DataBind();
            //foreach (GridViewRow row in gv_cm_id_complaint_history.Rows)
            //{
            //    if (row.RowIndex == gv_cm_id_complaint_history.SelectedIndex)
            //    {
            //        row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
            //        row.ToolTip = string.Empty;
            //    }
            //    else
            //    {
            //        row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            //        row.ToolTip = "Click to select this row.";
            //    }
            //}
        }

    }
}
//foreach (GridViewRow row in gv_cm_id_complaint_history.Rows)
//{
//    if (row.RowIndex == gv_cm_id_complaint_history.SelectedIndex)
//    {
//        row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
//        row.ToolTip = string.Empty;
//    }
//    else
//    {
//        row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
//        row.ToolTip = "Click to select this row.";
//    }
//}