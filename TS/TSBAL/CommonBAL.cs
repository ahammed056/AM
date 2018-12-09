using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSDAL;
using TSEntity;
using TSUtility;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TSBAL
{
    public class CommonBAL
    {

        #region [ Public Variables/Declarations ]

        CommonDAL objcommonDAL;

        #endregion

        #region [ Contructors ]

        public CommonBAL()
        {
            objcommonDAL = new CommonDAL();
        }

        #endregion

        #region [ Methods ]

        #region [ Exception ]

        /// <summary>
        /// Save records into database
        /// </summary>
        /// <param name="objITDBABO"></param>
        /// <returns></returns>
        public static void SaveException(Exception exception)
        {
            try
            {
                CommonDAL.SaveException(exception);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region [ User Login Info ]

        /// <summary>
        /// Save records into database
        /// </summary>
        /// <param name="objITDBABO"></param>
        /// <returns></returns>
        public static void SaveUserLoginInfo()
        {
            try
            {
                CommonDAL.SaveUserLoginInfo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Save records into database
        /// </summary>
        /// <param name="objITDBABO"></param>
        /// <returns></returns>
        public static void UpdateUserLoginInfo()
        {
            try
            {
                CommonDAL.UpdateUserLoginInfo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// [ Description : To get the user role ]
        /// [ Author : Bhanu Teja ]
        /// [ Created date : 15-Apr-2014 ]  
        /// </summary>
        /// <param name="GroupID"></param>
        /// <param name="GroupName"></param>
        /// <returns></returns>
        //public static ITDAPsRequest_UserRole GetPresentUserRole(string GroupID, string GroupName)
        //{
        //    if (GroupName.ToLower().Contains("daps"))
        //    {
        //        if (GroupName.ToLower().Contains("admin"))
        //        {
        //            return ITDAPsRequest_UserRole.DAPS_Admin;
        //        }
        //        if (GroupName.ToLower().Contains("l1") || GroupName.ToLower().Contains("team"))
        //        {
        //            return ITDAPsRequest_UserRole.DAPS_Team;
        //        }
        //        if (GroupName.ToLower().Contains("l2") || GroupName.ToLower().Contains("sme"))
        //        {
        //            return ITDAPsRequest_UserRole.DAPS_SME;
        //        }
        //    }
        //    return ITDAPsRequest_UserRole.Requestor;
        //}

        /// <summary>
        /// Get all records from database
        /// </summary>
        /// <returns></returns>
        public DataSet GetCMDBInstancesByModule(string Module, string IPAddress, string Hostname)
        {
            try
            {
                return objcommonDAL.GetCMDBInstancesByModule(Module, IPAddress, Hostname);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // <summary>
        //  Author      : <Bhanuprakash>
        //  Create date : <20-April-2012> 
        //  Description : <Generate Table & FieldSet>
        //  Input       : <DataSet,String>
        //  Output      : <Table>
        // </summary>
        public Table GenerateDashboard(DataSet dsCotent)
        {
            // Create the Table and Add it to the Page
            Table objTable = new Table();
            TableRow objTableRow = new TableRow();
            TableCell objTableCell = new TableCell();
            int iCount = 0;
            try
            {
                objTable.ID = "tblInstance";
                objTable.CellPadding = 0;
                objTable.CellSpacing = 0;
                objTableRow = new TableRow();
                objTableCell = new TableCell();

                iCount = dsCotent.Tables.Count;
                // Now iterate through the table and add your controls 
                foreach (DataTable dtContent in dsCotent.Tables)
                {
                    if (iCount > 1)
                    {
                        // Create HtmlGenericControl span tag
                        HtmlGenericControl spanMessage = new HtmlGenericControl("span");
                        spanMessage.InnerHtml = "<left>" + dtContent.TableName + "</left>";
                        spanMessage.Attributes.Add("class", "spanStyle");
                        // Add the span to the div
                        objTableCell.Controls.Add(spanMessage);
                    }

                    // Add the control to the div
                    objTableCell.Controls.Add(BindDashboardData(dtContent));

                    // Add the TableCell to the TableRow
                    objTableRow.Cells.Add(objTableCell);
                    // Add the TableRow to the Parent Table
                    objTable.Rows.Add(objTableRow);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objTable;
        }

        // <summary>
        //  Author      : <Bhanuprakash>
        //  Create date : <20-April-2012> 
        //  Description : <Generate Dashboard Data based on the input parameters>
        //  Input       : <DataTable,String>
        //  Output      : <GridView>
        // </summary>
        private GridView BindDashboardData(DataTable dtContent)
        {
            GridView gdvCommon = new GridView();
            try
            {
                gdvCommon.CssClass = "GridViewStyle";
                gdvCommon.RowStyle.CssClass = "RowStyle_lowheight";
                gdvCommon.RowStyle.HorizontalAlign = HorizontalAlign.Left;
                gdvCommon.FooterStyle.CssClass = "FooterStyle";
                gdvCommon.EmptyDataRowStyle.CssClass = "EmptyRowStyle";
                gdvCommon.PagerStyle.CssClass = "PagerStyle";
                gdvCommon.SelectedRowStyle.CssClass = "SelectedRowStyle";
                gdvCommon.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                gdvCommon.HeaderStyle.CssClass = "subHeaderRow";
                gdvCommon.EditRowStyle.CssClass = "EditRowStyle";
                gdvCommon.AlternatingRowStyle.CssClass = "AltRowStyle_lowheight";
                gdvCommon.RowStyle.HorizontalAlign = HorizontalAlign.Left;
                gdvCommon.EmptyDataText = "No Records Found";
                gdvCommon.DataSource = dtContent;
                gdvCommon.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return gdvCommon;
        }

        #endregion

        #endregion

    }
}
