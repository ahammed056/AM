using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AM_EntityLayer;
using AM_DB_Layer;
using System.Data;
using System.Management;
using System.Management.Instrumentation;
using Microsoft.Win32;
using System.Net.NetworkInformation;
using System.Collections;



namespace AM.Desktop
{
    public partial class AddCPU : System.Web.UI.Page
    {
        cpu_insertions cui = new cpu_insertions();

        protected void Page_PreLoad(object sender, EventArgs e)
        {



        }


        public void loaddates()
        {
            txt_ad_Receive_Date.Text = DateTime.Now.ToString("yyyy-MM-ddThh:mm");
            txt_ad_Warranty_Start_Date.Text = DateTime.Now.ToString("yyyy-MM-ddThh:mm");
            DateTime dts = DateTime.Now.AddYears(1);
            txt_ad_Warranty_End_Date.Text = dts.ToString("yyyy-MM-ddThh:mm");
        }
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                _load_view_desktop_ddl();
               
            }
        }

        public void _load_brand()
        {
            AM_DB_Tranactions adt = new AM_DB_Tranactions();
            CPU_Details cu = new CPU_Details();
            DataTable dt = adt.view_brands_by_grids();
            ddl_ad_brand.DataSource = dt;
            ddl_ad_brand.DataTextField = "bm_brand";
            ddl_ad_brand.DataValueField = "bm_id";
            ddl_ad_brand.DataBind();
        }
        protected void ddl_ad_brand_SelectedIndexChanged(object sender, EventArgs e)
        {
            AM_DB_Tranactions adt = new AM_DB_Tranactions();
            DataTable dt = adt.view_Cpu_model(ddl_ad_brand.SelectedItem.Value);
            ddl_ad_brand_model.DataSource = dt;
            ddl_ad_brand_model.DataTextField = "bbm_model";
            ddl_ad_brand_model.DataValueField = "bbm_brand_id";
            ddl_ad_brand_model.DataBind();
        }

       

        protected void ddl_desktop_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                loaddates();
                if (ddl_desktop.SelectedIndex == 0)
                {
                    try
                    {
                        Label1.Text = "New Asset Code";
                        Response.Redirect("~/default.aspx");
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
                        // Panel1.Visible = false;
                        PanelOs.Visible = false;
                       
                       // ddl_new_Asset_id.DataSource = dt;
                       // ddl_new_Asset_id.DataTextField = "As_AssetCode";
                       // ddl_new_Asset_id.DataValueField = "As_Id";
                       // ddl_new_Asset_id.DataBind();
                       // ddl_desktop.Items.Insert(0, new ListItem("Choose Asset Code", "0"));
                        if (IsPostBack)
                        {
                            if (ddl_desktop.SelectedIndex != 0)
                            {
                                _load_Asset_code();
                            }

                           //// txt_ad_mac_address.Text = String.IsNullOrEmpty(txt_ad_mac_address.Text) ? cpu_transactions.getIP() : "";
                           // txt_ad_mac_address.Text = String.IsNullOrEmpty(txt_ad_mac_address.Text) ? cpu_transactions.GetMACAddress() : "";
                           // txt_ad_ip_address.Text = cpu_transactions.GetAllLocalIPv4(NetworkInterfaceType.Ethernet).FirstOrDefault().ToString();
                           // txt_ad_brand.Text = cpu_transactions.Getbarnd();
                           // txt_ad_model.Text = cpu_transactions.GetModel();
                           // txt_ad_Product_Number.Text = cpu_transactions.GetServiceTag();
                           // txt_ad_HostName.Text = System.Environment.MachineName;
                           // txt_ad_processor.Text = cpu_transactions.Getprocessor();
                           // txt_ad_hdd_model.Text = cpu_transactions.gethddmodel();
                           // txt_ad_hdd_serial.Text = cpu_transactions.gethddSerial();
                           // ArrayList items = cpu_transactions.GetRamInformation();
                        
                           // GridView1.DataSource = items;
                          //  GridView1.DataBind();

                            //foreach (var i in items)
                            //{
                                
                            //   // txt_ad_ram_model.Text = Items.Values[0];
                            //   // txt_ad_ram_size.Text = i[1].ToString();
                            //}
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
                        // Panel1.Visible = false; 
                        PanelOs.Visible = false;
                        Label1.Text = "Monitor";
                        if (ddl_desktop.SelectedIndex != 0)
                        {
                            _load_Asset_code();
                        }
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
                        //Panel1.Visible = false; 
                        PanelOs.Visible = false;

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
                        // Panel1.Visible = false;
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
                        PanMain.Visible = true; //Panel1.Visible = false;
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
                        PanMain.Visible = true;// Panel1.Visible = false;
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
                        PanMain.Visible = false;// Panel1.Visible = false;
                        p123.Visible = false;
                        PanelOs.Visible = true;
                        Label1.Text = "Operating System";
                        if (!IsPostBack)
                        {
                           // _load_Asset_id_os();
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
                        //  Panel1.Visible = true;
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

        public int _load_view_desktop_ddl()
        {
            int ji = 105;
            DataTable dt = cui.loaddesktopdataddl(ji);
            ddl_desktop.DataSource = dt;
            ddl_desktop.DataTextField = "bm_brand";
            ddl_desktop.DataValueField = "BM_id";
            ddl_desktop.DataBind(); 
            ddl_desktop.Items.Insert(0, new ListItem("Add New Asset", "0"));
            return ji;
        }


        public void _load_Asset_code()
        {
            assets_info ass = new assets_info();
            ass.AS_TYPE = ddl_desktop.SelectedItem.Text.ToString();
            cpu_insertions cs = new cpu_insertions();
            DataTable dt = cs.load_Assetcode_by_type(ass);
            ddl_new_Asset_id.DataSource = dt;
            ddl_new_Asset_id.DataTextField = "As_AssetCode";
            ddl_new_Asset_id.DataValueField = "As_Id";
            ddl_new_Asset_id.DataBind();
            ddl_new_Asset_id.Items.Insert(0, new ListItem("Asset Code", "0"));
        }
   

        protected void btn_ad_save_Click(object sender, EventArgs e)
        {
            if (ddl_desktop.SelectedIndex == 1)
            {
                _load_brand();
                if (ddl_new_Asset_id.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "typething()();", true);

                }
                else
                {
                    
                    amcpu amct = new amcpu();
                    amct.CU_ASSETCODE = ddl_new_Asset_id.SelectedItem.Text.ToString();
                    amct.CU_MAKE = ddl_ad_brand.SelectedValue;
                    amct.CU_MODEL = ddl_ad_brand_model.SelectedValue;
                    amct.CU_SERVICETAG = txt_ad_Product_Number.Text.ToString();
                    amct.CU_EXPRESS_SERVICETAG = txt_ad_Serial_Number.Text.ToString();
                    amct.CU_PURCHASE_NUMBER = txt_ad_PR_Number.Text.ToString();
                    amct.CU_VOUCHER_NUMBER = txt_ad_Voucher_Number.Text.ToString();
                    amct.CU_RECIEVED_DATE = Convert.ToDateTime(txt_ad_Receive_Date.Text);
                    amct.CU_WARRANTY_STARTDATE = Convert.ToDateTime(txt_ad_Warranty_Start_Date.Text);
                    amct.CU_WARRANTY_ENDDATE = Convert.ToDateTime(txt_ad_Warranty_End_Date.Text);


                    // below transaction differ to different load options
                    amct.CU_PROCESSOR = txt_ad_processor.Text;
                    amct.CU_IPADDRESS = txt_ad_ip_address.Text;
                    amct.CU_MAC = txt_ad_mac_address.Text;
                    amct.CU_HOST = txt_ad_HostName.Text;
                    amct.CU_HDD_MODEL = txt_ad_hdd_model.Text;
                    amct.CU_HDD_SERIAL = txt_ad_hdd_serial.Text;
                    amct.CU_HDD_SIZE = txt_ad_hdd_size.Text;
                    amct.Createdby = "";
                    amct.Createdtime = DateTime.Now;
                    cpu_insertions ci = new cpu_insertions();

                    int cpu = ci.insertCpuDetails(amct);
                    if (cpu == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "Messagefor();", true);
                    }
                    else if (cpu == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "cpuRecinserted();", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "cpuRecninserted();", true);
                    }
                }
            }
            else if (ddl_desktop.SelectedIndex == 2)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "cpuRecinserted();", true);
            }
            else
            {
            }

        }

     


        #region Monitor_Details_laoads

       // void load_monitor_brands()
       // {
           // DataTable dt = adt.view_dng_details();
          //  ddl_ad_DNG.DataSource = dt;
          //  ddl_ad_DNG.DataTextField = "dng_name";
          //  ddl_ad_DNG.DataValueField = "dng_id";
         //   ddl_ad_DNG.DataBind();
      //  }


	    #endregion
    }

  
}

//protected void ddl_ad_barnd_SelectedIndexChanged(object sender, EventArgs e)
//{
//    DataTable dt = adt.view_Cpu_model(ddl_ad_barnd.SelectedItem.Value);
//    ddl_ad_brandmodel.DataSource = dt;
//    ddl_ad_brandmodel.DataTextField = "bbm_model";
//    ddl_ad_brandmodel.DataValueField = "bbm_brand_id";
//    ddl_ad_brandmodel.DataBind();
//}



//if (ddl_ad_brandmodel.SelectedIndex == -1)
//{
//    ddl_ad_brandmodel.Items.Add(new ListItem("Null", "0"));
//}
//else
//{
//    jcd.CPU_MODEL = ddl_ad_brandmodel.SelectedItem.Value;
//}



    //public void _load_Asset_id_os()
    //    {
    //        DataTable dt = adt.view_AssetId();
    //        ddl_new_Asset_id_os.DataSource = dt;
    //        ddl_new_Asset_id_os.DataTextField = "As_AssetCode";
    //        ddl_new_Asset_id_os.DataValueField = "As_Id";
    //        ddl_new_Asset_id_os.DataBind();
    //    }


    //    public void _load_processorModel()
    //    {
    //        DataTable dt = adt.view_processorModel_name();
    //        ddl_processorModel.DataSource = dt;
    //        ddl_processorModel.DataTextField = "processor_name";
    //        ddl_processorModel.DataValueField = "processor_id";
    //        ddl_processorModel.DataBind();
    //    }

    //    public void _load_processorSpeed()
    //    {
    //        DataTable dt = adt.view_processor_Speed();
    //        ddl_processor_speed.DataSource = dt;
    //        ddl_processor_speed.DataTextField = "processor_Speed";
    //        ddl_processor_speed.DataValueField = "processor_speed_id";
    //        ddl_processor_speed.DataBind();
    //    }


        

    //    public void _load_dng()
    //    {
    //        DataTable dt = adt.view_dng_details();
    //        ddl_ad_DNG.DataSource = dt;
    //        ddl_ad_DNG.DataTextField = "dng_name";
    //        ddl_ad_DNG.DataValueField = "dng_id";
    //        ddl_ad_DNG.DataBind();
    //    }