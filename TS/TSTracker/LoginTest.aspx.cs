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
    public partial class Login : System.Web.UI.Page
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
                string lstrUsername = "";

                ////FOR INDCORP
                string strDCPath = "dc=ind,dc=corp,dc=ad";
                string strDomain = "INDCORP";

                lstrUsername = Authenticate(strDomain.Trim(), strDCPath.Trim(), txtUsername.Text.Trim(), txtPassword.Text.Trim());
                if (!string.IsNullOrEmpty(lstrUsername))
                {
                    string strQuery = "USP_Get_UserAuthenticationDetails '" + txtUsername.Text.Trim() + "'";
                    DataTable dtContent = objMenuBAL.GetDataTable(strQuery);
                    if (dtContent.Rows.Count > 0)
                    {
                        //Setting Session Variables
                        strUserID = txtUsername.Text;
                        strUserName = dtContent.Rows[0]["USER NAME"].ToString();
                        strGroupID = dtContent.Rows[0]["Group ID"].ToString();
                        strGroupName = dtContent.Rows[0]["GroupName"].ToString();
                        strGroupEnumName = dtContent.Rows[0]["GroupEnumName"].ToString();
                        strUserEmail = dtContent.Rows[0]["UserEmail"].ToString();
                        strHostName = HttpContext.Current.Request.ServerVariables["remote_addr"].ToString();
                        strStartDate = dtContent.Rows[0]["StartDate"].ToString();
                        strCurDate = dtContent.Rows[0]["CurDate"].ToString();

                        //To avoid unathuorized access to the page
                        strQuery = "EXEC USP_Get_PageNames " + strGroupID;
                        DataTable tblPageName = objMenuBAL.GetDataTable(strQuery);
                        ArrayList arrPageName = new ArrayList();
                        foreach (DataRow row in tblPageName.Rows)
                        {
                            arrPageName.Add(row["PageName"]);
                        }
                        GlobalVariables.GlobalPageNames = arrPageName;
                        SessionVariables objSessionVariables = new SessionVariables(strUserID, strUserName, strGroupID, strGroupName, strGroupEnumName, strUserEmail, strHostName, strStartDate, strCurDate);
                        CommonBAL.SaveUserLoginInfo();
                        Response.Redirect(RMConstraints.GetGroupsDictionary()[strGroupEnumName], false);
                    }
                    else
                    {

                        strQuery = "USP_Get_LDSUserDetails '" + txtUsername.Text.Trim() + "'";
                        DataTable dtLDSContent = objMenuBAL.GetDataTable(strQuery);
                        if (dtLDSContent.Rows.Count > 0)
                        {
                            strUserName = dtLDSContent.Rows[0]["USER NAME"].ToString();
                            strUserEmail = dtLDSContent.Rows[0]["UserEmail"].ToString();
                        }
                        else
                        {
                            strUserName = txtUsername.Text;
                            strUserEmail =  string.Empty;
                        }

                        //***** When User logged in as requestor without having Group Name
                        //Setting Session Variables
                        strUserID = txtUsername.Text;
                        strGroupID = "84";
                        strGroupName = "Requestor";
                        strGroupEnumName = "ReadOnly";
                        strHostName = HttpContext.Current.Request.ServerVariables["remote_addr"].ToString();
                        strStartDate = dtContent.Rows[0]["StartDate"].ToString();
                        //To avoid unathuorized access to the page
                        strQuery = "EXEC USP_Get_PageNames " + strGroupID;
                        DataTable tblPageName = objMenuBAL.GetDataTable(strQuery);
                        ArrayList arrPageName = new ArrayList();
                        foreach (DataRow row in tblPageName.Rows)
                        {
                            arrPageName.Add(row["PageName"]);
                        }
                        GlobalVariables.GlobalPageNames = arrPageName;
                        SessionVariables objSessionVariables = new SessionVariables(strUserID, strUserName, strGroupID, strGroupName, strGroupEnumName, strUserEmail, strHostName, strStartDate, strCurDate);
                        CommonBAL.SaveUserLoginInfo();
                        Response.Redirect(RMConstraints.GetGroupsDictionary()[strGroupEnumName], false);
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

        private string Authenticate(string lsDomain, string lsDN, string lsUser, string lsPwd)
        {
            string lsResult = string.Empty;
            try
            {
                DirectoryEntry loDE = null;
                loDE = new DirectoryEntry("LDAP://" + lsDomain + "/" + lsDN, lsDomain + "\\" + lsUser, lsPwd);
                if (!string.IsNullOrEmpty(loDE.Name))
                {
                    lsResult = loDE.Name;
                    string[] lsaPPTY = new string[2];
                    lsaPPTY[0] = "DisplayName";
                    lsaPPTY[1] = "Name";
                    DirectorySearcher loDES = new DirectorySearcher(loDE, "(&(objectcategory=user)(SamAccountName=" + lsUser + "))", lsaPPTY, SearchScope.Subtree);

                    SearchResult loSrchRslt = loDES.FindOne();
                    lsResult = loSrchRslt.Properties["DisplayName"][0].ToString();
                }
            }
            catch (Exception)
            {
                lsResult = string.Empty;
            }
            return lsResult;
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
