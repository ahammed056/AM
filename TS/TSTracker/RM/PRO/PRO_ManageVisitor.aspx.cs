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
    public partial class PRO_ManageVisitor : System.Web.UI.Page
    {

        #region [ Public Variables/Declarations ]

        ITPROBAL objITPROBAL;
        PROBO objPROBO;
        Mailer objMailer;
        DataSet dsContent;
        DataSet dsMandal;
        DataSet dsVillage;

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
                Page.Title = RMConstraints.Page_Title_Main + RMConstraints.WebPage_ITPRO_ManageVisitor;
                objITPROBAL = new ITPROBAL();
                objMailer = new Mailer();
                dsContent = new DataSet();
                if (!IsPostBack)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["InsID"]))
                    {
                        hdnPrID.Value = "test";
                        hdnTransId.Value = Request.QueryString["InsID"].ToString().Trim();
                        LoadMasters();
                        LoadInstance();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        #endregion

        #region [ Control Events ]

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                dsMandal = objITPROBAL.GetMandalMst(ddlDistrict.SelectedValue);
                BindControls.BindDropDown(ddlMandal, dsMandal.Tables[0], "Name", "ID", DropDownOption._Select);
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
                dsVillage = objITPROBAL.GetVillageMst(ddlDistrict.SelectedValue, ddlMandal.SelectedValue);
                BindControls.BindDropDown(ddlVillage, dsVillage.Tables[0], "Name", "ID", DropDownOption._Select);

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
                UpdateInstance();
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
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

      
        #endregion

        #region [ Funcions/Methods ]

        private void LoadMasters()
        {
            try
            {
                foreach (KeyValuePair<ITPRO_MasterType, DropDownList> kvp in GetDropDownListDictionary())
                {
                    kvp.Value.Items.Clear();
                    List<PROMasterBO> objPROMasterBOList = objITPROBAL.GetMaster((int)Enum.Parse(typeof(ITPRO_MasterType), Enum.GetName(typeof(ITPRO_MasterType), kvp.Key)),"","");
                    if (objPROMasterBOList.Count > 0)
                    {
                        kvp.Value.DataValueField = RMConstraints.DropDownList_Master_DataValueField;
                        kvp.Value.DataTextField = RMConstraints.DropDownList_Master_DataTextField;
                        kvp.Value.DataSource = objPROMasterBOList;
                        kvp.Value.DataBind();
                    }
                    BindControls.AddOptionalItem(kvp.Value, DropDownOption._Select);
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        private void LoadInstance()
        {
            try
            {
                objPROBO = new PROBO();

                objPROBO.PrId = hdnPrID.Value;
                objPROBO.TransId = hdnTransId.Value;
                objPROBO = objITPROBAL.GetVisitorDtls(objPROBO);

                txtPrId.Text = objPROBO.PrId;
                txtTranId.Text = objPROBO.TransId;
                txtPrName.Text = objPROBO.VisitorName;
                txtFatherName.Text = objPROBO.FatherName;
                txtProofId.Text = objPROBO.ProofId;
                txtContactNo.Text = objPROBO.ContactNo;
                txtVisitDate.Text = objPROBO.VisitDate.ToString();
                txtNextCallDate.Text = objPROBO.NextCallDate.ToString();
                txtVisitPurpose.Text = objPROBO.VisitPurpose;
                txtRemarks.Text = objPROBO.Remarks;


                ddlDistrict.ClearSelection();
                ddlMandal.ClearSelection();
                ddlVillage.ClearSelection();
                ddlProofType.ClearSelection();
                ddlStatus.ClearSelection();
                
                //// Set the control selection value of type DropdownList
                ddlDistrict.Items.FindByValue(objPROBO.DistId).Selected = true;
                ddlMandal.Items.FindByValue(objPROBO.MandalId).Selected = true;
                ddlVillage.Items.FindByValue(objPROBO.VillageId).Selected = true;
                ddlProofType.Items.FindByValue(objPROBO.ProofTypeId).Selected = true;
                ddlStatus.SelectedValue = Convert.ToString(objPROBO.StatusId);

                txtPrName.Focus();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        private void UpdateInstance()
        {
            try
            {
                objPROBO = new PROBO();
                objPROBO.TransId = hdnTransId.Value;
                objPROBO.PrId = hdnPrID.Value;
                objPROBO.VisitorName = txtPrName.Text.Trim();
                objPROBO.FatherName = txtFatherName.Text.Trim();
                objPROBO.ProofId = txtProofId.Text;
                objPROBO.ContactNo = txtContactNo.Text;
                objPROBO.VisitDate = Convert.ToDateTime(txtVisitDate.Text);
                objPROBO.NextCallDate = Convert.ToDateTime(txtNextCallDate.Text);
                objPROBO.VisitPurpose = txtVisitPurpose.Text;
                objPROBO.Remarks = txtRemarks.Text;
                objPROBO.DistId = ddlDistrict.SelectedValue;
                objPROBO.MandalId = ddlMandal.SelectedValue;
                objPROBO.VillageId = ddlVillage.SelectedValue;
                objPROBO.ProofTypeId = ddlProofType.SelectedValue;

                objPROBO.StatusId = Convert.ToInt32(ddlStatus.SelectedValue);
                objPROBO.ModifiedBy = SessionVariables.UserID;
                objITPROBAL.UpdateVisitorDtls(objPROBO);
                Feedback.addFailure("Record has been updated successfully!!");
             
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
                Feedback.addFailure("Failed to Insert Record !");
            }
        }

        private void ClearControlValues()
        {
            try
            {
                // Clear the control value of type TextBox

                txtPrName.Text = string.Empty;
                txtFatherName.Text = string.Empty;
                txtProofId.Text = string.Empty;
                txtContactNo.Text = string.Empty;
                txtVisitDate.Text = string.Empty;
                txtNextCallDate.Text = string.Empty;
                txtVisitPurpose.Text = string.Empty;
                txtRemarks.Text = string.Empty;

                ddlDistrict.ClearSelection();
                ddlMandal.ClearSelection();
                ddlVillage.ClearSelection();
                ddlProofType.ClearSelection();

                // Set the control default selection value of type DropdownList
                ddlDistrict.Items.FindByValue(Convert.ToString((int)DropDownOption._Select)).Selected = true;
                ddlMandal.Items.FindByValue(Convert.ToString((int)DropDownOption._Select)).Selected = true;
                ddlVillage.Items.FindByValue(Convert.ToString((int)DropDownOption._Select)).Selected = true;
                ddlProofType.Items.FindByValue(Convert.ToString((int)DropDownOption._Select)).Selected = true;
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        #endregion

        #region [ Dictionary Objects ]

        private Dictionary<ITPRO_MasterType, DropDownList> GetDropDownListDictionary()
        {
            Dictionary<ITPRO_MasterType, DropDownList> DictObj = new Dictionary<ITPRO_MasterType, DropDownList>();

            DictObj.Add(ITPRO_MasterType.District, ddlDistrict);
            DictObj.Add(ITPRO_MasterType.ProofType, ddlProofType);

            return DictObj;
        }

        #endregion

    }
}
