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

namespace TSTracker.RM.TS
{
    public partial class TS_ManageMaster : System.Web.UI.Page
    {

        #region [ Public Variables/Declarations ]
        
        ITTSBAL objITTSBAL;
        TSMasterBO objTSMasterBO;
        DataSet dsContent;

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
                Page.Title = RMConstraints.Page_Title_Main + RMConstraints.WebPage_ITTS_ManageMaster;
                objITTSBAL = new ITTSBAL();
                objTSMasterBO = new TSMasterBO();
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

        /// <summary>
        /// "Author : Shaik Samdani Basha"
        /// "Create date : 05-Sep-2013"
        /// "Description : Handles GridView RowEditing Event"
        /// </summary>
        /// <param name="sender">Object(Control)</param>
        /// <param name="e">System.Web.UI.WebControls.GridViewEditEventArgs</param>
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

        /// <summary>
        /// "Author : Shaik Samdani Basha"
        /// "Create date : 05-Sep-2013"
        /// "Description : Handles GridView RowUpdating Event"
        /// </summary>
        /// <param name="sender">Object(Control)</param>
        /// <param name="e">System.Web.UI.WebControls.GridViewUpdateEventArgs</param>
        protected void gvMaster_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            try
            {
                Label lblEditName = (Label)gvMaster.Rows[e.RowIndex].FindControl("lblEditName");
                TextBox txtEditName = (TextBox)gvMaster.Rows[e.RowIndex].FindControl("txtEditName");
                TextBox txtEditDescription = (TextBox)gvMaster.Rows[e.RowIndex].FindControl("txtEditDescription");
                ImageButton imgbtnUpdate = (ImageButton)gvMaster.Rows[e.RowIndex].FindControl("imgbtnUpdate");

                objTSMasterBO.MasterType = Convert.ToInt32(ddlMaster.SelectedValue);
                objTSMasterBO.ID = imgbtnUpdate.CommandArgument;
                objTSMasterBO.Name = txtEditName.Text;
                objTSMasterBO.Description = txtEditDescription.Text;
                objTSMasterBO.ModifiedBy = SessionVariables.UserID;
                if (lblEditName.Text != txtEditName.Text)
                {
                    dsContent = objITTSBAL.CheckMaster(objTSMasterBO);
                    if (dsContent.Tables[0].Rows.Count == 0)
                    {
                        objITTSBAL.UpdateMaster(objTSMasterBO);
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
                    objITTSBAL.UpdateMaster(objTSMasterBO);
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

        /// <summary>
        /// "Author : Shaik Samdani Basha"
        /// "Create date : 05-Sep-2013"
        /// "Description : Handles GridView RowDeleting Event"
        /// </summary>
        /// <param name="sender">Object(Control)</param>
        /// <param name="e">System.Web.UI.WebControls.GridViewDeleteEventArgs</param>
        protected void gvMaster_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            try
            {
                ImageButton imgbtnDelete = (ImageButton)gvMaster.Rows[e.RowIndex].FindControl("imgbtnDelete");

                objTSMasterBO.MasterType = Convert.ToInt32(ddlMaster.SelectedValue);
                objTSMasterBO.ID = imgbtnDelete.CommandArgument;
                objTSMasterBO.ModifiedBy = SessionVariables.UserID;

                dsContent = objITTSBAL.CheckInstances(objTSMasterBO);
                if (dsContent.Tables[0].Rows.Count == 0)
                {
                    objITTSBAL.DeleteMaster(objTSMasterBO);
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

        /// <summary>
        /// "Author : Shaik Samdani Basha"
        /// "Create date : 05-Sep-2013"
        /// "Description : Handles GridView RowCancelingEdit Event"
        /// </summary>
        /// <param name="sender">Object(Control)</param>
        /// <param name="e">System.Web.UI.WebControls.GridViewCancelEditEventArgs</param>
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
                if ((ITTS_MasterType)Convert.ToInt32(ddlMaster.SelectedValue) == ITTS_MasterType._Select)
                {
                    divMaster.Visible = false;
                }
                else
                {
                    divMaster.Visible = true;
                    List<TSMasterBO> objTSBOList = objITTSBAL.GetMaster(Convert.ToInt32(ddlMaster.SelectedValue));
                    gvMaster.DataSource = objTSBOList;
                    gvMaster.DataBind();
                    if (objTSBOList.Count > 0)
                    {
                        lblRecords.Text = "Total Records : " + objTSBOList.Count;
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
                objTSMasterBO.MasterType = Convert.ToInt32(ddlMaster.SelectedValue);
                objTSMasterBO.Name = txtName.Text;
                objTSMasterBO.Description = txtDescription.Text;
                objTSMasterBO.CreatedBy = SessionVariables.UserID;
                dsContent = objITTSBAL.CheckMaster(objTSMasterBO);
                if (dsContent.Tables[0].Rows.Count == 0)
                {
                    objITTSBAL.SaveMaster(objTSMasterBO);
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
