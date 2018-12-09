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
    public class ITTSBAL
    {

        #region [ Public Variables/Declarations ]

        ITTSDAL objITTSDAL;

        #endregion

        #region [ Contructors ]

        public ITTSBAL()
        {
            objITTSDAL = new ITTSDAL();
        }

        #endregion

        #region [ Methods ]

        #region [ TSRecords ]

        /// <summary>
        /// Save records into database
        /// </summary>
        /// <param name="objTSBO"></param>
        /// <returns></returns>
        public int SaveEmpEffDtls(TSBO objTSBO)
        {
            try
            {
                return objITTSDAL.SaveEmpEffDtls(objTSBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update records into database
        /// </summary>
        /// <param name="objTSBO"></param>
        /// <returns></returns>
        public int UpdateEmpEffDtls(TSBO objTSBO)
        {
            try
            {
                return objITTSDAL.UpdateEmpEffDtls(objTSBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
        /// <summary>
        /// Check record in database
        /// </summary>
        /// <param name="objTSBO"></param>
        /// <returns></returns>
        public DataSet CheckEmpEffDtls(TSBO objTSBO)
        {
            try
            {
                return objITTSDAL.CheckEmpEffDtls(objTSBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        /// <summary>
        /// Get all records from database
        /// </summary>
        /// <param name="objTSBO"></param>
        /// <returns></returns>
        public TSBO GetEmpEfftDtls(TSBO objTSBO)
        {
            try
            {
                return objITTSDAL.GetEmpEfftDtls(objTSBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

     

        /// <summary>
        /// Get all records from database
        /// </summary>
        /// <returns></returns>
        public List<TSBO> GetAllEmpEfforts(string SearchVal)
        {
            try
            {
                return objITTSDAL.GetAllEmpEfforts(SearchVal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all records from database
        /// </summary>
        /// <returns></returns>
        public List<TSBO> GetFilteredEmpDtls(TSBO objTSBO)
        {
            try
            {
                return objITTSDAL.GetFilteredEmpDtls(objTSBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TSBO> GetTSRecords(ITTSSearchCriteria objSearch)
        {
            try
            {
                return objITTSDAL.GetTSRecords(objSearch);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetTSRptExprt(ITTSSearchCriteria objSearch)
        {
            try
            {
                return objITTSDAL.GetTSRptExprt(objSearch);
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
        public Table GenerateDashboard(DataSet dsCotent, Dictionary<int, string> DictHelp)
        {
            // Create the Table and Add it to the Page
            Table parenttable = new Table();
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            int iCount = 0;
            bool iStatus = false;
            try
            {
                parenttable.ID = "tblITDAPS";
                // Now iterate through the table and add your controls 
                foreach (DataTable dtContent in dsCotent.Tables)
                {
                    if (iCount == 0)
                    {
                        iStatus = true;
                    }
                    else if (dtContent.Rows.Count > 0)
                    {
                        iStatus = true;
                    }
                    else
                    {
                        iStatus = false;
                    }
                    if (iStatus == true)
                    {
                        // Create the fieldset/panel and Add it to the TableCell
                        Panel myFieldSet = new Panel();
                        // Create the Table and Add it to the fieldset/panel
                        Table childtable = new Table();
                        myFieldSet.GroupingText = dtContent.TableName;
                        // Create the div and Add it to the fieldset/panel
                        System.Web.UI.HtmlControls.HtmlGenericControl myDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                        myDiv.Style.Add(HtmlTextWriterStyle.BorderStyle, "none");
                        myDiv.Style.Add(HtmlTextWriterStyle.Padding, "5px");
                        myDiv.Style.Add(HtmlTextWriterStyle.Width, "955px");
                        myDiv.Style.Add(HtmlTextWriterStyle.Height, "150px");
                        myDiv.Style.Add(HtmlTextWriterStyle.OverflowX, "auto");
                        myDiv.Style.Add(HtmlTextWriterStyle.OverflowY, "auto");
                        if (dtContent.Rows.Count > 0)
                        {
                            // Add the control to the div
                            myDiv.Controls.Add(BindDashboardData(dtContent));
                        }
                        else
                        {
                            // Create HtmlGenericControl span tag
                            HtmlGenericControl spanMessage = new HtmlGenericControl("span");
                            spanMessage.InnerHtml = "<center>No Records Found</center>";
                            spanMessage.Style.Add(HtmlTextWriterStyle.Padding, "15px");
                            spanMessage.Style.Add(HtmlTextWriterStyle.Color, "Red");
                            spanMessage.Style.Add(HtmlTextWriterStyle.FontSize, "11px");
                            // Add the span to the div
                            myDiv.Controls.Add(spanMessage);
                        }
                        row = new TableRow();
                        cell = new TableCell();
                        // Add the div to the TableCell
                        cell.Controls.Add(myDiv);
                        // Add the TableCell to the TableRow
                        row.Cells.Add(cell);
                        // Add the TableRow to the Child Table
                        childtable.Rows.Add(row);
                        // Check is there any help text to show
                        if (DictHelp[dsCotent.Tables.IndexOf(dtContent)].Trim() != string.Empty)
                        {
                            // Create HtmlGenericControl span tag
                            HtmlGenericControl spanNote = new HtmlGenericControl("span");
                            spanNote.InnerHtml = "*Note::";
                            spanNote.Style.Add(HtmlTextWriterStyle.Color, "Red");
                            spanNote.Style.Add(HtmlTextWriterStyle.FontSize, "11px");
                            HtmlGenericControl spanHelp = new HtmlGenericControl("span");
                            spanHelp.InnerHtml = DictHelp[dsCotent.Tables.IndexOf(dtContent)];
                            spanHelp.Style.Add(HtmlTextWriterStyle.Color, "Blue");
                            spanHelp.Style.Add(HtmlTextWriterStyle.FontSize, "11px");
                            row = new TableRow();
                            cell = new TableCell();
                            cell.Style.Add(HtmlTextWriterStyle.Padding, "5px");
                            // Add the HorizontalAlign to the TableCell
                            cell.HorizontalAlign = HorizontalAlign.Left;
                            // Add the span to the TableCell
                            cell.Controls.Add(spanNote);
                            // Add the span to the TableCell
                            cell.Controls.Add(spanHelp);
                            // Add the TableCell to the TableRow
                            row.Cells.Add(cell);
                            // Add the TableRow to the Child Table
                            childtable.Rows.Add(row);
                        }
                        row = new TableRow();
                        cell = new TableCell();
                        // Add the Child Table to the fieldset/panel
                        myFieldSet.Controls.Add(childtable);
                        // Add the fieldset/panel to the TableCell
                        cell.Controls.Add(myFieldSet);
                        // Add the TableCell to the TableRow
                        row.Cells.Add(cell);
                        // Add the TableRow to the Parent Table
                        parenttable.Rows.Add(row);
                    }
                    iCount++;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return parenttable;
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
                gdvCommon.HeaderStyle.CssClass = "HeaderStyle";
                gdvCommon.EditRowStyle.CssClass = "EditRowStyle";
                gdvCommon.AlternatingRowStyle.CssClass = "AltRowStyle_lowheight";
                gdvCommon.RowStyle.HorizontalAlign = HorizontalAlign.Left;
                gdvCommon.Width = 935;
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

        #region [ Masters ]

        /// <summary>
        /// Save records into database
        /// </summary>
        /// <param name="objTSBO"></param>
        /// <returns></returns>
        public int SaveMaster(TSMasterBO objTSMasterBO)
        {
            try
            {
                return objITTSDAL.SaveMaster(objTSMasterBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update record into database
        /// </summary>
        /// <param name="objTSBO"></param>
        /// <returns></returns>
        public int UpdateMaster(TSMasterBO objTSMasterBO)
        {
            try
            {
                return objITTSDAL.UpdateMaster(objTSMasterBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete record from database
        /// </summary>
        /// <param name="objTSBO"></param>
        /// <returns></returns>
        public int DeleteMaster(TSMasterBO objTSMasterBO)
        {
            try
            {
                return objITTSDAL.DeleteMaster(objTSMasterBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Check record in database
        /// </summary>
        /// <param name="objTSBO"></param>
        /// <returns></returns>
        public DataSet CheckMaster(TSMasterBO objTSMasterBO)
        {
            try
            {
                return objITTSDAL.CheckMaster(objTSMasterBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Check record in database from Instances table
        /// </summary>
        /// <param name="objTSBO"></param>
        /// <returns></returns>
        public DataSet CheckInstances(TSMasterBO objTSMasterBO)
        {
            try
            {
                return objITTSDAL.CheckInstances(objTSMasterBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all records from database
        /// </summary>
        /// <returns></returns>
        public List<TSMasterBO> GetMaster(int MasterType)
        {
            try
            {
                return objITTSDAL.GetMaster(MasterType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all records from database
        /// </summary>
        /// <returns></returns>
        public DataSet GetExportMaster(int MasterType)
        {
            try
            {
                return objITTSDAL.GetExportMaster(MasterType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        #endregion


    }
}
