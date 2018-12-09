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

namespace TSTracker.RM.Common
{
    public partial class Common_Index : System.Web.UI.Page
    {

        #region [ Public Variables/Declarations ]

        CommonBAL objCommonBAL;

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
                Page.Title = RMConstraints.Page_Title_Main + RMConstraints.Page_Title_Home;
                objCommonBAL = new CommonBAL();
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
                BindInstances();
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

        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelExport.ExportGridView(hdnInnerHtml.Value);
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        protected void gvModule_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblModuleID = (Label)e.Row.FindControl("lblModuleID");
                    Panel pnlInstance = e.Row.FindControl("pnlInstance") as Panel;
                    pnlInstance.Controls.Add(objCommonBAL.GenerateDashboard(GetFormattedData(objCommonBAL.GetCMDBInstancesByModule(lblModuleID.Text, txtIPAddress.Text, txtHostname.Text), lblModuleID.Text)));
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        #endregion

        #region [ Funcions/Methods ]

        private void BindInstances()
        {
            try
            {
                gvModule.DataSource = RMConstraints.GetModulesDictionary();
                gvModule.DataBind();
                btnExport.Enabled = true;
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
                // Clear the control value of type TextBox
                txtIPAddress.Text = string.Empty;
                txtHostname.Text = string.Empty;
                btnExport.Enabled = false;

                gvModule.DataSource = new DataTable();
                gvModule.DataBind();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        #endregion

        #region [ Dictionary Objects ]

        // <summary>
        //  Author      : <Bhanuprakash>
        //  Create date : <20-April-2012> 
        //  Description : <Get formatted DataSet>
        //  Input       : <DataSet,Integer>
        // </summary>
        private DataSet GetFormattedData(DataSet dsCotent, string strModule)
        {
            try
            {
                Dictionary<int, string> DictObj = new Dictionary<int, string>();
                if (strModule == "1009")
                {
                    DictObj.Add(0, "SOC AV");
                    DictObj.Add(1, "SOC FW");
                    DictObj.Add(2, "SOC NS");
                }
                else if (strModule == "1012")
                {
                    DictObj.Add(0, "CItrix-Physical Servers");
                    DictObj.Add(1, "Genpact-VMs");
                    DictObj.Add(2, "Microsoft-Hyper-V");
                    DictObj.Add(3, "MS HyeperV");
                    DictObj.Add(4, "RCM-CItrix");
                    DictObj.Add(5, "Vmware");
                }
                foreach (KeyValuePair<int, string> kvp in DictObj)
                {
                    dsCotent.Tables[kvp.Key].TableName = kvp.Value;
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
            return dsCotent;
        }

        #endregion

    }
}
