using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSBAL;
using TSEntity;
using TSUtility;
using System.Collections;
using System.Drawing;

namespace TSTracker.RM.PRO
{
    public partial class PRO_VisitMgmt : System.Web.UI.Page
    {

        #region [ Public Variables/Declarations ]

        ITPROBAL objITPROBAL;
        PROBO objPROBO;

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
                Page.Title = RMConstraints.Page_Title_Main + RMConstraints.WebPage_ITPRO_Home;
                objITPROBAL = new ITPROBAL();
                if (!IsPostBack)
                {
                    BindVisitDtls();
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        #endregion
        
        #region [ Control Events ]

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BindVisitDtls();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        //protected void ImgSearch_Click(object sender, ImageClickEventArgs e)
        //{
        //    try
        //    {
        //        BindVisitDtls();
        //    }
        //    catch (Exception ex)
        //    {
        //        CommonBAL.SaveException(ex);
        //    }
        //}

        #endregion

        #region [ Funcions/Methods ]

        private void BindVisitDtls()
        {
            try
            {
                objPROBO = new PROBO();

                List<PROBO> objPROBOList = objITPROBAL.GetPendingVisitDtls(txtSearchVal.Text.Trim());
                gvVisitDtls.DataSource = objPROBOList;
                gvVisitDtls.DataBind();
                if (objPROBOList.Count > 0)
                {
                    lblRecords.Text = "Total Records : " + objPROBOList.Count;
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
              
        #endregion

      

        #region [ Edit and Update ]


        #endregion

    }
}
