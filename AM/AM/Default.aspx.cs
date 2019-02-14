using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AM_EntityLayer;
using AM_DB_Layer;
using System.Data;
using System.Data.SqlClient;

namespace AM
{
    public partial class Default : System.Web.UI.Page
    {
        MySqlAsmObjs objs = new MySqlAsmObjs();
        MysqlAsMDBCS amdb = new MysqlAsMDBCS();


        asset_info ai = new asset_info();
        AM_DB_Tranactions adt = new AM_DB_Tranactions();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Title = "Ahammed";
                _load_products_ddl();
                _load_assets_grid();

            }
        }
        public void _load_assets_grid()
        {
            DataTable dt = amdb._load_Asset_Codes1();
            gv_Asset_df.DataSource = dt;
            gv_Asset_df.DataBind();
        }
        public void _load_products_ddl()
        {
            MysqlAsMDBCS ABC = new MysqlAsMDBCS();
            DataTable dt = ABC._load_Asset_Products();
            ddl_Asset_product_ad.DataSource = dt;
            ddl_Asset_product_ad.DataTextField = "pr_Name";
            ddl_Asset_product_ad.DataValueField = "pr_id";
            ddl_Asset_product_ad.DataBind();
            ddl_Asset_product_ad.Items.Insert(0, new ListItem("Select One", "0"));
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    desktop_hidden_value.Value = dt.Rows[0]["pr_id"].ToString();
                    Printers_hidden_value.Value = dt.Rows[2]["pr_id"].ToString();
                    Laptop_hidden_value.Value = dt.Rows[1]["pr_id"].ToString();
                }
            }
        }
        protected void btn_assetNew_Num_Save_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_assetNew_Number.Text.ToString()))
            {                                
                objs.AS_AssetCode  = txt_assetNew_Number.Text.ToString();                
                objs.Pr_type_id = Convert.ToInt32(ddl_Asset_product_type_ad.SelectedItem.Value);
                objs.Prfk_id = Convert.ToInt32(ddl_Asset_product_ad.SelectedValue);
                objs.As_CreatedBy = "Ahammed";
                int i = amdb._insert_Asset_Code_info(objs);
                if (i == 1)
                {
                    _load_assets_grid();  
                    ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "AssetRecinserted();", true);
                    txt_assetNew_Number.Text = string.Empty;
                                     
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "AssetCodeUsed();", true);                   
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "typething();", true);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Desktop/AddDesktop.aspx?key=" + desktop_hidden_value.Value);
        }

        protected void ddl_Asset_product_ad_SelectedIndexChanged(object sender, EventArgs e)
        {

            objs.Prfk_id = Convert.ToInt32(ddl_Asset_product_ad.SelectedItem.Value);
            DataTable dt = amdb._load_Asset_Products_types_byid(objs);          
            ddl_Asset_product_type_ad.DataSource = dt;
            ddl_Asset_product_type_ad.DataTextField = "pr_type_name";
            ddl_Asset_product_type_ad.DataValueField = "pr_type_id";
            ddl_Asset_product_type_ad.DataBind();
            ddl_Asset_product_type_ad.Items.Insert(0, new ListItem("-- Select One --", "0"));        
           
        }

        protected void ddl_Asset_product_type_ad_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlAsmObjs obj = new MySqlAsmObjs();
            obj.Pr_sh_name = ddl_Asset_product_type_ad.SelectedItem.Value;
            MysqlAsMDBCS ABC = new MysqlAsMDBCS();
            DataTable dt = ABC._load_Asset_Short_name(obj);
            if (dt.Rows.Count > 0)
            {
                txt_assetNew_Number.Text = "KPCL/" + dt.Rows[0]["pr_type_sh_Name"].ToString() + "/";
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Desktop/AddDesktop.aspx?key=" + Printers_hidden_value.Value);
        }

        protected void lbtn_scanner_Click(object sender, EventArgs e)
        {

        }
        //protected void LinkButton3_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/Desktop/AddDesktop.aspx?key=" + Laptop_hidden_value.Value);
        //}



      
    }
}

