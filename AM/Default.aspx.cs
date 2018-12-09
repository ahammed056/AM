using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AM_EntityLayer;
using AM_DB_Layer;
using System.Data;
       

namespace AM
{
    public partial class Default : System.Web.UI.Page
    {
        asset_info ai = new asset_info();
        AM_DB_Tranactions adt = new AM_DB_Tranactions();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _load_astype_ddl();
                _load_assets_grid();
            }
        }
        public void _load_assets_grid()
        {
            DataTable dt = adt.view_AssetId();
            gv_Asset_aa.DataSource = dt;
            gv_Asset_aa.DataBind();
        }
        public void _load_astype_ddl()
        {
            DataTable dt = adt.view_Asset_type_grid();
            ddl_Asset_type_ad.DataSource = dt;
            ddl_Asset_type_ad.DataTextField = "type_name";
            ddl_Asset_type_ad.DataValueField = "type_id";
            ddl_Asset_type_ad.DataBind();
        }
        protected void btn_assetNew_Num_Save_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_assetNew_Number.Text.ToString()))
            {
                ai.AS_ASSETCODE = txt_assetNew_Number.Text.ToString();
                ai.AS_TYPE = ddl_Asset_type_ad.SelectedItem.Text;
                String i = adt.insertAssertid(ai);

                if (i == "Asset Code already exists")
                {
                //    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "Cpuview();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "AssetCodeUsed();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "AssetRecinserted();", true);
                    txt_assetNew_Number.Text = string.Empty;
                    _load_assets_grid();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "typething();", true);
            }
        }

    }
}