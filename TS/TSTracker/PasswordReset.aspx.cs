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
    public partial class PasswordReset : System.Web.UI.Page
    {

        #region [ Public Variables/Declarations ]

        MenuBAL objMenuBAL;
        string strUserID = string.Empty;

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
                    txtNewPwd.Focus();
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
                if (txtNewPwd.Text.Trim() == txtConfirmPwd.Text.Trim())
                {
                    objMenuBAL.UpdateEmpPwd(txtConfirmPwd.Text.Trim(), SessionVariables.UserID);
                    trNewfPwd.Visible = false;
                    trConfPwd.Visible = false;
                    trLoginlnk.Visible = true;
                    trbuttons.Visible = false;
                }
                else
                {
                    txtNewPwd.Focus();
                    Feedback.addFailure("Password mismatch, please check the new Password!!");
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
                txtNewPwd.Text = string.Empty;
                txtConfirmPwd.Text = string.Empty;
                txtNewPwd.Focus();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        #endregion

    }
}
