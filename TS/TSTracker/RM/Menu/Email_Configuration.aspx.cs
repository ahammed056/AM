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


namespace TSTracker.RM.Menu
{
    public partial class Email_Configuration : System.Web.UI.Page
    {
        #region [ Public Variables/Declarations ]
        
        CommonBAL objcommonBAL;
        string strEmails = string.Empty;
        string strDescription = string.Empty;
        string strModule = string.Empty;
        string strApproverLevel = string.Empty;
        string strAppLevelarg = string.Empty;
        string strCreatedBy = string.Empty;
        string strModifiedBy = string.Empty;
        
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
                objcommonBAL = new CommonBAL();
                dsContent = new DataSet();
                ddlModule.Focus();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        #endregion

        #region [ Control Events ]

        protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindMasterEmails();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        protected void ddlApprovalLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindMasterEmails();
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
                SaveEmailMaster();
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
                BindMasterEmails();
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
                BindMasterEmails();
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
                //Label lblEditEmail = (Label)gvMaster.Rows[e.RowIndex].FindControl("lblEditEmail");
                //TextBox txtEditEmail = (TextBox)gvMaster.Rows[e.RowIndex].FindControl("txtEditEmail");
                //ImageButton imgbtnUpdate = (ImageButton)gvMaster.Rows[e.RowIndex].FindControl("imgbtnUpdate");

                //strModule = ddlModule.SelectedValue;
                //strApproverLevel = ddlApprovalLevel.SelectedValue;
                //strEmails = txtEditEmail.Text;
                //strAppLevelarg = imgbtnUpdate.CommandArgument;
                //strModifiedBy = SessionVariables.UserID;

                //if (lblEditEmail.Text != txtEditEmail.Text)
                //{
                //    dsContent = objcommonBAL.CheckEmailMaster(strModule, strAppLevelarg, strEmails);

                //    if (dsContent.Tables[0].Rows.Count == 0)
                //    {
                //        objcommonBAL.UpdateEmailMaster(strModule, strAppLevelarg, strEmails, strModifiedBy);
                //        ClearControlValues();
                //        gvMaster.EditIndex = -1;
                //        BindMasterEmails();
                //        Feedback.addSuccess("Data saved successfully!");
                //    }
                //    else
                //    {
                //        Feedback.addinfo("'" + txtEditEmail.Text + "' already exists!");
                //        txtEditEmail.Focus();
                //    }
                //}
                //else
                //{
                //    objcommonBAL.UpdateEmailMaster(strModule, strAppLevelarg, strEmails, strModifiedBy);
                //    ClearControlValues();
                //    gvMaster.EditIndex = -1;
                //    BindMasterEmails();
                //    Feedback.addSuccess("Data saved successfully!");
                //}
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
                BindMasterEmails();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        /// <summary>
        /// "Author : Shaik Samdani Basha"
        /// "Create date : 05-Sep-2013"
        /// "Description : Handles GridView Page index change event."
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvMaster.PageIndex = e.NewPageIndex;
                BindMasterEmails();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }

        }


        #endregion

        #region [ Funcions/Methods ]

        private void BindMasterEmails()
        {
            try
            {
                //divMaster.Visible = true;
                //dsContent = objcommonBAL.GetEmailMaster(Convert.ToString(ddlModule.SelectedValue), Convert.ToString(ddlApprovalLevel.SelectedValue));
                //gvMaster.DataSource = dsContent.Tables[0];
                //gvMaster.DataBind();
                //if (dsContent.Tables[0].Rows.Count > 0)
                //{
                //    lblRecords.Text = "Total Records : " + dsContent.Tables[0].Rows.Count;
                //}
                //else
                //{
                //    lblRecords.Text = "No Records Found";
                //    divMaster.Visible = false;
                //}
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        private void SaveEmailMaster()
        {
            try
            {
                //strModule = ddlModule.SelectedValue;
                //strApproverLevel = ddlApprovalLevel.SelectedValue;
                //strEmails = txtEmail.Text;
                //strCreatedBy = SessionVariables.UserID;
                
                //dsContent = objcommonBAL.CheckEmailMaster(strModule, strApproverLevel, strEmails);
                //if (dsContent.Tables[0].Rows.Count == 0)
                //{
                //    objcommonBAL.SaveEmailMaster(strModule, strApproverLevel, strEmails, strCreatedBy);
                //    ClearControlValues();
                //    BindMasterEmails();
                //    Feedback.addSuccess("Data saved successfully!");
                //}
                //else
                //{
                //    Feedback.addinfo("'" + txtEmail.Text + "' already exists!");
                //    //txtName.Focus();
                //}
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
                ddlApprovalLevel.ClearSelection();
                ddlModule.Focus();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        #endregion

    }
}
