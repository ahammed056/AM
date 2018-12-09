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
using System.Collections;
using System.Drawing;
using System.Globalization;

namespace TSTracker.RM.TS
{
    public partial class TS_Mgmt : System.Web.UI.Page
    {
        #region [ Public Variables/Declarations ]

        ITTSBAL objITTSBAL;
        TSMasterBO objTSMasterBO;
        TSBO objTSBO;
        DataSet dsContent;
        Mailer objMailer;
        string TSId = string.Empty;
        //private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");


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
                Page.Title = RMConstraints.Page_Title_Main + RMConstraints.WebPage_ITTS_Management;
                objITTSBAL = new ITTSBAL();
                objMailer = new Mailer();
                if (!IsPostBack)
                {
                    LoadMasters();
                    ddlTask.Focus();
                    BindEmpDtls();
                    txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy").Replace("-","/");
                    //txtDate.Text = DateTime.Now.ToString("MM/dd/yyyy").Replace("-", "/");
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        #endregion

        #region [ Control Events ]

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnTSId.Value == "")
                {
                    SaveEmpEfforts();
                }
                else
                {
                    UpdateEmpEfforts();
                    hdnTSId.Value = "";
                }
                BindEmpDtls();
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
                BindEmpDtls();
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
                //DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                ImageButton imgbtnEdit = (ImageButton)gvMaster.Rows[e.NewEditIndex].FindControl("imgbtnEdit");
                hdnTSId.Value = imgbtnEdit.CommandArgument;

                //gvMaster.EditIndex = e.NewEditIndex;
                //string strTSId = gvMaster
                string strdate = gvMaster.Rows[e.NewEditIndex].Cells[2].Text;
                string strTask = gvMaster.Rows[e.NewEditIndex].Cells[4].Text;
                string strApp = gvMaster.Rows[e.NewEditIndex].Cells[6].Text;
                string strdesc = gvMaster.Rows[e.NewEditIndex].Cells[7].Text;
                string strTSHrs = gvMaster.Rows[e.NewEditIndex].Cells[8].Text;

                ddlTask.ClearSelection();
                ddlApp.ClearSelection();
                ddlTask.Items.FindByText(strTask).Selected = true;
                ddlApp.Items.FindByText(strApp).Selected = true;

                //txtDate.Text = Convert.ToDateTime(strdate).ToString("MM/dd/yyyy");
                //txtDate.Text = DateTime.ParseExact(txtDate.Text.Trim(), "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                //txtDate.Text = DateTime.ParseExact(strdate, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString();

                //txtDate.Text = strdate;
                //txtDate.Text = Convert.ToDateTime(strdate).ToString("dd/MM/yyyy");

                //string[] dateString = strdate.Split('/');
                //DateTime enter_date = Convert.ToDateTime(dateString[1] + "/" + dateString[0] + "/" + dateString[2]);
                //txtDate.Text = enter_date.ToString("dd/MM/yyyy");
                //txtDate.Text = txtDate.Text.Replace("-", "/");
                
                //txtDate.Text = DateTime.Parse(strdate, new CultureInfo("en-US")).ToString("dd/MM/yyyy");
                //txtDate.Text = Convert.ToDateTime(strdate).ToString("MM/dd/yyyy");
                txtDate.Text = strdate.Replace("-","/");
                txtDesc.Text = strdesc;
                txtTime.Text = strTSHrs;

                //BindEmpDtls();
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
                BindEmpDtls();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }
        #endregion

        #region [ Funcions/Methods ]


        private void SaveEmpEfforts()
        {
            try
            {
                objTSBO = new TSBO();

                objTSBO.EmpId = SessionVariables.UserID;
                objTSBO.EmpName = SessionVariables.UserName;
                objTSBO.TaskId = ddlTask.SelectedValue;
                objTSBO.ApplicationId = ddlApp.SelectedValue;
                objTSBO.Description = txtDesc.Text.Trim().Replace("'","");
                //objTSBO.TSDate = DateTime.ParseExact(txtDate.Text.Trim(), "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                //objTSBO.TSDate = Convert.ToDateTime(Convert.ToDateTime(txtDate.Text.Trim()).ToString("dd/MM/yyyy"));
                //objTSBO.TSDate = DateTime.ParseExact(txtDate.Text.Trim(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                //en-IA
                //string strDate = txtDate.Text.Trim();
                //string[] dateString = strDate.Split('/');
                //DateTime enter_date = Convert.ToDateTime(dateString[1] + "/" + dateString[0] + "/" + dateString[2]);
                ////objTSBO.TSDate = enter_date;
                //objTSBO.TSDate = enter_date;

                //txtDate.Text = Convert.ToDateTime(txtDate.Text.Replace("-","/")).ToString("dd/MM/yyyy");
                //objTSBO.TSDate = DateTime.Parse(Convert.ToDateTime(txtDate.Text.Replace("-","/")).ToString("dd/MM/yyyy"));

                //objTSBO.TSDate = DateTime.Parse(txtDate.Text);
                objTSBO.TSDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                
                objTSBO.TSHrs = txtTime.Text.Trim();
                objTSBO.CreatedBy = SessionVariables.UserID;
                //objTSBO.CurrDate = Convert.ToDateTime(Convert.ToDateTime(SessionVariables.CurDate).ToString("MM/dd/yyyy"));
                //objTSBO.StartDate = Convert.ToDateTime(Convert.ToDateTime(SessionVariables.StartDate).ToString("MM/dd/yyyy"));

                objTSBO.CurrDate = Convert.ToDateTime(SessionVariables.CurDate);
                objTSBO.StartDate = Convert.ToDateTime(SessionVariables.StartDate);

                if (objTSBO.TSDate > objTSBO.CurrDate)
                {
                    Feedback.addFailure("Please check the date, feature efforts will not be allowed!!");
                }
                else if (objTSBO.TSDate < objTSBO.StartDate)
                {
                    Feedback.addFailure("Please check the date, time sheet entry started from " + SessionVariables.StartDate + "!!");
                }
                else
                {
                    
                    ////TimeSpan ts = objTSBO.TSDate-objTSBO.CurrDate;
                    //////if (objTSBO.TSDate.ToString("dd/MM/yyyy").Equals(objTSBO.CurrDate.AddDays(-1).ToString("dd/MM/yyyy")))   
                    ////if (Math.Abs(ts.Days) == 1)
                    ////{
                    ////    objITTSBAL.SaveEmpEffDtls(objTSBO);
                    ////    Feedback.addSuccess("Data has been submitted successfully!!");
                    ////    ClearControlValues();
                    ////}
                    ////////if (Math.Abs(ts.Days) == 2 && DateTime.Now.DayOfWeek.ToString() == "Monday")
                    ////////{
                    ////////    objITTSBAL.SaveEmpEffDtls(objTSBO);
                    ////////    Feedback.addSuccess("Data has been submitted successfully!!");
                    ////////    ClearControlValues();
                    ////////}
                    ////else if (ts.Days == 0)
                    ////{
                    ////    //if (DateTime.Now.DayOfWeek.ToString() == "Monday")
                    ////    //{
                    ////    //    objTSBO.TSFlag = 2;
                    ////    //}
                    ////    TimeSpan tsInit = objTSBO.TSDate - objTSBO.StartDate;
                    ////    if (tsInit.Days == 0)
                    ////    {
                    ////        objITTSBAL.SaveEmpEffDtls(objTSBO);
                    ////        Feedback.addSuccess("Data has been submitted successfully!!");
                    ////        ClearControlValues();
                    ////    }
                    ////    else
                    ////    {
                    ////        dsContent = objITTSBAL.CheckEmpEffDtls(objTSBO);
                    ////        if (dsContent.Tables[0].Rows.Count == 0)
                    ////        {
                    ////            Feedback.addFailure("Please check and fill the data for previous working day!!");
                    ////            ddlTask.Focus();
                    ////        }
                    ////        else
                    ////        {
                    ////            objITTSBAL.SaveEmpEffDtls(objTSBO);
                    ////            Feedback.addSuccess("Data has been submitted successfully!!");
                    ////            ClearControlValues();
                    ////        }
                    ////    }
                    ////}
                    ////else
                    ////{
                    ////    Feedback.addFailure("Please check the date, system will not allow to enter the data for lessthan oneday!!");
                    ////    ddlTask.Focus();
                    ////}

                    objITTSBAL.SaveEmpEffDtls(objTSBO);
                    Feedback.addSuccess("Data has been submitted successfully!!");
                    ClearControlValues();

                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
                Feedback.addFailure("Failed to Insert Record !");
            }
        }

        private void UpdateEmpEfforts()
        {
            try
            {
                objTSBO = new TSBO();

                objTSBO.TSId = hdnTSId.Value;
                objTSBO.TaskId = ddlTask.SelectedValue;
                objTSBO.ApplicationId = ddlApp.SelectedValue;
                objTSBO.Description = txtDesc.Text.Trim();
                //objTSBO.TSDate = DateTime.ParseExact(txtDate.Text.Trim(), "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                //objTSBO.TSDate = Convert.ToDateTime(Convert.ToDateTime(txtDate.Text.Trim()).ToString("dd/MM/yyyy"));
                //objTSBO.TSDate = DateTime.Parse(txtDate.Text.Replace("-", "/"));

                //objTSBO.TSDate = DateTime.Parse(txtDate.Text);
                objTSBO.TSDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                objTSBO.TSHrs = txtTime.Text.Trim();
                objTSBO.ModifiedBy = SessionVariables.UserID;

                objITTSBAL.UpdateEmpEffDtls(objTSBO);
                Feedback.addSuccess("Record has been updated successfully.");
                ClearControlValues();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
                Feedback.addFailure("Failed to Update Record !");
            }
        }

        private void BindEmpDtls()
        {
            try
            {
                objTSBO = new TSBO();
                objTSBO.EmpId = SessionVariables.UserID;

                List<TSBO> objTSBOList = objITTSBAL.GetAllEmpEfforts(objTSBO.EmpId);
                gvMaster.DataSource = objTSBOList;
                gvMaster.DataBind();
                if (objTSBOList.Count > 0)
                {
                    //GroupGridView(gvMaster.Rows, 1, 2);
                    lblRecords.Text = "Total Records : " + objTSBOList.Count;
                }
                else
                {
                    lblRecords.Text = "No Records Found";
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        //private void GroupGridView(GridViewRowCollection gvrc, int startIndex, int total)
        //{
        //    if (total == 0)
        //    {
        //        return;
        //    }
        //    int i = 0;
        //    int count = 1;
        //    //Array lst = new Array();
        //    ArrayList lst = new ArrayList();
        //    lst.Add(gvrc[0]);
        //    TableCell ctrl = gvrc[0].Cells[startIndex];
        //    for (i = 1; i <= gvrc.Count - 1; i++)
        //    {
        //        TableCell nextCell = gvrc[i].Cells[startIndex];
        //        if (ctrl.Text == nextCell.Text)
        //        {
        //            count += 1;
        //            nextCell.Visible = false;
        //            lst.Add(gvrc[i]);
        //        }
        //        else
        //        {
        //            if (count > 1)
        //            {
        //                ctrl.RowSpan = count;
        //                GroupGridView(new GridViewRowCollection(lst), startIndex + 1, total - 1);
        //            }
        //            count = 1;
        //            lst.Clear();
        //            ctrl = gvrc[i].Cells[startIndex];
        //            lst.Add(gvrc[i]);
        //        }
        //    }
        //    if (count > 1)
        //    {
        //        ctrl.RowSpan = count;
        //        GroupGridView(new GridViewRowCollection(lst), startIndex + 1, total - 1);
        //    }
        //    count = 1;
        //    lst.Clear();
        //}

        private void LoadMasters()
        {
            try
            {
                foreach (KeyValuePair<ITTS_MasterType, DropDownList> kvp in GetDropDownListDictionary())
                {
                    kvp.Value.Items.Clear();
                    List<TSMasterBO> objTSMasterBOList = objITTSBAL.GetMaster((int)Enum.Parse(typeof(ITTS_MasterType), Enum.GetName(typeof(ITTS_MasterType), kvp.Key)));
                    if (objTSMasterBOList.Count > 0)
                    {
                        kvp.Value.DataValueField = RMConstraints.DropDownList_Master_DataValueField;
                        kvp.Value.DataTextField = RMConstraints.DropDownList_Master_DataTextField;
                        kvp.Value.DataSource = objTSMasterBOList;
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

        private void ClearControlValues()
        {
            try
            {
                // Clear the control value of type TextBox
                ddlTask.ClearSelection(); ;
                ddlApp.ClearSelection();
                txtDesc.Text = string.Empty;
                //txtDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy").Replace("-", "/");
                txtTime.Text = string.Empty;

                ddlTask.Focus();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        #endregion

        #region [ Dictionary Objects ]

        private Dictionary<ITTS_MasterType, DropDownList> GetDropDownListDictionary()
        {
            Dictionary<ITTS_MasterType, DropDownList> DictObj = new Dictionary<ITTS_MasterType, DropDownList>();
            DictObj.Add(ITTS_MasterType.Task, ddlTask);
            DictObj.Add(ITTS_MasterType.Application, ddlApp);
            return DictObj;
        }

        #endregion
    }
}
