using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSBAL;
using TSEntity;
using TSUtility;

namespace TSTracker
{
    public partial class Logout : System.Web.UI.Page
    {

        #region [ Public Variables/Declarations ]



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
                Page.Title = RMConstraints.Page_Title_Main + RMConstraints.Page_Title_Logout;
                if (!IsPostBack)
                {
                    Session.Abandon();
                    //Response.Write("<script>window.opener='X';window.open('','_self',''); self.close();</script>");
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

        

        #endregion

    }
}
