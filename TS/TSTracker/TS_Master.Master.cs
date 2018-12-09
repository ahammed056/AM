using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using TSBAL;
using TSEntity;
using TSUtility;
using System.Web.Services;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.IO;
using System.Text;

namespace TSTracker
{
    public partial class TS_Master : System.Web.UI.MasterPage
    {

        #region [ Public Variables/Declarations ]

        MenuBAL objMenuBAL;

        #endregion

        #region [ Page Events ]

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (SessionVariables.UserID != string.Empty)
                {
                    objMenuBAL = new MenuBAL();
                    if (!IsPostBack)
                    {
                        lblDisplayName.Text = "Welcome " + SessionVariables.UserName;
                        LoadMenu();
                    }
                }
                else
                {
                    Response.Redirect(RMConstraints.WebPage_Login, false);
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        #endregion

        #region [ Funcions/Methods ]

        private void LoadMenu()
        {
            try
            {
                divMenu.InnerHtml = ExecuteXSLTransformation();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        private string ExecuteXSLTransformation()
        {
            string HtmlTags, XsltPath;
            MemoryStream DataStream = default(MemoryStream);
            StreamReader streamReader = default(StreamReader);
            try
            {
                //Path of XSLT file             
                XsltPath = HttpContext.Current.Server.MapPath("../Menu/TransformXSLT.xsl");
                //Encode all Xml format string to bytes             
                byte[] bytes = Encoding.ASCII.GetBytes(GenerateXmlFormat());
                DataStream = new MemoryStream(bytes);
                //Create Xmlreader from memory stream               
                XmlReader reader = XmlReader.Create(DataStream);
                // Load the XML             
                XPathDocument document = new XPathDocument(reader);
                XslCompiledTransform XsltFormat = new XslCompiledTransform();
                // Load the style sheet.             
                XsltFormat.Load(XsltPath);
                DataStream = new MemoryStream();
                XmlTextWriter writer = new XmlTextWriter(DataStream, Encoding.ASCII);
                //Apply transformation from xml format to html format and save it in xmltextwriter             
                XsltFormat.Transform(document, writer);
                streamReader = new StreamReader(DataStream);
                DataStream.Position = 0;
                HtmlTags = streamReader.ReadToEnd();
                return HtmlTags;
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
                return string.Empty;
            }
            finally
            {
                //Release the resources               
                streamReader.Close();
                DataStream.Close();
            }
        }

        private string GenerateXmlFormat()
        {
            try
            {
                DataSet DbMenu;
                DataRelation relation;
                string sql = "USP_GET_MENU_LIST " + SessionVariables.GroupID;
                DbMenu = objMenuBAL.GetDataSet(sql);
                DbMenu.DataSetName = "Menus";
                DbMenu.Tables[0].TableName = "Menu";
                //create Relation Parent and Child     
                relation = new DataRelation("ParentChild", DbMenu.Tables["Menu"].Columns["menumstid"], DbMenu.Tables["Menu"].Columns["menuparentid"], true);
                relation.Nested = true;
                DbMenu.Relations.Add(relation);
                return DbMenu.GetXml();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
                return string.Empty;
            }
        }

        #endregion

        #region [ Link Button Events ]
        

        //protected void lnkLogout_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Response.Redirect(RMConstraints.WebPage_Logout, false);
        //    }
        //    catch (Exception ex)
        //    {
        //        CommonBAL.SaveException(ex);
        //    }
        //}

        protected void lnkPwdReset_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(RMConstraints.WebPage_ResetPwd, false);
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }
       #endregion

    }
}
