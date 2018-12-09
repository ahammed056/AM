using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSBAL;
using System.Data;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.IO;
using System.Text;
using System.Web.Services;

namespace TSTracker.RM.Menu
{
    public partial class Menu_WebService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region [ Functions ]

        #region [ Get Menu Items ]

        [WebMethod]
        public static string GetMenuItems()
        {
            try
            {
                MenuBAL objMenuBAL = new MenuBAL();
                DataSet loDataSet = new DataSet();
                string lsSqlQuery;
                lsSqlQuery = "USP_GET_MENU_LIST '" + HttpContext.Current.Session["GroupID"].ToString() + "'";
                loDataSet = objMenuBAL.GetDataSet(lsSqlQuery);
                if (loDataSet.Tables[0].Rows.Count > 0)
                {
                    loDataSet.DataSetName = "Menus";
                    loDataSet.Tables[0].TableName = "Menu";

                    DataRelation relation = new DataRelation("ParentChild", loDataSet.Tables["Menu"].Columns["menumstid"], loDataSet.Tables["Menu"].Columns["menuparentid"], true);

                    relation.Nested = true;
                    loDataSet.Relations.Add(relation);
                    loDataSet.WriteXml(HttpContext.Current.Server.MapPath("../Menu/Menu.xml"));

                    //load the Xml doc
                    XPathDocument myXPathDoc = new XPathDocument(HttpContext.Current.Server.MapPath("../Menu/Menu.xml"));
                    XslTransform myXslTrans = new XslTransform();

                    //load the Xsl 
                    myXslTrans.Load(HttpContext.Current.Server.MapPath("../Menu/Menu.xslt"));

                    //create the output stream
                    XmlTextWriter myWriter = new XmlTextWriter
                        (HttpContext.Current.Server.MapPath("Tree_Menu.html"), null);

                    //do the actual transform of Xml
                    myXslTrans.Transform(myXPathDoc, null, myWriter);

                    myWriter.Close();

                    using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("../Menu/Menu.html"), Encoding.Default))
                    {
                        return reader.ReadToEnd();
                    }
                }
                else
                {
                    return "Empty";
                }
            }
            catch (Exception)
            {
                return "Empty"; //ex.Message.ToString() + ex.StackTrace.ToString();
            }
        }

        #endregion

        #endregion

    }
}
