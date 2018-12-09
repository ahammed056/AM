using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TSBAL;
using TSEntity;
using TSUtility;

namespace TSTracker.RM.Menu
{
    public partial class Menu_ManageUser : System.Web.UI.Page
    {

        #region [ Public Variables/Declarations ]

        MenuBAL objMenuBAL;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                objMenuBAL = new MenuBAL();
                if (!Page.IsPostBack)
                {
                    FillMasterGrid();
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        private void FillMasterGrid()
        {
            try
            {
                DataTable dtab = FetchMasterDetails();
                if (dtab.Rows.Count == 0)
                {
                    DataRow drItem;
                    drItem = dtab.NewRow();
                    drItem[0] = 0;
                    dtab.Rows.Add(drItem);
                }
                gvComapny.DataSource = dtab;
                gvComapny.DataBind();
                if (dtab.Rows.Count == 0)
                {
                    lblEmpty.Visible = true;
                    gvComapny.Visible = false;
                }
                else
                {
                    lblEmpty.Visible = false;
                    gvComapny.Visible = true;
                }
                DropDownList ddlGroupID_fk = (DropDownList)gvComapny.FooterRow.FindControl("ddlGroupID_fk");
                DataSet dsContent = objMenuBAL.GetDataSet("USP_GetAccessLevels");
                BindControls.BindDropDown(ddlGroupID_fk, dsContent.Tables[0], "Group Name", "Group ID", DropDownOption._Select);
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        public void dropdown_datapopulate(ref DropDownList dropdown_list, string sqlcommand, string datavaluefield, string datatextfield, string selected_item)
        {
            try
            {
                DataTable tbl_temp = objMenuBAL.GetDataTable(sqlcommand);
                dropdown_list.DataSource = tbl_temp;
                dropdown_list.DataValueField = datavaluefield;
                dropdown_list.DataTextField = datatextfield;
                dropdown_list.DataBind();
                if (!(selected_item == null) | string.IsNullOrEmpty(selected_item))
                {
                    dropdown_list.SelectedValue = selected_item;
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        public DataTable FetchMasterDetails()
        {
            try
            {
                string srchQry = null;
                DataTable dtAssetDetails = default(DataTable);
                string txtSearchCmpny = string.Empty;
                txtSearchCmpny = txtSearchbox.Text.Trim();
                srchQry = "USP_Get_User_details";
                if (!string.IsNullOrEmpty(txtSearchCmpny))
                {
                    srchQry = srchQry + "'%" + txtSearchCmpny.ToString() + "%'";
                }

                dtAssetDetails = objMenuBAL.GetDataTable(srchQry);
                return dtAssetDetails;
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
                return null;
            }
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (txtSearchbox.Text.Contains("'") == true)
                {
                    lblEmpty.Visible = true;
                    gvComapny.Visible = false;
                }
                else
                {
                    lblEmpty.Visible = false;
                    FillMasterGrid();
                    gvComapny.Visible = true;
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtSearchbox.Text = string.Empty;
                FillMasterGrid();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        protected void gvComapny_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                txtSearchbox.Text = string.Empty;
                gvComapny.EditIndex = -1;
                FillMasterGrid();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        protected void gvComapny_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName.Equals("AddNew"))
                {

                    if (Page.IsValid)
                    {
                        TextBox UserID = (TextBox)gvComapny.FooterRow.FindControl("txtUserID");
                        DropDownList txtDomain = (DropDownList)gvComapny.FooterRow.FindControl("ddldomain_footer");
                        TextBox txtUsername = (TextBox)gvComapny.FooterRow.FindControl("txtUsername");
                        DropDownList ddlGroupID_fk = (DropDownList)gvComapny.FooterRow.FindControl("ddlGroupID_fk");
                        TextBox txtpassword = (TextBox)gvComapny.FooterRow.FindControl("txtpassword");

                        string sqlquery = "USP_Get_User_details '" + UserID.Text + "' , '" + txtDomain.SelectedValue + "'";
                        DataTable dtExistingdiscription = objMenuBAL.GetDataTable(sqlquery);
                        if (dtExistingdiscription.Rows.Count > 0)
                        {
                            Feedback.addinfo("Record Already Exists !");
                            txtSearchbox.Text = string.Empty;
                        }
                        else
                        {
                            Insert_grid_data(UserID.Text.Trim(), txtUsername.Text.Trim(), txtDomain.SelectedValue, Convert.ToInt32(ddlGroupID_fk.SelectedValue), txtpassword.Text.Trim());
                            FillMasterGrid();
                        }
                    }
                    else
                    {
                        Feedback.addFailure("Please enter valid data");
                    }

                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        public Int32 dropdown_get_footerrow_value(string gv_control_name)
        {
            Int32 int_result = default(Int32);
            try
            {
                DropDownList ldrp = (DropDownList)gvComapny.FooterRow.FindControl(gv_control_name);
                int_result = Convert.ToInt32(ldrp.SelectedValue);
                return int_result;
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
                return 0;
            }
        }

        protected void gvComapny_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                txtSearchbox.Text = string.Empty;
                Int32 li_CompId = Convert.ToInt32(gvComapny.DataKeys[e.RowIndex].Values[0].ToString());
                DeleteAsset(li_CompId);
                FillMasterGrid();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        protected void gvComapny_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvComapny.EditIndex = e.NewEditIndex;
                FillMasterGrid();
                Int32 record_Id = Convert.ToInt32(gvComapny.DataKeys[e.NewEditIndex].Values[0].ToString());
                DropDownList txtEditDomain = (DropDownList)gvComapny.Rows[e.NewEditIndex].FindControl("txtEditDomain");
                TextBox txtedituserid = (TextBox)gvComapny.Rows[e.NewEditIndex].FindControl("txtedituserid");
                TextBox txteditusername = (TextBox)gvComapny.Rows[e.NewEditIndex].FindControl("txteditusername");
                TextBox txteditpassword = (TextBox)gvComapny.Rows[e.NewEditIndex].FindControl("txteditpassword");
                DropDownList ddleditGroupID_fk = (DropDownList)gvComapny.Rows[e.NewEditIndex].FindControl("ddleditGroupID_fk");

                string lsquery = null;
                lsquery = "USP_Get_User_details_id_wise " + record_Id;
                DataTable lsdt = objMenuBAL.GetDataTable(lsquery);
                string currunt_group = null;
                foreach (DataRow a in lsdt.Rows)
                {
                    currunt_group = a["GroupID_fk"].ToString();

                    ddleditGroupID_fk.SelectedValue = currunt_group;
                    txtEditDomain.SelectedValue = a["domain"].ToString();
                }

                ViewState["txtedituserid"] = txtedituserid.Text.Trim();
                ViewState["txteditusername"] = txteditusername.Text.Trim();
                ViewState["txtEditDomain"] = txtEditDomain.SelectedValue;
                ViewState["txteditpassword"] = txteditpassword.Text.Trim();
                ViewState["ddleditGroupID_fk"] = ddleditGroupID_fk.SelectedValue;

                DataSet dsContent = objMenuBAL.GetDataSet("USP_GetAccessLevels");
                BindControls.BindDropDown(ddleditGroupID_fk, dsContent.Tables[0], "Group Name", "Group ID", DropDownOption._Select);
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        protected void gvComapny_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    txtSearchbox.Text = string.Empty;
                    DropDownList txtEditDomain = (DropDownList)gvComapny.Rows[e.RowIndex].FindControl("txtEditDomain");
                    TextBox txtedituserid = (TextBox)gvComapny.Rows[e.RowIndex].FindControl("txtedituserid");
                    TextBox txteditusername = (TextBox)gvComapny.Rows[e.RowIndex].FindControl("txteditusername");
                    TextBox txteditpassword = (TextBox)gvComapny.Rows[e.RowIndex].FindControl("txteditpassword");
                    DropDownList ddleditGroupID_fk = (DropDownList)gvComapny.Rows[e.RowIndex].FindControl("ddleditGroupID_fk");
                    Int32 record_Id = Convert.ToInt32(gvComapny.DataKeys[e.RowIndex].Values[0].ToString());
                    bool lblnDummy = false;
                    lblnDummy = Int32.TryParse(gvComapny.DataKeys[e.RowIndex].Values[0].ToString(), out  record_Id);
                    string strtxtEditDomain = string.Empty;
                    if (ViewState["txtEditDomain"] != null)
                    {
                        strtxtEditDomain = ViewState["txtEditDomain"].ToString();
                    }
                    string strtxtedituserid = string.Empty;
                    if (ViewState["txtedituserid"] != null)
                    {
                        strtxtedituserid = ViewState["txtedituserid"].ToString();
                    }
                    string strtxteditusername = string.Empty;
                    if (ViewState["txteditusername"] != null)
                    {
                        strtxteditusername = ViewState["txteditusername"].ToString();
                    }
                    string strtxteditpassword = string.Empty;
                    if (ViewState["txteditpassword"] != null)
                    {
                        strtxteditusername = ViewState["txteditusername"].ToString();
                    }
                    string strddleditGroupID_fk = string.Empty;
                    if (ViewState["ddleditGroupID_fk"] != null)
                    {
                        strddleditGroupID_fk = ViewState["ddleditGroupID_fk"].ToString();
                    }
                    string sqlquery = "USP_Get_User_details '" + txtedituserid.Text.Trim() + "' , '" + txtEditDomain.Text.Trim() + "'";
                    if (string.Compare(strtxtEditDomain, txtEditDomain.SelectedValue) == 0 & string.Compare(strtxtedituserid, txtedituserid.Text.Trim()) == 0 & string.Compare(strtxteditusername, txteditusername.Text.Trim()) == 0 & string.Compare(strddleditGroupID_fk, ddleditGroupID_fk.SelectedValue) == 0 & string.Compare(strtxteditpassword, txteditpassword.Text.Trim()) == 0)
                    {
                        ViewState["txtEditDomain"] = null;
                        ViewState["txtedituserid"] = null;
                        ViewState["txteditusername"] = null;
                        FillMasterGrid();
                    }
                    else
                    {
                        DataTable dtExistingAsset = objMenuBAL.GetDataTable(sqlquery);
                        if (dtExistingAsset.Rows.Count > 1)
                        {
                            Feedback.addinfo("User Already Exists !!!");
                            txtSearchbox.Text = string.Empty;
                        }
                        else
                        {
                            updaterecord(record_Id, txtedituserid.Text.Trim(), txteditusername.Text.Trim(), txteditpassword.Text.Trim(), txtEditDomain.SelectedValue, Convert.ToInt32(ddleditGroupID_fk.SelectedValue));
                            gvComapny.EditIndex = -1;
                            txtSearchbox.Text = string.Empty;
                            FillMasterGrid();
                            Feedback.addSuccess("Record Updated Successfully");
                        }
                    }
                }
                else
                {
                    Feedback.addFailure("Please enter valid data");
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
                Feedback.addFailure("Cannot Update Record !");
            }
        }

        public void updaterecord(int ID, string Userid, string UserName, string Password, string domain, int groupid)
        {
            try
            {
                string ls_sqlupdate = "";
                ls_sqlupdate = "USP_Upd_User_details '" + Userid + "',  '" + UserName + "', '" + Password + "', '" + domain + "', " + groupid + ",'" + SessionVariables.UserID + "', " + ID + "";
                objMenuBAL.ExecNonQuery(ls_sqlupdate);
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
                Feedback.addFailure("Cannot Update Record !");
            }
        }

        public void DeleteAsset(int ID)
        {
            try
            {
                string ls_SqlDeleteComp = "";
                ls_SqlDeleteComp = "USP_DEL_User_details " + ID + ",'" + SessionVariables.UserID + "'";
                objMenuBAL.ExecNonQuery(ls_SqlDeleteComp);
                Feedback.addSuccess("Record Deleted Successfully");
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
                Feedback.addFailure("Cannot Delete Record !");
            }
        }

        public void Insert_grid_data(string UserId, string Username, string DomainName, int groupid, string password)
        {
            try
            {
                string ls_SqlInsertUser = "";
                ls_SqlInsertUser = "USP_ins_User_details '" + UserId + "','" + Username + "','" + DomainName + "'," + groupid + ",'" + password + "', '" + SessionVariables.UserID + "'";
                objMenuBAL.ExecNonQuery(ls_SqlInsertUser);
                Feedback.addSuccess("Record Added Successfully");
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
                Feedback.addFailure("Cannot Add New Record !");
            }
        }

        protected void gvComapny_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvComapny.PageIndex = e.NewPageIndex;
                FillMasterGrid();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        protected void gvComapny_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    foreach (DataControlFieldCell cell in e.Row.Cells)
                    {
                        foreach (Control control in cell.Controls)
                        {
                            ImageButton button = control as ImageButton;
                            if (button != null && button.CommandName == "Delete")
                            {
                                button.OnClientClick = "if (!confirm('Are you sure " + "you want to delete this Record?')) return;";
                                button.ToolTip = "Delete";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

    }
}
