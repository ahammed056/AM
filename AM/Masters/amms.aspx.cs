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
                _load_brand_model_grid();
                _load_processorName_grid();
                _load_processorName_ddl();
                _load_processor_speed_grid();        
            }
        }

        protected void btn_Brand_Save_Click(object sender, EventArgs e)
        {


            if (btn_Brand_Save.Text == "Save")
            {

                if (!string.IsNullOrWhiteSpace(txt_Brand_Name_amms.Text.ToString()))
                {
                    CPU_Details cd = new CPU_Details();
                    cd.CPU_BRAND_MAKE = txt_Brand_Name_amms.Text.ToString();
                    cd.CPU_ITEM_CREATEDBY = "ahammed";
                    String i = adt.insert_brand_Name_cpu(cd);
                    if (i == "Brand Name Inserted Sucessfully")
                    {
                        ScriptManager.RegisterClientScriptBlock(btn_Brand_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + i + "');</script>", false);
                        txt_Brand_Name_amms.Text = string.Empty;
                        _load_brand();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(btn_Brand_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + i + "');</script>", false);
                        _load_brand();
                        txt_Brand_Name_amms.Text = string.Empty;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "typething();", true);
                }
            }
            else if (btn_Brand_Save.Text == "Update")
            {
                if (!string.IsNullOrWhiteSpace(txt_Brand_Name_amms.Text.ToString()))
                {
                    CPU_Details cd = new CPU_Details();
                    cd.Cpu_brand_id = Convert.ToInt32(ViewState["bm_brand_id"]);
                    cd.CPU_BRAND_MAKE = txt_Brand_Name_amms.Text.ToString();
                    //  cd.CPU_ITEM_CREATEDBY = "ahammed";
                    String i = adt.Upadte_brand_Name_cpu(cd);
                    if (i == "Select 'Brand Name Has Changed'")
                    {
                        ScriptManager.RegisterClientScriptBlock(btn_Brand_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + i + "');</script>", false);
                        txt_Brand_Name_amms.Text = string.Empty;
                        _load_brand();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(btn_Brand_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('No chages has Done');</script>", false);
                        _load_brand();
                        txt_Brand_Name_amms.Text = string.Empty;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "typething();", true);
                }
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
                    String i = adt.insert_barnd_Model_cpu(cd);
                    if (i == "Model Name Inserted Sucessfully")
                    {
                        ScriptManager.RegisterClientScriptBlock(btn_Brand_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + i + "');</script>", false);
                        txt_Brand_Name_amms.Text = string.Empty;
                        _load_brand_model_grid();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(btn_Brand_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + i + "');</script>", false);
                        _load_brand_model_grid();
                        txt_Brand_Model.Text = string.Empty;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "typething();", true);
                }                       
        }

        public void _load_brand_grid()
        {
            DataTable dt = adt.view_Cpu_brand();
            gv_cpu_brand_info.DataSource = dt;
            gv_cpu_brand_info.DataBind();
        }

        public void _load_brand_model_grid()
        {
            DataTable dt = adt.view_Cpu_brand_model();
            gv_cpu_brand_Model_info.DataSource = dt;
            gv_cpu_brand_Model_info.DataBind();
        }
       // gv_processor_asm
        public void _load_processorName_grid()
        {
            DataTable dt = adt.view_processorModel_name();
            gv_processor_asm.DataSource = dt;
            gv_processor_asm.DataBind();
        }
        public void _load_processor_speed_grid()
        {
            DataTable dt = adt.view_processor_Speed();
            gv_processor_speed_asm.DataSource = dt;
            gv_processor_speed_asm.DataBind();
        }

        public void _load_processorName_ddl()
        {
            DataTable dt = adt.view_processorModel_name();
            ddl_processor_Name_asm.DataSource = dt;
            ddl_processor_Name_asm.DataTextField = "processor_Name";
            ddl_processor_Name_asm.DataValueField = "processor_id";
            ddl_processor_Name_asm.DataBind();           
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
                    String i = adt.insert_AssetType(ais);
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
            if (btn_Asset_type_save_amms.Text == "Update")
            {
                if (!string.IsNullOrWhiteSpace(txt_Asset_type_amms.Text.ToString()))
                {
                    asset_info ais = new asset_info();
                    ais.Asset_id = Convert.ToInt32(lbl_id.Text);
                    ais.AS_TYPE = txt_Asset_type_amms.Text.TrimEnd(' ');


                    String i = adt.Upadte_AssetType(ais);
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

        protected void ibtn_brand_asm_Click(object sender, ImageClickEventArgs e)
        {
          
            btn_Brand_Save.Text = "Update";
            ImageButton btn = (ImageButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            HiddenField hf_brand = (HiddenField)gvr.FindControl("hf_brand_id");
            HiddenField hf_val = new HiddenField();
            hf_val.Value = hf_brand.Value;
            CPU_Details cds = new CPU_Details();
            cds.Cpu_brand_id = Convert.ToInt32(hf_val.Value);
            AM_DB_Tranactions ad = new AM_DB_Tranactions();
            DataTable dt = ad.view_Cpu_brand_edit_dispaly(cds);
            if (dt.Rows.Count > 0)
            {
                    lbl_brand_id.Text = dt.Rows[0]["bm_id"].ToString();
                    ViewState["bm_brand_id"] = dt.Rows[0]["bm_id"].ToString();
                    txt_Brand_Name_amms.Text = dt.Rows[0]["bm_brand"].ToString();
            }
            else
            {
                txt_Brand_Name_amms.Text = string.Empty;
            }
        }

        protected void ibtn_brand_model_asm_Click(object sender, ImageClickEventArgs e)
        {
            _load_brand_model_grid();
            btn_Brand_Model_save.Text = "Update";
            ImageButton btn1 = (ImageButton)sender;
            GridViewRow gvr1 = (GridViewRow)btn1.NamingContainer;

            HiddenField hf_brand_model = (HiddenField)gvr1.FindControl("hf_brand_model_name");

         //   Label lb1 = (Label)gvr1.FindControl("lbl_brand_model_asm");



            HiddenField hf_model = new HiddenField();


             hf_model.Value = hf_brand_model.Value;


            CPU_Details cds = new CPU_Details();
            cds.Cpu_model_make = hf_model.Value;
            AM_DB_Tranactions ad = new AM_DB_Tranactions();
            DataTable dt = ad.view_Cpu_brand_model_edit_dispaly(cds);
            if (dt.Rows.Count > 0)
            {              
                ddl_amms_brand.SelectedItem.Value = dt.Rows[0]["bbm_brand_id"].ToString();
                txt_Brand_Model.Text = dt.Rows[0]["bbm_model"].ToString();
            }
            else
            {
                txt_Brand_Model.Text = string.Empty;
            }

           

            
        }

        protected void gv_view_Assettype_grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_view_Assettype_grid.PageIndex = e.NewPageIndex;
            _load_astype_grid();
        }

        protected void gv_cpu_brand_info_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_cpu_brand_info.PageIndex = e.NewPageIndex;
            _load_brand_grid();
        }

        protected void gv_cpu_brand_Model_info_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_cpu_brand_Model_info.PageIndex = e.NewPageIndex;
            _load_brand_model_grid();
        }

        protected void btn_processor_asm_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_processor_name_asm.Text.ToString()))
            {
                CPU_Details cds = new CPU_Details();
                cds.CPU_PROCESSOR_MODEL = txt_processor_name_asm.Text.ToString();
                cds.CPU_ITEM_CREATEDBY = "ahammed";
                int i = adt.insert_Processor_Name(cds);
                if (i == 1)
                {
                    ScriptManager.RegisterClientScriptBlock(btn_Brand_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('processor Name Saved Sucessfully');</script>", false);
                    txt_processor_name_asm.Text = string.Empty;
                    _load_processorName_grid();
                }
                else
                {
                   
                    ScriptManager.RegisterClientScriptBlock(btn_Brand_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('Try a.... New Processor Name');</script>", false);                   
                    txt_processor_name_asm.Text = string.Empty;
                    _load_processorName_grid();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "typething();", true);
            }
        }

        protected void gv_processor_asm_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_processor_asm.PageIndex = e.NewPageIndex;
            _load_processorName_grid();
            _load_processorName_ddl();
        }

        protected void btn_processor_speed_asm_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_processor_speed_asm.Text.ToString()))
            {
                CPU_Details cds = new CPU_Details();
                cds.Cpu_brand_id = Convert.ToInt32(ddl_processor_Name_asm.SelectedItem.Value);
                cds.CPU_PROCESSOR_SPEED = txt_processor_speed_asm.Text.ToString();
                cds.CPU_ITEM_CREATEDBY = "ahammed";
                int i = adt.insert_Processor_speed(cds);
                if (i == 1)
                {
                    ScriptManager.RegisterClientScriptBlock(btn_Brand_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('processor Name Saved Sucessfully');</script>", false);
                    txt_processor_name_asm.Text = string.Empty;
                    _load_processorName_grid();
                }
                else
                {

                    ScriptManager.RegisterClientScriptBlock(btn_Brand_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('Try a.... New Processor Name');</script>", false);
                    txt_processor_name_asm.Text = string.Empty;
                    _load_processorName_grid();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "typething();", true);
            }

        }

        protected void btn_Monitor_asm_Click(object sender, EventArgs e)
        {
            if (btn_Monitor_asm.Text == "Save")
            {

                if (!string.IsNullOrWhiteSpace(txt_Monitor_name_asm.Text.ToString()))
                {
                    Monitor_Details md = new Monitor_Details();
                    md.MO_MAKE = txt_Monitor_name_asm.Text.ToString();
                    md.MO_CREATEDBY = "ahammed";
                    String i = adt.insert_brand_Name_monitor(md);
                    if (i == "Brand Name Inserted Sucessfully")
                    {
                        ScriptManager.RegisterClientScriptBlock(btn_Brand_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + i + "');</script>", false);
                        txt_Monitor_name_asm.Text = string.Empty;
                        //  _load_brand();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(btn_Brand_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + i + "');</script>", false);
                        // _load_brand();
                        txt_Monitor_name_asm.Text = string.Empty;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "typething();", true);
                }
            }
            if (btn_Monitor_asm.Text == "Update")
            {
                if (!string.IsNullOrWhiteSpace(txt_Asset_type_amms.Text.ToString()))
                {
                    asset_info ais = new asset_info();
                    ais.Asset_id = Convert.ToInt32(lbl_id.Text);
                    ais.AS_TYPE = txt_Asset_type_amms.Text.TrimEnd(' ');


                    String i = adt.Upadte_AssetType(ais);
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

        protected void btn_Monitor_Model_asm_Click(object sender, EventArgs e)
        {

        }
    }
}