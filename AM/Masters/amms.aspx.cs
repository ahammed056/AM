using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AM_EntityLayer;
using AM_DB_Layer;
using System.Data;

namespace AM.Masters
{
    public partial class amms : System.Web.UI.Page
    {
        AM_DB_Tranactions adt = new AM_DB_Tranactions();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                _load_brand();
                _load_brand_grid();
                _load_astype_grid();
        
            }
        }

        protected void btn_Brand_Save_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_Brand_Name.Text.ToString()))
            {
                CPU_Details cd = new CPU_Details();
                cd.CPU_BRAND_MAKE= txt_Brand_Name.Text.ToString();
                cd.CPU_ITEM_CREATEDBY = "ahammed";
                String i = adt.insertbarndName(cd);
                if (i == "Brand Name Inserted Sucessfully")
                {
                    ScriptManager.RegisterClientScriptBlock(btn_Brand_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + i + "');</script>", false);
                    txt_Brand_Name.Text = string.Empty;
                    _load_brand();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(btn_Brand_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + i + "');</script>", false);
                    _load_brand();
                    txt_Brand_Name.Text = string.Empty;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "typething();", true);
            }                           
        }

        public void _load_brand()
        {
            DataTable dt = adt.view_Cpu_brand();
            ddl_amms_brand.DataSource = dt;
            ddl_amms_brand.DataTextField = "bm_brand";
            ddl_amms_brand.DataValueField = "bm_id";
            ddl_amms_brand.DataBind();
        }

        protected void btn_Brand_Model_save_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_Brand_Model.Text.ToString()))
            {
                CPU_Details cd = new CPU_Details();
                cd.Cpu_brand_id = Convert.ToInt32(ddl_amms_brand.SelectedItem.Value);
                cd.CPU_BRAND_MAKE = txt_Brand_Model.Text.ToString();
                cd.CPU_ITEM_CREATEDBY = "ahammed";
                String i = adt.insertbarndModel(cd);
                if (i == "Model Name Inserted Sucessfully")
                {
                    ScriptManager.RegisterClientScriptBlock(btn_Brand_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + i + "');</script>", false);
                    txt_Brand_Name.Text = string.Empty;
                    _load_brand();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(btn_Brand_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + i + "');</script>", false);
                    _load_brand();
                    txt_Brand_Name.Text = string.Empty;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "typething();", true);
            }               
        }

        public void _load_brand_grid()
        {
            DataTable dt = adt.view_Cpu_brand_grid();
            gv_cpu_brand_info.DataSource = dt;
            gv_cpu_brand_info.DataBind();
        }

        public void _load_astype_grid()
        {
            DataTable dt = adt.view_Asset_type_grid();
            gv_view_Assettype_grid.DataSource = dt;
            gv_view_Assettype_grid.DataBind();
        }

        protected void btn_Asset_type_save_amms_Click(object sender, EventArgs e)
        {

            if (btn_Asset_type_save_amms.Text == "Save")
            {

                if (!string.IsNullOrWhiteSpace(txt_Asset_type_amms.Text.ToString()))
                {
                    asset_info ais = new asset_info();
                    ais.AS_TYPE = txt_Asset_type_amms.Text.ToString();
                    ais.AS_CREATEDBY = "ahammed";
                    String i = adt.insertAssetType(ais);
                    if (i == "Asset Type Inserted Sucessfully")
                    {
                        ScriptManager.RegisterClientScriptBlock(btn_Brand_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + i + "');</script>", false);
                        txt_Asset_type_amms.Text = string.Empty;
                        //  _load_brand();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(btn_Brand_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + i + "');</script>", false);
                        // _load_brand();
                        txt_Asset_type_amms.Text = string.Empty;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "typething();", true);
                }
            }
            if(btn_Asset_type_save_amms.Text == "Update")
            {
                if (!string.IsNullOrWhiteSpace(txt_Asset_type_amms.Text.ToString()))
                {
                    asset_info ais = new asset_info();
                    ais.Asset_id = Convert.ToInt32(lbl_id.Text);
                    ais.AS_TYPE = txt_Asset_type_amms.Text.TrimEnd(' ');
                    

                    String i = adt.UpadteAssetType(ais);
                    if (i == "1")
                    {
                        ScriptManager.RegisterClientScriptBlock(btn_Brand_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + i + "');</script>", false);
                        txt_Asset_type_amms.Text = string.Empty;
                        btn_Asset_type_save_amms.Text = "Save";
                        _load_astype_grid();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(btn_Brand_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + i + "');</script>", false);
                        btn_Asset_type_save_amms.Text = "Save";
                        txt_Asset_type_amms.Text = string.Empty;
                        _load_astype_grid();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "typething();", true);
                }
            }
        }

        protected void ibtn_asttype_asm_Click(object sender, ImageClickEventArgs e)
        {
            btn_Asset_type_save_amms.Text = "Update";
            ImageButton btn = (ImageButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            HiddenField hiduno = (HiddenField)gvr.FindControl("hf_type_name");
            HiddenField hfieldupd = new HiddenField();
            hfieldupd.Value = hiduno.Value;
            AM_DB_Tranactions ad = new AM_DB_Tranactions();
            DataTable dt = ad.view_Asset_type_edit_dispaly(hiduno.Value);
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                   
                    lbl_id.Text = dt.Rows[0]["type_id"].ToString();
                    txt_Asset_type_amms.Text = dt.Rows[0]["type_name"].ToString();
                }

            }
            else
            {
                txt_Asset_type_amms.Text = string.Empty;
            }
        }
    }
}