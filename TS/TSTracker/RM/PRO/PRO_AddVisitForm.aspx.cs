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

    public partial class PRO_AddVisitForm : System.Web.UI.Page
    {

        #region [ Public Variables/Declarations ]

        ITPROBAL objITPROBAL;
        PROBO objPROBO;
        PROMasterBO objPROMasterBO;
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
                Page.Title = RMConstraints.Page_Title_Main + RMConstraints.WebPage_ITPRO_AddVisitor;
                objITPROBAL = new ITPROBAL();
                if (!IsPostBack)
                {
                    txtVisitDate.Text = DateTime.Now.ToString("MM/dd/yyyy").Replace("-", "/");
                    txtNextCallDate.Text = DateTime.Now.ToString("MM/dd/yyyy").Replace("-", "/");
                    LoadMasters();
                    //GetRequestorEmail();
                }
                txtPrName.Focus();
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
            SaveInstance();
        }


        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearControlValues();
        }

        #endregion

        #region [ Funcions/Methods ]

        private void SaveInstance()
        {
            try
            {
                objPROBO = new PROBO();
                //objPROBO.PrId = txtPrId.Text.Trim();
                //objPROBO.TransId = txtTranId.Text.Trim();
                objPROBO.PrId = "";
                objPROBO.TransId = "";
                objPROBO.VisitorName = txtPrName.Text.Trim();
                objPROBO.FatherName = txtFatherName.Text.Trim();
                objPROBO.DistId = ddlDistrict.SelectedValue;
                objPROBO.MandalId = ddlMandal.SelectedValue;
                objPROBO.VillageId = ddlVillage.SelectedValue;
                objPROBO.ProofTypeId = ddlProofType.SelectedValue;
                objPROBO.ProofId = txtProofId.Text.Trim();
                objPROBO.ContactNo = txtContactNo.Text.Trim();
                objPROBO.VisitDate = Convert.ToDateTime(txtVisitDate.Text.Trim());
                objPROBO.NextCallDate = Convert.ToDateTime(txtNextCallDate.Text.Trim());
                objPROBO.VisitPurpose = txtVisitPurpose.Text.Trim();
                objPROBO.Remarks = txtRemarks.Text.Trim();
                objPROBO.StatusId = 1;
                objPROBO.CreatedBy = SessionVariables.UserID;

                dsContent = objITPROBAL.CheckVisitor(objPROBO);
                if (dsContent.Tables[0].Rows.Count == 0)
                {
                    objITPROBAL.SaveVisitorDtls(objPROBO);
                    //objPROBO = new PROBO();
                    //objPROBO = objITPROBAL.GetVisitorDtls(objPROBO);

                    Feedback.addSuccess("Visitor details inserted successfully!!");
                    ClearControlValues();
                }
                else
                {
                    objITPROBAL.SaveVisitorDtls(objPROBO);
                    ClearControlValues();
                    Feedback.addSuccess("Visitor details already exists and new transaction has been created succesfully!!");
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
                Feedback.addFailure("Failed to Insert Record !");
            }
        }

        private void LoadMasters()
        {
            try
            {
                foreach (KeyValuePair<ITPRO_MasterType, DropDownList> kvp in GetDropDownListDictionary())
                {
                    kvp.Value.Items.Clear();
                    List<PROMasterBO> objITPROMasterBOList = objITPROBAL.GetMaster((int)Enum.Parse(typeof(ITPRO_MasterType), Enum.GetName(typeof(ITPRO_MasterType), kvp.Key)), "", "");
                    if (objITPROMasterBOList.Count > 0)
                    {
                        kvp.Value.DataValueField = RMConstraints.DropDownList_Master_DataValueField;
                        kvp.Value.DataTextField = RMConstraints.DropDownList_Master_DataTextField;
                        kvp.Value.DataSource = objITPROMasterBOList;
                        kvp.Value.DataBind();
                    }
                    BindControls.AddOptionalItem(kvp.Value, DropDownOption._Select);
                }
                // bind the End User Location from where the share will be accessed.
                //dsLocContent = objITStorageBAL.GetNASLocationMst();
                //BindControls.BindDropDown(ddlEULocation, dsLocContent.Tables[0], "Name", "ID", DropDownOption._Select);


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
                txtPrName.Text = string.Empty;
                txtFatherName.Text = string.Empty;
                txtProofId.Text = string.Empty;
                txtContactNo.Text = string.Empty;
                txtVisitDate.Text = DateTime.Now.ToString("MM/dd/yyyy").Replace("-", "/");
                txtNextCallDate.Text = DateTime.Now.ToString("MM/dd/yyyy").Replace("-", "/");
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

                txtPrName.Text = "";
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }


        //private void GetRequestorEmail()
        //{
        //    try
        //    {
        //        objITNASRequestBO = new ITNASRequestBO();
        //        objITNASRequestBO.CreatedBy = SessionVariables.UserID;
        //        objITNASRequestBO = objITStorageBAL.GetNASReqEmail(objITNASRequestBO);

        //        if (objITNASRequestBO.RequestorEmail != "")
        //        {
        //            txtReqEmail.Text = objITNASRequestBO.RequestorEmail;
        //        }
        //        else
        //        {
        //            txtReqEmail.Text = "";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        CommonBAL.SaveException(ex);
        //    }
        //}

        #endregion

        #region [ Dictionary Objects ]

        private Dictionary<ITPRO_MasterType, DropDownList> GetDropDownListDictionary()
        {
            Dictionary<ITPRO_MasterType, DropDownList> DictObj = new Dictionary<ITPRO_MasterType, DropDownList>();

            DictObj.Add(ITPRO_MasterType.District, ddlDistrict);
            DictObj.Add(ITPRO_MasterType.Mandal, ddlMandal);
            DictObj.Add(ITPRO_MasterType.Village, ddlVillage);
            DictObj.Add(ITPRO_MasterType.ProofType, ddlProofType);


            return DictObj;
        }

        #endregion






    }
}
