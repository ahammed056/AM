using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSBAL;
using TSEntity;
using TSUtility;
using System.Data;

namespace TSTracker.RM.PRO
{
    public partial class PRO_ManageMaster : System.Web.UI.Page
    {

        #region [ Public Variables/Declarations ]
        
        ITPROBAL objITPROBAL;
        PROMasterBO objPROMasterBO;

        DataSet dsContent;
        DataSet dsDistContent;
        DataSet dsMandContent;

        #endregion

        #region [ Page Events ]

        protected void Page_PreInit(object sender, EventArgs e)
        {
            try
            {
                Page.Theme = RMConstraints.Page_Theme_Default;
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Title = RMConstraints.Page_Title_PRO_Main + RMConstraints.WebPage_ITPRO_ManageMaster;
                objITPROBAL = new ITPROBAL();
                objPROMasterBO = new PROMasterBO();

                if (!IsPostBack)
                {
                    dsDistContent = objITPROBAL.GetDistrictMst();
                    BindControls.BindDropDown(ddlDistrict, dsDistContent.Tables[0], "Name", "ID", DropDownOption._Select);
                }
                txtName.Focus();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        #endregion

        #region [ Control Events ]

        #region [ Control Events ]

        protected void ddlMaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                if (ddlMaster.SelectedValue == "1002")
                {
                    trDistrict.Visible = true;
                    trMandal.Visible = false;

                    dsDistContent = objITPROBAL.GetDistrictMst();
                    BindControls.BindDropDown(ddlDistrict, dsDistContent.Tables[0], "Name", "ID", DropDownOption._Select);
                }
                else if (ddlMaster.SelectedValue == "1003")
                {
                    trDistrict.Visible = true;
                    trMandal.Visible = true;

                    dsDistContent = objITPROBAL.GetDistrictMst();
                    BindControls.BindDropDown(ddlDistrict, dsDistContent.Tables[0], "Name", "ID", DropDownOption._Select);
                }
                else
                {
                    trDistrict.Visible = false;
                    trMandal.Visible = false;
                }

                BindMasters();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        { 
            try
            {
                dsMandContent = objITPROBAL.GetMandalMst(ddlDistrict.SelectedValue);
                BindControls.BindDropDown(ddlMandal, dsMandContent.Tables[0], "Name", "ID", DropDownOption._Select);
                BindMasters();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }

        }

        protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //dsMandContent = objITPROBAL.GetVillageMst(ddlDistrict.SelectedValue, ddlMandal.SelectedValue);
                //BindControls.BindDropDown(ddlvillage, dsMandContent.Tables[0], "Name", "ID", DropDownOption._Select);

                BindMasters();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SaveMaster();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControlValues();
                BindMasters();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }
       
        #endregion

        #region [ GridView-Main ]

        protected void gvMaster_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            try
            {
                gvMaster.EditIndex = e.NewEditIndex;
                BindMasters();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        protected void gvMaster_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            try
            {
                Label lblEditName = (Label)gvMaster.Rows[e.RowIndex].FindControl("lblEditName");
                TextBox txtEditName = (TextBox)gvMaster.Rows[e.RowIndex].FindControl("txtEditName");
                TextBox txtEditDescription = (TextBox)gvMaster.Rows[e.RowIndex].FindControl("txtEditDescription");
                ImageButton imgbtnUpdate = (ImageButton)gvMaster.Rows[e.RowIndex].FindControl("imgbtnUpdate");

                objPROMasterBO.MasterType = Convert.ToInt32(ddlMaster.SelectedValue);
                objPROMasterBO.ID = imgbtnUpdate.CommandArgument;
                objPROMasterBO.Name = txtEditName.Text;
                objPROMasterBO.DistId = ddlDistrict.SelectedValue;
                objPROMasterBO.MandalId = ddlMandal.SelectedValue;
                objPROMasterBO.Description = txtEditDescription.Text;
                objPROMasterBO.ModifiedBy = SessionVariables.UserID;
                if (lblEditName.Text != txtEditName.Text)
                {
                    dsContent = objITPROBAL.CheckMaster(objPROMasterBO);
                    if (dsContent.Tables[0].Rows.Count == 0)
                    {
                        objITPROBAL.UpdateMaster(objPROMasterBO);
                        ClearControlValues();
                        gvMaster.EditIndex = -1;
                        BindMasters();
                        Feedback.addSuccess("Data saved successfully!");
                    }
                    else
                    {
                        Feedback.addinfo("'" + txtEditName.Text + "' already exists!");
                        txtEditName.Focus();
                    }
                }
                else
                {
                    objITPROBAL.UpdateMaster(objPROMasterBO);
                    ClearControlValues();
                    gvMaster.EditIndex = -1;
                    BindMasters();
                    Feedback.addSuccess("Data saved successfully!");
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

       
        protected void gvMaster_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            try
            {
                ImageButton imgbtnDelete = (ImageButton)gvMaster.Rows[e.RowIndex].FindControl("imgbtnDelete");

                objPROMasterBO.MasterType = Convert.ToInt32(ddlMaster.SelectedValue);
                objPROMasterBO.ID = imgbtnDelete.CommandArgument;
                objPROMasterBO.ModifiedBy = SessionVariables.UserID;

                //dsContent = objITPROBAL.CheckInstances(objPROMasterBO);
                if (dsContent.Tables[0].Rows.Count == 0)
                {
                    objITPROBAL.DeleteMaster(objPROMasterBO);
                    ClearControlValues();
                    BindMasters();
                    Feedback.addSuccess("Data deleted successfully!");
                }
                else
                {
                    Feedback.addinfo("You cannot delete the " + "'" + ddlMaster.SelectedItem.Text + "', its already mapped with the Instance!");
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        protected void gvMaster_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            try
            {
                gvMaster.EditIndex = -1;
                BindMasters();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }
        protected void gvMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvMaster.PageIndex = e.NewPageIndex;
                BindMasters();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }
        #endregion

        #endregion

        #region [ Funcions/Methods ]

        private void BindMasters()
        {
            try
            {
                if ((ITPRO_MasterType)Convert.ToInt32(ddlMaster.SelectedValue) == ITPRO_MasterType._Select)
                {
                    divMaster.Visible = false;
                }
                else
                {
                    divMaster.Visible = true;
                    List<PROMasterBO> objPROMasterBOList = objITPROBAL.GetMaster(Convert.ToInt32(ddlMaster.SelectedValue), ddlDistrict.SelectedValue, ddlMandal.SelectedValue);
                    gvMaster.DataSource = objPROMasterBOList;
                    gvMaster.DataBind();
                    if (objPROMasterBOList.Count > 0)
                    {
                        lblRecords.Text = "Total Records : " + objPROMasterBOList.Count;
                    }
                    else
                    {
                        lblRecords.Text = "No Records Found";
                    }
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        private void SaveMaster()
        {
            try
            {
                objPROMasterBO.MasterType = Convert.ToInt32(ddlMaster.SelectedValue);
                objPROMasterBO.Name = txtName.Text;
                objPROMasterBO.Description = txtDescription.Text;
                objPROMasterBO.CreatedBy = SessionVariables.UserID;
                objPROMasterBO.DistId = ddlDistrict.SelectedValue;
                objPROMasterBO.MandalId = ddlMandal.SelectedValue;
                dsContent = objITPROBAL.CheckMaster(objPROMasterBO);
                if (dsContent.Tables[0].Rows.Count == 0)
                {
                    objITPROBAL.SaveMaster(objPROMasterBO);
                    ClearControlValues();
                    BindMasters();
                    Feedback.addSuccess("Data saved successfully!");
                }
                else
                {
                    Feedback.addinfo("'" + txtName.Text + "' already exists!");
                    txtName.Focus();
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        private void ClearControlValues()
        {
            try
            {
                // Clear the control value of type TextBox
                trDistrict.Visible = false;
                trMandal.Visible = false;
                txtName.Text = string.Empty;
                txtDescription.Text = string.Empty;
                txtName.Focus();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        #endregion

      

    }
}
