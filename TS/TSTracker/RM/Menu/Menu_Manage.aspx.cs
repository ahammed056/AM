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
    public partial class Menu_Manage : System.Web.UI.Page
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
                    string lsQuery = "";
                    DataTable ldtable = new DataTable();
                    lsQuery = "SELECT MenuMstid, MenuName FROM dbo.Menu_Master WHERE MenuParentId = '1' AND Display_Flag = '1'";
                    ldtable = objMenuBAL.GetDataTable(lsQuery);
                    BindControls.BindDropDown(ddlMainMenu, ldtable, "MenuName", "MenuMstid", DropDownOption._Select);
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
                DataTable dtAssetDetails = new DataTable();
                string txtSearchCmpny = string.Empty;
                txtSearchCmpny = txtSearchbox.Text.Trim();
                srchQry = "USP_Get_Menu_details";
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

        protected void btnSearch_Click(object sender, EventArgs e)
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchbox.Text = string.Empty;
            FillMasterGrid();
        }

        protected void gvComapny_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            txtSearchbox.Text = string.Empty;
            gvComapny.EditIndex = -1;
            FillMasterGrid();
        }

        protected void gvComapny_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                DropDownList drpparent_id = (DropDownList)gvComapny.FooterRow.FindControl("ddlParent_menu_name");
                TextBox txtmenu_name = (TextBox)gvComapny.FooterRow.FindControl("txtmenu_name");
                TextBox txtmenu_url = (TextBox)gvComapny.FooterRow.FindControl("txtmenu_url");
                TextBox txttool_tip_text = (TextBox)gvComapny.FooterRow.FindControl("txttool_tip_text");
                string sqlquery = "USP_Get_Menu_details '" + txtmenu_name.Text + "' , '" + txtmenu_url.Text + "'";
                DataTable dtExistingdiscription = objMenuBAL.GetDataTable(sqlquery);
                if (dtExistingdiscription.Rows.Count > 0)
                {
                    //Feedback.AddMessage("Menu Already Exists!", VikingMessage.enmMessageType.Info)
                    txtSearchbox.Text = string.Empty;
                }
                else
                {
                    if (drpparent_id.Text == "Root")
                    {
                        Insert_grid_data(txtmenu_name.Text.Trim(), txtmenu_url.Text.Trim(), txttool_tip_text.Text.Trim(), 0);
                    }
                    else
                    {
                        Insert_grid_data(txtmenu_name.Text.Trim(), txtmenu_url.Text.Trim(), txttool_tip_text.Text.Trim(), Convert.ToInt16(drpparent_id.SelectedValue.Trim()));
                    }

                    FillMasterGrid();
                }
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
            txtSearchbox.Text = string.Empty;
            Int32 li_CompId = Convert.ToInt32(gvComapny.DataKeys[e.RowIndex].Values[0].ToString());
            DeleteAsset(li_CompId);
            FillMasterGrid();
        }

        protected void gvComapny_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvComapny.EditIndex = e.NewEditIndex;
            FillMasterGrid();
            TextBox txtEditmenu_name = (TextBox)gvComapny.Rows[e.NewEditIndex].FindControl("txtEditmenu_name");
            TextBox txtEditmenu_url = (TextBox)gvComapny.Rows[e.NewEditIndex].FindControl("txtEditmenu_url");
            TextBox txtEdittool_tip_text = (TextBox)gvComapny.Rows[e.NewEditIndex].FindControl("txtEdittool_tip_text");

            ViewState["txtEditmenu_name"] = txtEditmenu_name.Text.Trim();
            ViewState["txtEditmenu_url"] = txtEditmenu_url.Text.Trim();
            ViewState["txtEdittool_tip_text"] = txtEdittool_tip_text.Text.Trim();
        }

        protected void gvComapny_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                txtSearchbox.Text = string.Empty;
                TextBox txtEditmenu_name = (TextBox)gvComapny.Rows[e.RowIndex].FindControl("txtEditmenu_name");
                TextBox txtEditmenu_url = (TextBox)gvComapny.Rows[e.RowIndex].FindControl("txtEditmenu_url");
                TextBox txtEdittool_tip_text = (TextBox)gvComapny.Rows[e.RowIndex].FindControl("txtEdittool_tip_text");

                //Dim record_Id As Int32 = Convert.ToInt32(gvComapny.DataKeys(e.RowIndex).Values(0).ToString)
                bool lblnDummy = false;
                Int32 record_Id = 0;

                lblnDummy = Int32.TryParse(gvComapny.DataKeys[e.RowIndex].Values[0].ToString(), out  record_Id);

                string strtxtEditmenu_name = string.Empty;
                if (ViewState["txtEditmenu_name"] != null)
                {
                    strtxtEditmenu_name = ViewState["txtEditmenu_name"].ToString();
                }
                string strtxtEditmenu_url = string.Empty;
                if (ViewState["txtEditmenu_url"] != null)
                {
                    strtxtEditmenu_url = ViewState["txtEditmenu_url"].ToString();
                }
                string strtxtEdittool_tip_text = string.Empty;
                if (ViewState["txtEdittool_tip_text"] != null)
                {
                    strtxtEdittool_tip_text = ViewState["txtEdittool_tip_text"].ToString();
                }

                string sqlquery = "USP_Get_Menu_details '" + txtEditmenu_name.Text.Trim() + "' , '" + txtEditmenu_url.Text.Trim() + "'";
                if (string.Compare(strtxtEditmenu_name, txtEditmenu_name.Text.Trim()) == 0 & string.Compare(strtxtEditmenu_url, txtEditmenu_url.Text.Trim()) == 0 & string.Compare(strtxtEdittool_tip_text, txtEdittool_tip_text.Text.Trim()) == 0)
                {
                    ViewState["txtEditmenu_name"] = null;
                    ViewState["txtEditmenu_url"] = null;
                    ViewState["txtEdittool_tip_text"] = null;
                    FillMasterGrid();
                }
                else
                {
                    DataTable dtExistingAsset = objMenuBAL.GetDataTable(sqlquery);
                    if (dtExistingAsset.Rows.Count > 1)
                    {
                        txtSearchbox.Text = string.Empty;
                    }
                    else
                    {
                        updaterecord(record_Id, txtEditmenu_name.Text.Trim(), txtEditmenu_url.Text.Trim(), txtEdittool_tip_text.Text.Trim());
                        gvComapny.EditIndex = -1;
                        txtSearchbox.Text = string.Empty;
                        FillMasterGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        public void updaterecord(int ID, string Menu_Name, string Menu_URL, string Tool_Tip_text)
        {
            try
            {
                string ls_sqlupdate = "";
                ls_sqlupdate = "USP_Upd_Menu_details '" + Menu_Name + "',  '" + Menu_URL + "', '" + Tool_Tip_text + "','" + SessionVariables.UserID + "', " + ID + "";
                objMenuBAL.ExecNonQuery(ls_sqlupdate);
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
                ls_SqlDeleteComp = "USP_DEL_Menu_details " + ID + ",'" + SessionVariables.UserID + "'";
                objMenuBAL.ExecNonQuery(ls_SqlDeleteComp);
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        public void Insert_grid_data(string menu_name, string menu_url, string tool_tip_text, string parent_id)
        {
            try
            {
                string ls_SqlInsertUser = "";
                ls_SqlInsertUser = "USP_ins_Menu_details '" + menu_name + "','" + menu_url + "','" + tool_tip_text + "','" + menu_name + "'," + parent_id + ",'" + SessionVariables.UserID + "'";
                objMenuBAL.ExecNonQuery(ls_SqlInsertUser);
                Feedback.addSuccess("New Menu Saved Successfully");
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        protected void gvComapny_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvComapny.PageIndex = e.NewPageIndex;
            FillMasterGrid();
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

        protected void ddlMainMenu_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                ddlSubMenu.Visible = true;
                lblSubMenu.Visible = true;
                ddlChildMenu.Visible = false;
                lblChildMenu.Visible = false;
                string mainmenuId = "";
                mainmenuId = ddlMainMenu.SelectedItem.Value;
                Session["MasterID"] = mainmenuId;
                string lsSubQuery = "SELECT MenuMstid, MenuName, MenuParentId FROM dbo.Menu_Master WHERE MenuParentId = '" + mainmenuId.ToString() + "' AND Display_Flag = '1'";
                DataTable ldtable = new DataTable();
                ldtable = objMenuBAL.GetDataTable(lsSubQuery);

                if (ldtable.Rows.Count > 0)
                {
                    BindControls.BindDropDown(ddlSubMenu, ldtable, "MenuName", "MenuMstid", DropDownOption._Select);
                }
                else
                {
                    ddlSubMenu.Visible = false;
                    lblSubMenu.Visible = false;
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        protected void ddlSubMenu_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                ddlChildMenu.Visible = true;
                lblChildMenu.Visible = true;
                string submenuId = "";
                submenuId = ddlSubMenu.SelectedItem.Value;
                Session["MasterID"] = submenuId;
                string lsSubQuery = "SELECT MenuMstid, MenuName, MenuParentId FROM dbo.Menu_Master WHERE MenuParentId = '" + submenuId.ToString() + "' AND Display_Flag = '1'";
                DataTable ldtable = new DataTable();
                ldtable = objMenuBAL.GetDataTable(lsSubQuery);
                if (ldtable.Rows.Count > 0)
                {
                    BindControls.BindDropDown(ddlChildMenu, ldtable, "MenuName", "MenuMstid", DropDownOption._Select);
                }
                else
                {
                    ddlChildMenu.Visible = false;
                    lblChildMenu.Visible = false;
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        protected void btnADD_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    string menuname = txtMenuName.Text.Trim();
                    string menuurl = txtManuURL.Text.Trim();
                    string menutooltip = txtToolTip.Text.Trim();

                    Insert_grid_data(menuname, menuurl, menutooltip, Session["MasterID"].ToString());
                    txtMenuName.Text = "";
                    txtManuURL.Text = "";
                    txtToolTip.Text = "";
                    ddlMainMenu.SelectedItem.Selected = false;
                    ddlSubMenu.SelectedItem.Selected = false;
                    ddlChildMenu.SelectedItem.Selected = false;
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

        public void Insert_grid_data(string menu_name, string menu_url, string tool_tip_text, Int16 parent_id)
        {
            try
            {
                string ls_SqlInsertUser = "";
                ls_SqlInsertUser = "[USP_ins_Menu_details] '" + menu_name + "','" + menu_url + "','" + tool_tip_text + "'," + parent_id + ",'" + SessionVariables.UserID + "'";
                objMenuBAL.ExecNonQuery(ls_SqlInsertUser);
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        protected void ddlChildMenu_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                string childmenuId = "";
                childmenuId = ddlChildMenu.SelectedItem.Value;
                Session["MasterID"] = childmenuId;
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

    }
}
