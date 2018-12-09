using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Web.UI;


namespace TSUtility
{
    public class ExcelExport
    {

        /// <summary>
        /// "Author : Bhanuprakash"
        /// "Create date : 20-March-2012"
        /// "Description : Exporting DataTable to Excel/CSV file based on the record count"
        /// </summary>
        /// <param name="dt">Input DataTable</param>
        /// <param name="strFileName">Output File Name</param>
        public static void ExportDataTable(DataTable dt, string strFileName)
        {
            try
            {
                string attachment = "attachment; filename=" + strFileName + "";
                StringBuilder sb = new StringBuilder();
                if (dt.Rows.Count > 64998)
                {
                    //Exporting DataTable to CSV file  
                    attachment = attachment + ".csv";
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.Buffer = true;
                    HttpContext.Current.Response.AddHeader("content-disposition", attachment);
                    HttpContext.Current.Response.ContentType = "application/text";
                    HttpContext.Current.Response.Charset = "";
                    HttpContext.Current.Response.ContentType = "application/force-download";
                    //Write a line with the columns name
                    foreach (DataColumn dcHeader in dt.Columns)
                    {
                        sb.Append(dcHeader.ColumnName.Replace(RMConstraints.ExcelExport_vbCr + RMConstraints.ExcelExport_vbLf, " ").Replace(",", "-") + ',');
                    }
                    sb.Append(RMConstraints.ExcelExport_vbCr + RMConstraints.ExcelExport_vbLf);
                    //Write all the rows
                    foreach (DataRow drBody in dt.Rows)
                    {
                        foreach (DataColumn col in dt.Columns)
                        {
                            sb.Append(drBody[col.ColumnName].ToString().Replace(RMConstraints.ExcelExport_vbCr + RMConstraints.ExcelExport_vbLf, " ").Replace(",", "-") + ',');
                        }
                        sb.Append(RMConstraints.ExcelExport_vbCr + RMConstraints.ExcelExport_vbLf);
                    }
                    HttpContext.Current.Response.Output.Write(sb.ToString());
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.Response.End();
                }
                else
                {
                    //Exporting DataTable to Excel file
                    attachment = attachment + ".xls";
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.AddHeader("content-disposition", attachment);
                    HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                    HttpContext.Current.Response.Charset = "UTF-8";
                    HttpContext.Current.Response.ContentType = "application/force-download";
                    //Write a line with the columns name
                    foreach (DataColumn dcHeader in dt.Columns)
                    {
                        sb.Append(dcHeader.ColumnName.Replace(RMConstraints.ExcelExport_vbCr + RMConstraints.ExcelExport_vbLf, " ") + RMConstraints.ExcelExport_vbTab);
                    }
                    sb.Append(RMConstraints.ExcelExport_vbCr + RMConstraints.ExcelExport_vbLf);
                    //Write all the rows
                    foreach (DataRow drBody in dt.Rows)
                    {
                        foreach (DataColumn col in dt.Columns)
                        {
                            sb.Append(drBody[col.ColumnName].ToString().Replace(RMConstraints.ExcelExport_vbCr + RMConstraints.ExcelExport_vbLf, " ") + RMConstraints.ExcelExport_vbTab);
                        }
                        sb.Append(RMConstraints.ExcelExport_vbCr + RMConstraints.ExcelExport_vbLf);
                    }
                    HttpContext.Current.Response.Output.Write(sb.ToString());
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.Response.End();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// "Author : Bhanuprakash"
        /// "Create date : 13-April-2012"
        /// "Description : Exporting DataSet to Excel"
        /// </summary>
        /// <param name="ds">Input DataSet</param>
        /// <param name="strFileName">Output File Name</param>
        public static void ExportDataSet(DataSet ds, string strFileName)
        {
            try
            {
                string attachment = "attachment; filename=" + strFileName + "";
                StringBuilder sb = new StringBuilder();
                //Exporting DataTable to Excel file
                attachment = attachment + ".xls";
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader("content-disposition", attachment);
                HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                HttpContext.Current.Response.Charset = "UTF-8";
                HttpContext.Current.Response.ContentType = "application/force-download";
                foreach (DataTable dt in ds.Tables)
                {
                    sb.Append(RMConstraints.ExcelExport_vbCr + RMConstraints.ExcelExport_vbLf);
                    sb.Append(RMConstraints.ExcelExport_vbCr + RMConstraints.ExcelExport_vbLf);
                    sb.Append(dt.TableName.Replace(RMConstraints.ExcelExport_vbCr + RMConstraints.ExcelExport_vbLf, " "));
                    sb.Append(RMConstraints.ExcelExport_vbCr + RMConstraints.ExcelExport_vbLf);
                    sb.Append(RMConstraints.ExcelExport_vbCr + RMConstraints.ExcelExport_vbLf);
                    //Write a line with the columns name
                    foreach (DataColumn dcHeader in dt.Columns)
                    {
                        sb.Append(dcHeader.ColumnName.Replace(RMConstraints.ExcelExport_vbCr + RMConstraints.ExcelExport_vbLf, " ") + RMConstraints.ExcelExport_vbTab);
                    }
                    sb.Append(RMConstraints.ExcelExport_vbCr + RMConstraints.ExcelExport_vbLf);
                    //Write all the rows
                    foreach (DataRow drBody in dt.Rows)
                    {
                        foreach (DataColumn col in dt.Columns)
                        {
                            sb.Append(drBody[col.ColumnName].ToString().Replace(RMConstraints.ExcelExport_vbCr + RMConstraints.ExcelExport_vbLf, " ") + RMConstraints.ExcelExport_vbTab);
                        }
                        sb.Append(RMConstraints.ExcelExport_vbCr + RMConstraints.ExcelExport_vbLf);
                    }
                }
                HttpContext.Current.Response.Output.Write(sb.ToString());
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ExportGridView(GridView gridView, string strFileName)
        {
            try
            {
                string attachment = "attachment; filename=" + strFileName + "";
                attachment = attachment + ".xls";
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.AddHeader("content-disposition", attachment);
                HttpContext.Current.Response.ContentType = "application/ms-excel";
                HttpContext.Current.Response.Charset = "UTF-8";
                HttpContext.Current.Response.ContentType = "application/force-download";
                StringWriter sWriter = new StringWriter();

                HtmlTextWriter htwWriter = new HtmlTextWriter(sWriter);

                gridView.RenderControl(htwWriter);
                HttpContext.Current.Response.Write(sWriter.ToString());
                HttpContext.Current.Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ExportGridView(string strHtmlContent)
        {
            try
            {
                HttpContext.Current.Response.Cache.SetExpires(DateTime.Now.AddSeconds(1));
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AppendHeader("content-disposition", "attachment;filename=CDR_Instances.xls");
                HttpContext.Current.Response.Charset = "";
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                HttpContext.Current.Response.Write("\r\n");
                HttpContext.Current.Response.Write(strHtmlContent);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void VerifyRenderingInServerForm(Control control)
        {
            return;
        }

    }
}
