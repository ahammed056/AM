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
using System.IO;

namespace TSTracker.RM.TS_Hardware
{
    public partial class search_complaints : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ImageButton1.Enabled = false;
            if (!IsPostBack)
            {
                ts_hardware ts = new ts_hardware();
                DataTable dt = ts.get_employee();
                sd_byengineer.DataSource = dt;
                sd_byengineer.DataValueField = "e_id";
                sd_byengineer.DataTextField = "e_Name";
                sd_byengineer.DataBind();
                sd_byengineer.Items.Insert(0, new ListItem("--Select One--", "0"));
            }
        }

        protected void ibtn_search_onclick(object sender, EventArgs e)
        {
            ts_hardware ts = new ts_hardware();
            DataTable dt = ts.search_complaint(txt_search.Text.ToString());
            gv_search.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                ImageButton1.Enabled = true;
                Session["all_search"] = dt;
                gv_search.DataBind();
            }
            else
            {
                gv_search.DataSource = null;
                gv_search.DataBind();
                ImageButton1.Enabled = false;
            }
        }

        protected void btn_search_onclick(object sender, EventArgs e)
        {
            if ((txt_from.Text != string.Empty || txt_to.Text.ToString() != string.Empty) && sd_byengineer.SelectedIndex == 0 && sd_bypriority.SelectedIndex == 0 && sd_bystatus.SelectedIndex == 0)
            {
                ts_hardware ts = new ts_hardware();
                DataTable dt = ts.search_complaint_date(Convert.ToDateTime(txt_from.Text), Convert.ToDateTime(txt_to.Text));
                //DataTable dt = ts.search_complaint_bystatus(Convert.ToInt32(sd_bystatus.SelectedValue));
                gv_search.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    ImageButton1.Enabled = true;
                    Session["all_search"] = dt;
                    gv_search.DataBind();
                }
                else
                {
                    gv_search.DataSource = null;
                    gv_search.DataBind();
                    ImageButton1.Enabled = false;
                }

            }
            else if (sd_byengineer.SelectedIndex > 0 && (txt_from.Text == string.Empty || txt_to.Text.ToString() == string.Empty) && sd_bystatus.SelectedIndex == 0 && sd_bypriority.SelectedIndex == 0)
            {
                ts_hardware ts = new ts_hardware();
                DataTable dt = ts.search_complaint_byassigned2(Convert.ToInt32(sd_byengineer.SelectedValue));
                gv_search.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    ImageButton1.Enabled = true;
                    Session["all_search"] = dt;
                    gv_search.DataBind();
                }
                else
                {
                    gv_search.DataSource = null;
                    gv_search.DataBind();
                    ImageButton1.Enabled = false;
                }

            }

            else if (sd_bystatus.SelectedIndex > 0 && (txt_from.Text == string.Empty || txt_to.Text.ToString() == string.Empty) && sd_byengineer.SelectedIndex == 0 && sd_bypriority.SelectedIndex == 0)
            {
                //ts_hardware ts = new ts_hardware();
                //int act = 0;
                //DataTable dt = ts.search_complaint_bystatus(Convert.ToInt32(sd_bystatus.SelectedValue, act));
                //gv_search.DataSource = dt;
                //if (dt.Rows.Count > 0)
                //{
                //    ImageButton1.Enabled = true;
                //    Session["all_search"] = dt;
                //    gv_search.DataBind();
                //}
                //else
                //{
                //    gv_search.DataSource = null;
                //    gv_search.DataBind();
                //    ImageButton1.Enabled = false;
                //}

            }
            else if (sd_bypriority.SelectedIndex > 0 && (txt_from.Text == string.Empty || txt_to.Text.ToString() == string.Empty) && sd_byengineer.SelectedIndex == 0 && sd_bystatus.SelectedIndex == 0)
            {
                ts_hardware ts = new ts_hardware();
                DataTable dt = ts.search_complaint_bypriority(Convert.ToInt32(sd_bypriority.SelectedValue));
                gv_search.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    ImageButton1.Enabled = true;
                    Session["all_search"] = dt;
                    gv_search.DataBind();
                }
                else
                {
                    gv_search.DataSource = null;
                    gv_search.DataBind();
                    ImageButton1.Enabled = false;
                }

            }

        }

        protected void txt_from_TextChanged(object sender, EventArgs e)
        {
            int i = 0;
            sd_byengineer.SelectedIndex = i;
            sd_bypriority.SelectedIndex = i;
            sd_bystatus.SelectedIndex = i;

        }

        protected void sd_byengineer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            sd_bypriority.SelectedIndex = i;
            sd_bystatus.SelectedIndex = i;
            txt_from.Text = string.Empty;
            txt_to.Text = string.Empty;
            ts_hardware ts = new ts_hardware();
            DataTable dt = ts.search_complaint_byassigned2(Convert.ToInt32(sd_byengineer.SelectedValue));
            gv_search.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                ImageButton1.Enabled = true;
                Session["all_search"] = dt;
                gv_search.DataBind();
            }
            else
            {
                gv_search.DataSource = null;
                gv_search.DataBind();
                ImageButton1.Enabled = false;
            }


        }

        protected void sd_bystatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            int i = 0;
            sd_byengineer.SelectedIndex = i;
            sd_bypriority.SelectedIndex = i;
            txt_from.Text = string.Empty;
            txt_to.Text = string.Empty;
            if (sd_bystatus.SelectedIndex == 3)
            {
                int act = 0;
                ts_hardware ts = new ts_hardware();
                DataTable dt = ts.search_complaint_bystatus(Convert.ToInt32(sd_bystatus.SelectedValue), act);
               
                gv_search.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    ImageButton1.Enabled = true;
                    Session["all_search"] = dt;
                    gv_search.DataBind();
                }
                else
                {
                    gv_search.DataSource = null;
                    gv_search.DataBind();
                    ImageButton1.Enabled = false;
                }

            }
            else
            {
                int act = 1;
                ts_hardware ts = new ts_hardware();
                DataTable dt = ts.search_complaint_bystatus(Convert.ToInt32(sd_bystatus.SelectedValue), act);
                gv_search.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    ImageButton1.Enabled = true;
                    Session["all_search"] = dt;
                    gv_search.DataBind();
                }
                else
                {
                    gv_search.DataSource = null;
                    gv_search.DataBind();
                    ImageButton1.Enabled = false;
                }
            }

        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_search.PageIndex = e.NewPageIndex;
            gv_search.DataBind();
        }

        protected void sd_bypriority_index_changed(object sender, EventArgs e)
        {
            int i = 0;
            sd_byengineer.SelectedIndex = i;
            sd_bystatus.SelectedIndex = i;
            txt_from.Text = string.Empty;
            txt_to.Text = string.Empty;
            ts_hardware ts = new ts_hardware();
            DataTable dt = ts.search_complaint_bypriority(Convert.ToInt32(sd_bypriority.SelectedValue));
            gv_search.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                ImageButton1.Enabled = true;
                Session["all_search"] = dt;
                gv_search.DataBind();
            }
            else
            {
                gv_search.DataSource = null;
                gv_search.DataBind();
                ImageButton1.Enabled = false;
            }

            
        }
    
       

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if ((DataTable)Session["all_search"] != null)
            {
                string namesoffile = DateTime.Now.ToShortDateString() + "issue.xls";
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + namesoffile);
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    gv_search.AllowPaging = false;
                    gv_search.DataSource = (DataTable)Session["all_search"];
                    gv_search.HeaderRow.ForeColor = Color.Black;
                    gv_search.RenderControl(hw);
                    string style = @"<style> .textmode { } </style>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                    Session.Abandon();
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "txtrequired();", true);
            }
        }
        
    }
}
