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
    public partial class _Default : System.Web.UI.Page
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
            //#######################################################################################################################
            // SSO (Single Sign On) will redirects the URL to  Path
            // i.e. default.aspx. From this page we need to read the SSO header.
            // If the OHRID is authenticated within SSO Database, then only it will redirect the page to above URL.
            //#######################################################################################################################
            try
            {
                Page.Title = RMConstraints.Page_Title_Main + RMConstraints.Page_Title_Default;
                objMenuBAL = new MenuBAL();
                if (!IsPostBack)
                {
                    try
                    {
                        //For getting the UserID from SSO
                        //strUserID = Request.Headers["SM_USER"].ToString();
                        //strUserID = "800045227";
                        //strUserID = "800046833";
                    }
                    catch (Exception ex)
                    {
                        CommonBAL.SaveException(ex);
                        //Feedback.addFailure("Error while reading SSO Header");
                    }
                    try
                    {
                        if (!(strUserID == null) && !(strUserID == string.Empty))
                        {
                            //To Load the User details from Database
                            LoadUserDetails(strUserID.Trim());
                        }
                    }
                    catch (Exception ex)
                    {
                        CommonBAL.SaveException(ex);
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



        #endregion

        #region [ Funcions/Methods ]

        private void LoadUserDetails(string strUserID)
        {
            try
            {
                string strQuery = "USP_Get_UserAuthenticationDetails '" + strUserID + "'";
                DataTable dtContent = objMenuBAL.GetDataTable(strQuery);
                if (dtContent.Rows.Count > 0)
                {
                    //Setting Session Variables
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

                    //SessionVariables objSessionVariables = new SessionVariables(strUserID, strUserName, strGroupID, strGroupName, strUserEmail, strHostName);
                    SessionVariables objSessionVariables = new SessionVariables(strUserID, strUserName, strGroupID, strGroupName, strGroupEnumName, strUserEmail, strHostName, strStartDate, strCurDate);
                    CommonBAL.SaveUserLoginInfo();
                    //Response.Redirect(RMConstraints.WebPage_ITOperational_Index, false);
                    //Response.Redirect(RMConstraints.WebPage_ITStorage_Index, false);
                    Response.Redirect(RMConstraints.GetGroupsDictionary()[strGroupEnumName], false);
                }
                else
                {
                    strQuery = "USP_Get_LDSUserDetails '" + strUserID + "'";
                    DataTable dtLDSContent = objMenuBAL.GetDataTable(strQuery);
                    if (dtLDSContent.Rows.Count > 0)
                    {
                        strUserName = dtLDSContent.Rows[0]["USER NAME"].ToString();
                        strUserEmail = dtLDSContent.Rows[0]["UserEmail"].ToString();
                    }
                    else
                    {
                        strUserName = strUserID;
                        strUserEmail = string.Empty;
                    }

                    //***** When User logged in as requestor without having Group Name
                    //Setting Session Variables
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
                    //Response.Redirect(RMConstraints.GetGroupsDictionary()[strGroupEnumName], false);
                    Response.Redirect(RMConstraints.GetGroupsDictionary()[strGroupEnumName], false);
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        #endregion

    }
}
