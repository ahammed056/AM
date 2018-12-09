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
    public partial class Menu_ManageGroup : System.Web.UI.Page
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
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
                Feedback.addFailure(ex.Message);
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
                //srchQry = "SELECT * FROM Mail_Distribution_Details where [m_delete] = 0"
                srchQry = "USP_Get_Group_details";
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
                Feedback.addFailure(ex.Message);
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
                    TextBox txtGroup_name = (TextBox)gvComapny.FooterRow.FindControl("txtGroup_name");
                    string sqlquery = "USP_Get_Group_details '" + txtGroup_name.Text + "'";
                    //Dim sqlquery As String = "Select * from Mail_Distribution_Details with(NOLOCK) where M_DELETE=0 and Report_name='" & txtreport_name.Text & "'"
                    DataTable dtExistingdiscription = objMenuBAL.GetDataTable(sqlquery);
                    if (dtExistingdiscription.Rows.Count > 0)
                    {
                        Feedback.addinfo("Record Already Exists !");
                        txtSearchbox.Text = string.Empty;
                    }
                    else
                    {
                        Insert_grid_data(txtGroup_name.Text.Trim());
                        FillMasterGrid();
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
                TextBox txteditgroup_name = (TextBox)gvComapny.Rows[e.NewEditIndex].FindControl("txtEditGroup_Name");
                ViewState["txteditgroup_name"] = txteditgroup_name.Text.Trim();
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
                txtSearchbox.Text = string.Empty;
                TextBox txteditgroup_name = (TextBox)gvComapny.Rows[e.RowIndex].FindControl("txteditgroup_name");
                //Dim record_Id As Int32 = Convert.ToInt32(gvComapny.DataKeys(e.RowIndex).Values(0).ToString)
                //----
                bool lblnDummy = false;
                Int32 record_Id = 0;
                lblnDummy = int.TryParse(gvComapny.DataKeys[e.RowIndex].Values[0].ToString(), out  record_Id);


                //----
                string strgroup = string.Empty;
                if (ViewState["txtreport_name"] != null)
                {
                    strgroup = ViewState["txtreport_name"].ToString();
                }

                string sqlquery = "USP_Get_Group_details '" + txteditgroup_name.Text.Trim() + "'";
                if (string.Compare(strgroup, txteditgroup_name.Text.Trim()) == 0)
                {
                    ViewState["txtreport_name"] = null;
                    FillMasterGrid();
                    Feedback.addinfo("No Changes Has Been Made!");
                }
                else
                {
                    DataTable dtExistingAsset = objMenuBAL.GetDataTable(sqlquery);
                    if (dtExistingAsset.Rows.Count > 1)
                    {
                        Feedback.addinfo("Record Already Exists !");
                        txtSearchbox.Text = string.Empty;
                    }
                    else
                    {
                        updaterecord(record_Id, txteditgroup_name.Text.Trim());
                        gvComapny.EditIndex = -1;
                        txtSearchbox.Text = string.Empty;
                        FillMasterGrid();
                        Feedback.addSuccess("Record Updated Successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        public void updaterecord(int ID, string Group_name)
        {
            try
            {
                if (Page.IsValid)
                {
                    string ls_sqlupdate = "";
                    ls_sqlupdate = "USP_Upd_Group_details " + ID + ",'" + Group_name + "','" + SessionVariables.UserID + "'";
                    objMenuBAL.ExecNonQuery(ls_sqlupdate);
                }
                else
                {
                    Feedback.addFailure("Please enter valid data");
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        public void DeleteAsset(int ID)
        {
            try
            {
                string ls_SqlDeleteComp = "";
                ls_SqlDeleteComp = "USP_DEL_Group_details " + ID + " , '" + SessionVariables.UserID + "'";
                objMenuBAL.ExecNonQuery(ls_SqlDeleteComp);
                Feedback.addSuccess("Record Deleted Successfully");
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        public void Insert_grid_data(string txtGroup_name)
        {
            try
            {
                if (Page.IsValid)
                {
                    string ls_SqlInsertUser = "";
                    ls_SqlInsertUser = " USP_ins_Group_details '" + txtGroup_name + "','" + SessionVariables.UserID + "',1 ";
                    objMenuBAL.ExecNonQuery(ls_SqlInsertUser);
                    Feedback.addSuccess("Record Added Successfully");
                }
                else
                {
                    Feedback.addFailure("Please enter valid data");
                }
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
