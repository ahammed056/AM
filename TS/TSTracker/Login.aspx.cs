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
using System.Collections;
using System.DirectoryServices;

namespace TSTracker
{
    public partial class Login1 : System.Web.UI.Page
    {
        #region [ Public Variables/Declarations ]

        MenuBAL objMenuBAL;
        string strUserID = string.Empty;
        string strUserName = string.Empty;
        string strGroupID = string.Empty;
        string strGroupName = string.Empty;
        string strGroupEnumName = string.Empty;
        string strUserEmail = string.Empty;
        string strHostName = string.Empty;
        string strStartDate = string.Empty;
        string strCurDate = string.Empty;
        
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
                Page.Title = RMConstraints.Page_Title_Main + RMConstraints.Page_Title_Default;
                objMenuBAL = new MenuBAL();
                if (!IsPostBack)
                {
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        #endregion

        #region [ Control Events ]

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateRUser();
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

        private void ValidateRUser()
        {
            try
            {
                //string lstrUsername = "";

                string strQuery = "USP_Get_UserDtls '" + txtUsername.Text.Trim() + "','" + txtPassword.Text.Trim() + "'";
                    DataTable dtContent = objMenuBAL.GetDataTable(strQuery);
                    if (dtContent.Rows.Count > 0)
                    {
                        //Setting Session Variables
                        strUserID = txtUsername.Text;
                        strUserName = dtContent.Rows[0]["USER NAME"].ToString();
                        strGroupID = dtContent.Rows[0]["GroupId"].ToString();
                        strGroupName = dtContent.Rows[0]["GroupName"].ToString();
                        strGroupEnumName = dtContent.Rows[0]["GroupName"].ToString();
                        strStartDate = dtContent.Rows[0]["StartDate"].ToString();
                        strCurDate = dtContent.Rows[0]["CurDate"].ToString();
                        strHostName = HttpContext.Current.Request.ServerVariables["remote_addr"].ToString();
                        
                        strQuery = "EXEC USP_Get_PageNames " + strGroupID;
                        DataTable tblPageName = objMenuBAL.GetDataTable(strQuery);
                        ArrayList arrPageName = new ArrayList();
                        foreach (DataRow row in tblPageName.Rows)
                        {
                            arrPageName.Add(row["PageName"]);
                        }
                        GlobalVariables.GlobalPageNames = arrPageName;
                        SessionVariables objSessionVariables = new SessionVariables(strUserID, strUserName, strGroupID, strGroupName, strGroupEnumName, "", strHostName, strStartDate, strCurDate);
                        CommonBAL.SaveUserLoginInfo();
                       // Response.Redirect(RMConstraints.GetGroupsDictionary()[strGroupEnumName], false);

                        if (Convert.ToInt32(strGroupID) == 88)
                        {
                            Response.Redirect(RMConstraints.GetGroupsDictionary()["TSGeneral"], false);
                        }
                        else if (Convert.ToInt32(strGroupID) == 2)
                        {
                            Response.Redirect(RMConstraints.GetGroupsDictionary()["TSManager"], false);
                        }
                        else
                        {
                            Response.Redirect(RMConstraints.GetGroupsDictionary()["Administrator"], false);
                        }
                    }
                else
                {
                    txtUsername.Focus();
                    Feedback.addFailure("Invalid UserName / Password");
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
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtUsername.Focus();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        #endregion

    }
}

