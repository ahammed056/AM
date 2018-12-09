using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TSBAL;
using TSEntity;
using TSUtility;
using System.Collections;
using System.Drawing;
using System.Globalization;

namespace TSTracker.RM.TS
{
    public partial class TS_Report : System.Web.UI.Page
    {
        #region [ Public Variables/Declarations ]

        ITTSBAL objITTSBAL;
        TSBO objTSBO;

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
                Page.Title = RMConstraints.Page_Title_Main + RMConstraints.WebPage_ITTS_Report;
                objITTSBAL = new ITTSBAL();
                if (!IsPostBack)
                {
                    DateTime firstOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    //txtFromDate.Text = firstOfMonth.ToString("MM/dd/yyyy").Replace("-", "/");
                    //txtToDate.Text = DateTime.Now.ToString("MM/dd/yyyy").Replace("-", "/");

                    txtFromDate.Text = firstOfMonth.ToString("MM/dd/yyyy");
                    txtToDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                }
                BindRequests();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        #endregion

        #region [ Control events ]

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindRequests();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                List<TSBO> objList = new List<TSBO>();
                ITTSSearchCriteria objSearch = new ITTSSearchCriteria();
                objSearch.EmpId = txtEmpId.Text.Trim();
                objSearch.FromDate = Convert.ToDateTime(txtFromDate.Text);
                objSearch.ToDate = Convert.ToDateTime(txtToDate.Text);

                GridView gvtmp = new GridView();
                gvtmp.DataSource = objITTSBAL.GetTSRptExprt(objSearch).Tables[0];
                gvtmp.DataBind();
                GroupGridView(gvtmp.Rows, 0, 1);

                ExcelExport.ExportGridView(gvtmp, "TimeSheet_Details");
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        #endregion

        #region [ Funcions/Methods ]

        private void BindRequests()
        {
            try
            {
                List<TSBO> objList = new List<TSBO>();
                ITTSSearchCriteria objSearch = new ITTSSearchCriteria();
                objSearch.EmpId = txtEmpId.Text.Trim();

                //objSearch.FromDate = Convert.ToDateTime(txtFromDate.Text);
                //objSearch.ToDate = Convert.ToDateTime(txtToDate.Text);

                objSearch.FromDate = DateTime.ParseExact(txtFromDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                objSearch.ToDate = DateTime.ParseExact(txtToDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                objList = objITTSBAL.GetTSRecords(objSearch);
                gvReport.DataSource = objList;
                gvReport.DataBind();
                if (objList.Count > 0)
                {
                    //GroupGridView(gvReport.Rows, 1, 1);
                    lblRecords.Text = "No.of Requests : " + objList.Count.ToString();
                }
                else
                {
                    gvReport.DataSource = null;
                    gvReport.DataBind();
                    lblRecords.Text = "";
                    lblRecords.Text = "No Requests Found";
                }
            }
            catch (Exception ex)
            {
                Feedback1.addFailure("Could not get requests !");
                throw ex;
            }
        }
        private void GroupGridView(GridViewRowCollection gvrc, int startIndex, int total)
        {
            if (total == 0)
            {
                return;
            }
            int i = 0;
            int count = 1;
            //Array lst = new Array();
            ArrayList lst = new ArrayList();
            lst.Add(gvrc[0]);
            TableCell ctrl = gvrc[0].Cells[startIndex];
            for (i = 1; i <= gvrc.Count - 1; i++)
            {
                TableCell nextCell = gvrc[i].Cells[startIndex];
                if (ctrl.Text == nextCell.Text)
                {
                    count += 1;
                    nextCell.Visible = false;
                    lst.Add(gvrc[i]);
                }
                else
                {
                    if (count > 1)
                    {
                        ctrl.RowSpan = count;
                        GroupGridView(new GridViewRowCollection(lst), startIndex + 1, total - 1);
                    }
                    count = 1;
                    lst.Clear();
                    ctrl = gvrc[i].Cells[startIndex];
                    lst.Add(gvrc[i]);
                }
            }
            if (count > 1)
            {
                ctrl.RowSpan = count;
                GroupGridView(new GridViewRowCollection(lst), startIndex + 1, total - 1);
            }
            count = 1;
            lst.Clear();
        }
        #endregion
    }
}
