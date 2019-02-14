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
    /// <summary>
    ///     // string te = String.IsNullOrEmpty(ddl_brands_amms.SelectedValue) ? null : ddl_brands_amms.SelectedValue;  passing a null value in ddl
    /// </summary>
    public partial class amms : System.Web.UI.Page
    {
        MysqlAsMDBCS amdb = new MysqlAsMDBCS();
        MySqlAsmObjs objs = new MySqlAsmObjs();
        AM_DB_Tranactions adt = new AM_DB_Tranactions();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                
                _load_products_grid();
                _load_products_ddl();
                _load_products_types_grid();
                _load_cartridemodel_grid();
            }
        }



        #region MysqlCode for Asset Management
        /// <summary>
        /// This is to get the products on Grid
        /// </summary>
        /// 
        public void _load_products_grid()
        {
            DataTable dt = amdb._load_Asset_Products();
            gv_products_grid.DataSource = dt;
            gv_products_grid.DataBind();
        }

        public void _load_cartridemodel_grid()
        {
            DataTable dt = amdb._load_Asset_cartridge();
            gv_cartridges_amms.DataSource = dt;
            gv_cartridges_amms.DataBind();
        }
        /// <summary>
        /// This code is used for Loading the product into dropdown
        /// </summary>
        public void _load_products_ddl()
        {
            DataTable dt = amdb._load_Asset_Products();  // adt.view_Asset_type_grid();
            ddl_products_asm.DataSource = dt;
            ddl_products_asm.DataTextField = "pr_Name";
            ddl_products_asm.DataValueField = "pr_id";
            ddl_products_asm.DataBind();
            ddl_products_asm.Items.Insert(0, new ListItem("-- Select One --", "0"));
        }
        /// <summary>
        /// This code is used for the loading the grid for the product Types
        /// </summary>
        /// 

        public void _load_products_types_grid()
        {
            DataTable dt = amdb._load_Asset_Products_types();
            gv_products_type_info.DataSource = dt;
            gv_products_type_info.DataBind();
        }
        /// <summary>
        /// This code is used for the loading the grid for the product Types by prfks       --- nouse
        /// </summary>
        /// 
        public void _load_products_types_byid()
        {
            objs.Prfk_id = Convert.ToInt32(ddl_products_asm.SelectedItem.Value);
            DataTable dt = amdb._load_Asset_Products_types_byid(objs);
            gv_products_type_info.DataSource = dt;
            gv_products_type_info.DataBind();
            ddl_product_type_amms.DataSource = dt;
            ddl_product_type_amms.DataTextField = "pr_type_name";
            ddl_product_type_amms.DataValueField = "pr_type_id";
            ddl_product_type_amms.DataBind();
            ddl_product_type_amms.Items.Insert(0, new ListItem("-- Select One --", "0"));
        }

        /// <summary>
        /// This code is used for the loading the grid for the brands by prfks and prids      
        /// </summary>
        /// 
        public void _load_brands_byids()
        {
            objs.Pr_id = Convert.ToInt32(ddl_products_asm.SelectedItem.Value);
            objs.Prfk_id = Convert.ToInt32(ddl_product_type_amms.SelectedItem.Value);
            DataTable dt = amdb._load_Asset_brands_byid(objs);
            gv_brand_info_amms.DataSource = dt;
            gv_brand_info_amms.DataBind();
            ddl_brands_amms.DataSource = dt;
            ddl_brands_amms.DataTextField = "br_name";
            ddl_brands_amms.DataValueField = "br_id";
            ddl_brands_amms.DataBind();
            ddl_brands_amms.Items.Insert(0, new ListItem("-- Select One --", "0"));
        }


        public void _load_model_byids()
        {
            objs.Mo_br_id = Convert.ToInt32(ddl_brands_amms.SelectedItem.Value);          
            DataTable dt = amdb._load_Asset_models_byid(objs);
            gv_model_info_amms.DataSource = dt;
            gv_model_info_amms.DataBind();
           // gv_model_info_amms.Items.Insert(0, new ListItem("-- Select One --", "0"));
        }



        #endregion

        public void _load_brand_ddl()
        {
            DataTable dt = adt.view_Asset_type_grid();
            ddl_products_asm.DataSource = dt;
            ddl_products_asm.DataTextField = "pr_name";
            ddl_products_asm.DataValueField = "pr_id";
            ddl_products_asm.DataBind();
            ddl_products_asm.Items.Insert(0, new ListItem("-- Select One --", "0"));       
        }
        public void _load_brand_model_ddl()
        {
            CPU_Details cu1 = new CPU_Details();
            cu1.Brandidinc = ddl_products_asm.SelectedItem.Value;
            DataTable dt = adt.view_brands_byid(cu1);
            ddl_product_type_amms.DataSource = dt;
            ddl_product_type_amms.DataTextField = "bm_brand";
            ddl_product_type_amms.DataValueField = "type_id";
            ddl_product_type_amms.DataBind();
        
        }
        public void _load_brand_grid()
        {
            CPU_Details cu1 = new CPU_Details();
            cu1.Brandidinc = ddl_products_asm.SelectedItem.Value;
            DataTable dt = adt.view_brands_byid(cu1);
            gv_products_type_info.DataSource = dt;
            gv_products_type_info.DataBind();
        }
        public void _load_brand_model_grid()
        {
            CPU_Details cu1 = new CPU_Details();
            cu1.Cpu_am_id3 = ddl_products_asm.SelectedItem.Value;
            DataTable dt = adt.view_brand_model(cu1);
            gv_brand_info_amms.DataSource = dt;
            gv_brand_info_amms.DataBind();
        }  
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
            gv_products_grid.DataSource = dt;
            gv_products_grid.DataBind();
        }

        public void _load_Monitor_brand()
        {
            DataTable dt = adt.view_Monitor_brand();
            gv_Monitor_barnd_asm.DataSource = dt;
            gv_Monitor_barnd_asm.DataBind();
        }
        public void _ddl_load_Monitor_brand()
        {
            DataTable dt = adt.view_Monitor_brand();
            ddl_MonitorModel_asm.DataSource = dt;
            ddl_MonitorModel_asm.DataTextField = "bm_brand";
            ddl_MonitorModel_asm.DataValueField = "bm_id";
            ddl_MonitorModel_asm.DataBind();
        }
        public void _load_Monitor_brand_Model_grid()
        {
            DataTable dt = adt.view_Monitor_brand_model();
            gv_Monitor_barnd_model_asm.DataSource = dt;
            gv_Monitor_barnd_model_asm.DataBind();
        }
        public void _load_Monitor_brand_Model_ddl()
        {
            DataTable dt = adt.view_Monitor_brand();
           ddl_MonitorModel_asm.DataSource = dt;
           ddl_MonitorModel_asm.DataTextField = "bm_brand";
           ddl_MonitorModel_asm.DataValueField = "BM_id";
          ddl_MonitorModel_asm.DataBind();
        }

        /// <summary>
        /// Products Insertions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_product_save_amms_Click(object sender, EventArgs e)
        {
            if (btn_product_save_amms.Text == "Save")
            {
                if (!string.IsNullOrWhiteSpace(txt_product_amms.Text.ToString()))
                {
                    objs.Pr_Name = txt_product_amms.Text.ToString().TrimEnd().TrimStart();
                    objs.Pr_createdby = "Ahammed syed";
                    int i  = amdb._insert_product_info(objs);
                    string strmessage = "";
                    if (i == 1)
                    {
                        strmessage = "New Asset  " + txt_product_amms.Text + "     Was Inserted";
                        ScriptManager.RegisterClientScriptBlock(btn_product_save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + strmessage + "');</script>", false);
                        txt_product_amms.Text = string.Empty;
                        _load_products_grid();
                        _load_products_ddl();
                        
                    }
                    else if (i == 0)
                    {
                        strmessage = txt_product_amms.Text + "  " + "  ---- Already we have -- Try a New One";
                        ScriptManager.RegisterClientScriptBlock(btn_product_save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + strmessage + "');</script>", false);
                        _load_products_grid();
                        _load_products_ddl();
                       txt_product_amms.Text = string.Empty;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(btn_product_save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('Some Thing Went Wrong');</script>", false);                     
                        txt_product_amms.Text = string.Empty;
                        _load_products_grid();
                        _load_products_ddl();
                    }
                }
                else
                {
                    string textmess = "Please Enter Text";
                    ScriptManager.RegisterClientScriptBlock(btn_product_save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + textmess + "');</script>", false);
                }
            }
            if (txt_product_amms.Text == "Update")
            {
                if (!string.IsNullOrWhiteSpace(txt_product_amms.Text.ToString()))
                {
                    asset_info ais = new asset_info();
                    ais.Asset_id = Convert.ToInt32(lbl_id.Text);
                    ais.AS_TYPE = txt_product_amms.Text.TrimEnd(' ');


                    String i = adt.Upadte_AssetType(ais);
                    if (i == "1")
                    {

                        string str1message = "New  " + txt_product_amms.Text + "     Was Updated";
                        ScriptManager.RegisterClientScriptBlock(btn_product_save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + str1message + "');</script>", false);
                        btn_product_save_amms.Text = "Save";
                        _load_products_grid();
                        _load_products_ddl();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(btn_product_save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + i + "');</script>", false);
                        btn_product_save_amms.Text = "Save";
                        txt_product_amms.Text = string.Empty;
                        _load_products_grid();
                        _load_products_ddl();
                    }
                }
                else
                {
                    string textmess = "Please Enter Text";
                    ScriptManager.RegisterClientScriptBlock(btn_product_save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + textmess + "');</script>", false);
                }
            }
        }
        /// <summary>
        /// Products Types Insertions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_product_type_Save_amms_Click(object sender, EventArgs e)
        {
             string strptymessage = "";
             if (btn_product_type_Save_amms.Text == "Save")
            {
                if (!string.IsNullOrWhiteSpace(txt_product_type_amms.Text.ToString()))
                {
                    
                    objs.Prfk_id = Convert.ToInt32(ddl_products_asm.SelectedItem.Value);
                    objs.Pr_type_Name = txt_product_type_amms.Text.ToString();
                    string shname = txt_product_type_amms.Text.ToString();
                   // shname.Substring(0, 2);
                    objs.Pr_type_SH_name = shname.Substring(0, 3).ToString();
                    objs.Pr_type_created_by = "ahammed";
                    int i = amdb._insert_product_type_info(objs);
                    if (i == 1)
                    {
                        strptymessage = "Product Type  " + txt_product_type_amms.Text + "  Inserted Sucessfully";
                        ScriptManager.RegisterClientScriptBlock(btn_product_type_Save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + strptymessage + "');</script>", false);
                        txt_product_type_amms.Text = string.Empty;
                        _load_products_types_byid();
                    
                    }
                    else if (i == 0)
                    {

                        ScriptManager.RegisterClientScriptBlock(btn_product_type_Save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('!---!-----Try Again-----');</script>", false);
                      //  _load_brand_ddl();
                        _load_products_types_grid();
                        txt_product_type_amms.Text = string.Empty;
                    }
                     else
                    {
                        ScriptManager.RegisterClientScriptBlock(btn_product_type_Save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('Some Thing was Wrong');</script>", false);
                       // _load_brand_ddl();
                        _load_products_types_grid();
                        txt_product_type_amms.Text = string.Empty;
                    }
                }
                else
                {
                    string textmess = "Please Enter Text"+ lbl_brand_Name.InnerText;
                    ScriptManager.RegisterClientScriptBlock(btn_product_type_Save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + textmess + "');</script>", false);
                }
            }
             else if (btn_product_type_Save_amms.Text == "Update")
            {
                if (!string.IsNullOrWhiteSpace(txt_product_type_amms.Text.ToString()))
                {
                    CPU_Details cd = new CPU_Details();
                    cd.Cpu_brand_id = Convert.ToInt32(ViewState["bm_brand_id"]);
                    cd.CPU_BRAND_MAKE = txt_product_type_amms.Text.ToString();
                    //  cd.CPU_ITEM_CREATEDBY = "ahammed";
                    String i = adt.Upadte_brand_Name_cpu(cd);
                    
                    if (i == "1")
                    {
                        strptymessage = "Brand Name  " + txt_product_type_amms.Text + "  Updated Sucessfully";
                        ScriptManager.RegisterClientScriptBlock(btn_product_type_Save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + strptymessage + "');</script>", false);
                        txt_product_type_amms.Text = string.Empty;
                        btn_product_type_Save_amms.Text = "Save";
                        _load_brand_ddl();
                        _load_brand_grid();                        
                    }
                    else if(i == "0")
                    {
                        ScriptManager.RegisterClientScriptBlock(btn_product_type_Save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('No chages has Done');</script>", false);
                        _load_brand_ddl(); _load_brand_grid();
                        txt_product_type_amms.Text = string.Empty;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(btn_product_type_Save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('Some Thing went Wrong');</script>", false);
                        _load_brand_ddl();
                        txt_product_type_amms.Text = string.Empty;
                    }
                }
                else
                {
                    string textmess = "Please Enter Text";
                    ScriptManager.RegisterClientScriptBlock(btn_product_type_Save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + textmess + "');</script>", false);
                }
            }


        }

        protected void btn_Brand_save_amms_Click(object sender, EventArgs e)
        {
            string strbrandmessage = "";
            if (!string.IsNullOrWhiteSpace(txt_Brand_amms.Text.ToString()))
            {
                objs.Br_name = txt_Brand_amms.Text.ToString().TrimEnd().TrimStart();
                objs.Pr_id = Convert.ToInt32(ddl_products_asm.SelectedItem.Value);
                objs.Prfk_id = Convert.ToInt32(ddl_product_type_amms.SelectedItem.Value);
                objs.Br_createdBy = "Syed ahammed";
                int i = amdb._insert_brands_info(objs);
                if (i == 1)
                {
                    strbrandmessage = "Brand Name  " + txt_product_type_amms.Text + "  Inserted Sucessfully";
                    ScriptManager.RegisterClientScriptBlock(btn_product_type_Save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + strbrandmessage + "');</script>", false);

                  
                    txt_Brand_amms.Text = string.Empty;
                    _load_brands_byids();

                   // _load_brand_model_grid();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(btn_Brand_save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('issue');</script>", false);
                    _load_brands_byids();
                    txt_Brand_amms.Text = string.Empty;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "typething();", true);
            }
        }

        protected void ibtn_products_asm_Click(object sender, ImageClickEventArgs e)
        {
            btn_product_save_amms.Text = "Update";
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
                    txt_product_amms.Text = dt.Rows[0]["type_name"].ToString();
                }

            }
            else
            {
                txt_product_amms.Text = string.Empty;
            }
        }
        protected void ibtn_brand_asm_Click(object sender, ImageClickEventArgs e)
        {
          
          //  btn_product_type_Save.Text = "Update";
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
                    txt_product_amms.Text = dt.Rows[0]["bm_brand"].ToString();
            }
            else
            {
                txt_product_amms.Text = string.Empty;
            }
        }
        protected void ibtn_brand_model_asm_Click(object sender, ImageClickEventArgs e)
        {
            _load_brand_model_grid();
            btn_Brand_save_amms.Text = "Update";
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
                ddl_product_type_amms.SelectedItem.Value = dt.Rows[0]["bbm_brand_id"].ToString();
                txt_Brand_amms.Text = dt.Rows[0]["bbm_model"].ToString();
            }
            else
            {
                txt_Brand_amms.Text = string.Empty;
            }
        }

        protected void gv_products_grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_products_grid.PageIndex = e.NewPageIndex;
            _load_astype_grid();
        }
        protected void gv_products_type_info_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_products_type_info.PageIndex = e.NewPageIndex;
            _load_products_types_byid();
        }
        protected void gv_cpu_brand_info_amms_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_brand_info_amms.PageIndex = e.NewPageIndex;
           // _load_brand_model_grid();
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
                   // ScriptManager.RegisterClientScriptBlock(btn_product_type_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('processor Name Saved Sucessfully');</script>", false);
                    txt_processor_name_asm.Text = string.Empty;
                    _load_processorName_grid();
                }
                else
                {
                   
                  //  ScriptManager.RegisterClientScriptBlock(btn_product_type_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('Try a.... New Processor Name');</script>", false);                   
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
                   // ScriptManager.RegisterClientScriptBlock(btn_product_type_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('processor Name Saved Sucessfully');</script>", false);
                    txt_processor_name_asm.Text = string.Empty;
                    _load_processorName_grid();
                }
                else
                {

                  //  ScriptManager.RegisterClientScriptBlock(btn_product_type_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('Try a.... New Processor Name');</script>", false);
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
                     //   ScriptManager.RegisterClientScriptBlock(btn_product_type_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + i + "');</script>", false);
                        txt_Monitor_name_asm.Text = string.Empty;
                          _load_Monitor_brand();
                    }
                    else
                    {
                      //  ScriptManager.RegisterClientScriptBlock(btn_product_type_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + i + "');</script>", false);
                        _load_Monitor_brand();
                        txt_Monitor_name_asm.Text = string.Empty;
                    }
                }
                else
                {
                    string textmess = "Please Enter Text";
                   // ScriptManager.RegisterClientScriptBlock(btn_product_type_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + textmess + "');</script>", false);
                }
            }
            if (btn_Monitor_asm.Text == "Update")
            {
                //if (!string.IsNullOrWhiteSpace(txt_Asset_type_amms.Text.ToString()))
                //{
                //    asset_info ais = new asset_info();
                //    ais.Asset_id = Convert.ToInt32(lbl_id.Text);
                //    ais.AS_TYPE = txt_Asset_type_amms.Text.TrimEnd(' ');


                //    String i = adt.Upadte_AssetType(ais);
                //    if (i == "1")
                //    {
                //        ScriptManager.RegisterClientScriptBlock(btn_product_type_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + i + "');</script>", false);
                //        txt_Asset_type_amms.Text = string.Empty;
                //        btn_Asset_type_save_amms.Text = "Save";
                //        _load_astype_grid();
                //    }
                //    else
                //    {
                //        ScriptManager.RegisterClientScriptBlock(btn_product_type_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + i + "');</script>", false);
                //        btn_Asset_type_save_amms.Text = "Save";
                //        txt_Asset_type_amms.Text = string.Empty;
                //        _load_astype_grid();
                //    }
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "typething();", true);
                //}
            }
        }
        protected void btn_Monitor_Model_asm_Click(object sender, EventArgs e)
        {
            if (btn_Monitor_Model_asm.Text == "Save")
            {

                if (!string.IsNullOrWhiteSpace(txt_Monitor_Model_asm.Text.ToString()))
                {
                    Monitor_Details md = new Monitor_Details();
                    md.MO_ID = Convert.ToInt32(ddl_MonitorModel_asm.SelectedValue);
                    md.MO_MAKE = txt_Monitor_Model_asm.Text.ToString();
                    md.MO_CREATEDBY = "ahammed";
                    String i = adt.insert_brand_Model_monitor(md);
                    if (i == "Brand Name Inserted Sucessfully")
                    {
                      //  ScriptManager.RegisterClientScriptBlock(btn_product_type_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + i + "');</script>", false);
                        txt_Monitor_Model_asm.Text = string.Empty;
                        _load_Monitor_brand_Model_grid();
                    }
                    else
                    {
                     //   ScriptManager.RegisterClientScriptBlock(btn_product_type_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + i + "');</script>", false);
                        _load_Monitor_brand_Model_grid();
                        txt_Monitor_Model_asm.Text = string.Empty;
                    }
                }
                else
                {
                    string textmess = "Please Enter Text";
                  //  ScriptManager.RegisterClientScriptBlock(btn_product_type_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + textmess + "');</script>", false);
                }
            }
            if (btn_Monitor_asm.Text == "Update")
            {
                //if (!string.IsNullOrWhiteSpace(txt_Asset_type_amms.Text.ToString()))
                //{
                //    asset_info ais = new asset_info();
                //    ais.Asset_id = Convert.ToInt32(lbl_id.Text);
                //    ais.AS_TYPE = txt_Asset_type_amms.Text.TrimEnd(' ');


                //    String i = adt.Upadte_AssetType(ais);
                //    if (i == "1")
                //    {
                //        ScriptManager.RegisterClientScriptBlock(btn_product_type_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + i + "');</script>", false);
                //        txt_Asset_type_amms.Text = string.Empty;
                //        btn_Asset_type_save_amms.Text = "Save";
                //        _load_astype_grid();
                //    }
                //    else
                //    {
                //        ScriptManager.RegisterClientScriptBlock(btn_product_type_Save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + i + "');</script>", false);
                //        btn_Asset_type_save_amms.Text = "Save";
                //        txt_Asset_type_amms.Text = string.Empty;
                //        _load_astype_grid();
                //    }
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "typething();", true);
                //}
            }
        }

        protected void gv_Monitor_barnd_model_asm_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected void gv_Monitor_barnd_asm_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void ddl_products_asm_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  _load_products_grid();
           _load_products_types_byid();


            //objs.Prfk_id = Convert.ToInt32(ddl_products_asm.SelectedItem.Value);
            //DataTable dt = amdb._load_Asset_Products_types_byid(objs);
            //if (dt.Rows.Count > 0)
            //{
            //    gv_products_type_info.DataSource = dt;
            //    gv_products_type_info.DataBind();
            //}
        }

        protected void ddl_product_type_amms_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            _load_products_types_byid();          
        }
        protected void btn_model_save_amms_Click(object sender, EventArgs e)
        {
            if (btn_model_save_amms.Text == "Save")
            {
                if (!string.IsNullOrWhiteSpace(txt_Model_amms.Text.ToString()))
                {
                    objs.Mo_Name = txt_Model_amms.Text.ToString().TrimEnd().TrimStart();
                    objs.Mo_br_id = Convert.ToInt32(ddl_brands_amms.SelectedItem.Value);
                    objs.Mo_created_by = "Ahammed syed";
                    int i = amdb._insert_model_info(objs);
                    string strmessage = "";
                    if (i == 1)
                    {
                        strmessage = "New Model  " + txt_Model_amms.Text + "     Was Inserted";
                        ScriptManager.RegisterClientScriptBlock(btn_model_save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + strmessage + "');</script>", false);
                        txt_Model_amms.Text = string.Empty;
                     //   _load_products_grid();
                     //   _load_products_ddl();

                    }
                    else if (i == 0)
                    {
                        strmessage = txt_Model_amms.Text + "  " + "  ---- Already we have -- Try a New One";
                        ScriptManager.RegisterClientScriptBlock(btn_model_save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + strmessage + "');</script>", false);
                      //  _load_products_grid();
                      //  _load_products_ddl();
                        txt_Model_amms.Text = string.Empty;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(btn_model_save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('Some Thing Went Wrong');</script>", false);
                        txt_Model_amms.Text = string.Empty;
                      //  _load_products_grid();
                      //  _load_products_ddl();
                    }
                }
                else
                {
                    string textmess = "Please Enter Text";
                    ScriptManager.RegisterClientScriptBlock(btn_model_save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + textmess + "');</script>", false);
                }
            }
            if (btn_model_save_amms.Text == "Update")
            {
                if (!string.IsNullOrWhiteSpace(txt_Model_amms.Text.ToString()))
                {
                    asset_info ais = new asset_info();
                    ais.Asset_id = Convert.ToInt32(lbl_id.Text);
                    ais.AS_TYPE = txt_Model_amms.Text.TrimEnd(' ');


                    String i = adt.Upadte_AssetType(ais);
                    if (i == "1")
                    {

                        string str1message = "New  " + txt_Model_amms.Text + "     Was Updated";
                        ScriptManager.RegisterClientScriptBlock(btn_model_save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + str1message + "');</script>", false);
                        btn_model_save_amms.Text = "Save";
                        //_load_products_grid();
                      //  _load_products_ddl();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(btn_model_save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + i + "');</script>", false);
                        btn_model_save_amms.Text = "Save";
                        txt_Model_amms.Text = string.Empty;
                   //     _load_products_grid();
                    //    _load_products_ddl();
                    }
                }
                else
                {
                    string textmess = "Please Enter Text";
                    ScriptManager.RegisterClientScriptBlock(btn_model_save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + textmess + "');</script>", false);
                }
            }
        }

        protected void ddl_brands_amms_SelectedIndexChanged(object sender, EventArgs e)
        {
            _load_model_byids();
        }

        protected void btn_cartridge_amms_Click(object sender, EventArgs e)
        {
            if (btn_cartridge_amms.Text == "Save")
            {
                if (!string.IsNullOrWhiteSpace(txt_cartridge_amms.Text.ToString()))
                {

                    objs.Cat_Model = txt_cartridge_amms.Text.ToString().TrimEnd().TrimStart();
                    objs.Cat_Createdby = "1595";

                  //  objs.Pr_createdby = "Ahammed syed";
                    int i = amdb._insert_asset_cartridge(objs);
                    string strmessage = "";
                    if (i == 1)
                    {
                        strmessage = "New Asset  " + txt_cartridge_amms.Text + " Was Inserted";
                        ScriptManager.RegisterClientScriptBlock(btn_cartridge_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + strmessage + "');</script>", false);
                        txt_cartridge_amms.Text = string.Empty;
                        _load_cartridemodel_grid();
                        
                    }
                    else if (i == 0)
                    {
                        strmessage = txt_cartridge_amms.Text + "  " + "  ---- Already we have -- Try a New One";
                        ScriptManager.RegisterClientScriptBlock(btn_cartridge_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + strmessage + "');</script>", false);
                        
                       txt_cartridge_amms.Text = string.Empty;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(btn_cartridge_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('Some Thing Went Wrong');</script>", false);
                        txt_cartridge_amms.Text = string.Empty;
                        
                    }
                }
                else
                {
                    string textmess = "Please Enter Text";
                    ScriptManager.RegisterClientScriptBlock(btn_cartridge_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + textmess + "');</script>", false);
                }
            }
        }
    }
}