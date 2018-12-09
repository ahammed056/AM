using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using TSUtility;
using TSBAL;

namespace TSTracker.RM.Help
{
    public partial class Help_Index : System.Web.UI.Page
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
                Page.Title = RMConstraints.Page_Title_Main + RMConstraints.Page_Title_Help_Home;
                if (!IsPostBack)
                {
                    //DownloadHelpDocument();
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        #endregion

        #region [ Funcions/Methods ]

        private void DownloadHelpDocument()
        {
            try
            {
                string strFilePath = Server.MapPath("~/Common/Documents/CDR_HelpDocument.pdf");
                if (File.Exists(strFilePath))
                {
                    byte[] btContent = File.ReadAllBytes(strFilePath);
                    Response.Clear();
                    Response.ClearHeaders();
                    Response.AddHeader("Content-Type", "Application/pdf");
                    Response.AddHeader("Content-Length", btContent.Length.ToString());
                    Response.AddHeader("Content-Disposition", "attachment;   filename=" + "CDR_Help_Document.pdf");
                    Response.BinaryWrite(btContent);
                    Response.Flush();
                    Response.End();
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
