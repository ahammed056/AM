using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AM_EntityLayer;
using AM_DB_Layer;
using System.Data;

    namespace AM.Desktop
    {
        public partial class AddCPU : System.Web.UI.Page
        {
            asset_info ai = new asset_info();
            AM_DB_Tranactions adt = new AM_DB_Tranactions();

            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    _load_dng();
                    _load_Asset_id();
                    _load_processorModel();
                    _load_processorSpeed();
                    _load_cpu_griddata();

                }
            }
        
            protected void ddl_desktop_SelectedIndexChanged(object sender, EventArgs e)
            {
                try
                {
                    if (ddl_desktop.SelectedIndex == 0)
                    {
                        try
                        {
                            Label1.Text = "New Asset Code";
                            p123.Visible = false;
                            PanMain.Visible = false;
                            Panel1.Visible = true; PanelOs.Visible = false;                           
                           
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }

                    else if (ddl_desktop.SelectedIndex == 1)
                    {
                        try
                        {                       
                            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "Cpuview();", true);                            
                            Label1.Text = "CPU";
                            PanMain.Visible = true;
                            p123.Visible = true;
                            Panel1.Visible = false; PanelOs.Visible = false;
                            if (IsPostBack)
                            {
                                _load_brand();
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                    else if (ddl_desktop.SelectedIndex == 2)
                    {
                        try
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "Moniview();", true);
                            PanMain.Visible = true;
                            p123.Visible = false;
                            Panel1.Visible = false; PanelOs.Visible = false;

                            Label1.Text = "Monitor";
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                    else if (ddl_desktop.SelectedIndex == 3)
                    {
                        try
                        {
                            PanMain.Visible = true;
                            p123.Visible = false;
                            Label1.Text = "Mouse";
                            Panel1.Visible = false; PanelOs.Visible = false;

                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    else if (ddl_desktop.SelectedIndex == 4)
                    {
                        try
                        {
                            Panel1.Visible = false;
                            PanMain.Visible = true;
                            p123.Visible = false; PanelOs.Visible = false;
                            Label1.Text = "KeyBoard";

                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                    else if (ddl_desktop.SelectedIndex == 5)
                    {
                        try
                        {
                            PanMain.Visible = true; Panel1.Visible = false;
                            p123.Visible = false; PanelOs.Visible = false;
                            Label1.Text = "RAM";
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                    else if (ddl_desktop.SelectedIndex == 6)
                    {
                        try
                        {
                            PanMain.Visible = true; Panel1.Visible = false;
                            p123.Visible = false; PanelOs.Visible = false;
                            Label1.Text = "HDD";

                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                    else if (ddl_desktop.SelectedIndex == 7)
                    {
                        try
                        {
                            PanMain.Visible = false; Panel1.Visible = false;
                            p123.Visible = false;
                            PanelOs.Visible = true;
                            Label1.Text = "Operating System";
                            if (!IsPostBack)
                            {
                                _load_Asset_id_os();
                            }
                            

                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                    else
                    {
                        try
                        {
                            Label1.Text = "New Asset Code";
                            p123.Visible = false;
                            PanMain.Visible = false;
                            Panel1.Visible = true;
                            PanelOs.Visible = false;
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }

            protected void btn_assetNew_Num_Save_Click(object sender, EventArgs e)
            {
                if (!string.IsNullOrWhiteSpace(txt_assetNew_Number.Text.ToString()))
                {
                    ai.AS_ASSETCODE = txt_assetNew_Number.Text.ToString();
                    ai.AS_TYPE = "Desktop";
                    String i = adt.insertAssertid(ai);

                    if (i == "Asset Code already exists")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "Messagefor();", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "Sucessfor();", true);
                        txt_assetNew_Number.Text = string.Empty;
                        _load_Asset_id();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "typething();", true);
                }                           
            }

            public void _load_Asset_id()
            {
                DataTable dt = adt.view_AssetId();
                ddl_new_Asset_id.DataSource = dt;
                ddl_new_Asset_id.DataTextField = "As_AssetCode";
                ddl_new_Asset_id.DataValueField = "As_Id";
                ddl_new_Asset_id.DataBind();
            }

            public void _load_Asset_id_os()
            {
                DataTable dt = adt.view_AssetId();
                ddl_new_Asset_id_os.DataSource = dt;
                ddl_new_Asset_id_os.DataTextField = "As_AssetCode";
                ddl_new_Asset_id_os.DataValueField = "As_Id";
                ddl_new_Asset_id_os.DataBind();
            }

            public void _load_cpu_griddata()
            {
                DataTable dt = adt.view_Cpu_details();
                cpuinfo.DataSource = dt;
                cpuinfo.DataBind();              
            }

            public void _load_processorModel()
            {
                DataTable dt = adt.view_processorModel_name();
                ddl_processorModel.DataSource = dt;
                ddl_processorModel.DataTextField = "processor_name";
                ddl_processorModel.DataValueField = "Pro_id";
                ddl_processorModel.DataBind();                 
            }

             public void _load_processorSpeed()
            {
                DataTable dt = adt.view_processor_Speed();
                ddl_processor_speed.DataSource = dt;
                ddl_processor_speed.DataTextField = "processor_Speed";
                ddl_processor_speed.DataValueField = "Pro_id";
                ddl_processor_speed.DataBind();                 
            }


            

            public void _load_brand()
            {
                DataTable dt = adt.view_Cpu_brand();
                ddl_ad_barnd.DataSource = dt;
                ddl_ad_barnd.DataTextField = "bm_brand";
                ddl_ad_barnd.DataValueField = "bm_id";
                ddl_ad_barnd.DataBind();
            }

            public void _load_dng()
            {
                DataTable dt = adt.view_dng_details();
                ddl_ad_DNG.DataSource = dt;
                ddl_ad_DNG.DataTextField = "dng_name";
                ddl_ad_DNG.DataValueField = "dng_id";
                ddl_ad_DNG.DataBind();
            }

            protected void ddl_ad_barnd_SelectedIndexChanged(object sender, EventArgs e)
            {                
                DataTable dt = adt.view_Cpu_model(ddl_ad_barnd.SelectedItem.Value);
                ddl_ad_brandmodel.DataSource = dt;
                ddl_ad_brandmodel.DataTextField = "bm_model";
                ddl_ad_brandmodel.DataValueField = "bm_brand_id";
                ddl_ad_brandmodel.DataBind();             
            }

            protected void btn_ad_save_Click(object sender, EventArgs e)
            {
                if (ddl_desktop.SelectedIndex == 1)
                {
                    CPU_Details jcd = new CPU_Details();
                    jcd.CPU_ASSETCODE = ddl_new_Asset_id.SelectedItem.Text.ToString();
                    jcd.CPU_PRODUCT_NUMBER=txt_ad_Product_Number.Text.ToString();
                    jcd.CPU_SERIAL_NUMBER= txt_ad_Serial_Number.Text.ToString();
                    jcd.CPU_PR_NUMBER= txt_ad_PR_Number.Text.ToString();
                    jcd.CPU_VOUCHER_NUMBER= txt_ad_Voucher_Number.Text.ToString();
                    jcd.CPU_BRAND_MAKE= ddl_ad_barnd.SelectedItem.Value;
                    jcd.CPU_MODEL= ddl_ad_brandmodel.SelectedItem.Value;
                    jcd.CPU_RECEIVE_DATE= Convert.ToDateTime(txt_ad_Receive_Date.Text);
                    jcd.CPU_WARRANTY_START_DATE= Convert.ToDateTime(txt_ad_Warranty_Start_Date.Text);
                    jcd.CPU_WARRANTY_END_DATE= Convert.ToDateTime(txt_ad_Warranty_End_Date.Text);
                    jcd.CPU_IP_ADDRESS= txt_ad_ip_address.Text.ToString();
                    jcd.CPU_MAC_ID = txt_ad_mac_address.Text.ToString();
                    jcd.CPU_HOST_NAME=txt_ad_HostName.Text.ToString();
                    jcd.CPU_DOMAIN_NAME_GROUP = ddl_ad_DNG.SelectedItem.Value;
                    jcd.CPU_PROCESSOR_SERIALNUMBER=txt_ad_Serial_Number.Text.ToString();
                    jcd.CPU_PROCESSOR_MODEL = ddl_processorModel.SelectedItem.Value;                   
                    jcd.CPU_PROCESSOR_SPEED= ddl_processor_speed.SelectedItem.Value;
                    jcd.CPU_ITEM_CREATEDBY="ahammed";
                    AM_DB_Tranactions adt = new AM_DB_Tranactions();
                    string cpu = adt.insertCpuDetails(jcd);
                    if (cpu == "Asset Code already exists")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "cpuRecninserted();", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "cpuRecinserted();", true);
                        _load_cpu_griddata();
                    }

                }
            }


        }
    }
