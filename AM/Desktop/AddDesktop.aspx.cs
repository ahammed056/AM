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
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Configuration;

namespace AM.Desktop
{
    public partial class AddCPU : System.Web.UI.Page
    {
        MySqlAsmObjs objs = new MySqlAsmObjs();
        MysqlAsMDBCS amdb = new MysqlAsMDBCS();
        cpu_insertions cui = new cpu_insertions();

        public void loaddates()
        {
            txt_ad_Receive_Date.Text = DateTime.Now.ToString("yyyy-MM-ddThh:mm");
            txt_ad_Warranty_Start_Date.Text = DateTime.Now.ToString("yyyy-MM-ddThh:mm");
            DateTime dts = DateTime.Now.AddYears(1);
            txt_ad_Warranty_End_Date.Text = dts.ToString("yyyy-MM-ddThh:mm");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewState["ids"] = Request.QueryString["key"].ToString();
            if (!IsPostBack)
            {
               
               //int IDSSS = Convert.ToInt32(ViewState["ids"]); 
                _load_view_desktop_ddl();
                _load_Asset_info();
            
            }
        }


        protected void ddl_ad_brand_SelectedIndexChanged(object sender, EventArgs e)
        {
            objs.Mo_br_id = Convert.ToInt32(ddl_ad_brand.SelectedItem.Value);
            DataTable dt = amdb._load_Asset_models_byid(objs);
            ddl_ad_brand_model.DataSource = dt;
            ddl_ad_brand_model.DataTextField = "mo_Name";
            ddl_ad_brand_model.DataValueField = "mo_id";
            ddl_ad_brand_model.DataBind();

        }

        protected void ddl_desktop_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (ddl_desktop.SelectedItem.Text.ToString() == "CPU")
                {
                    p123.Visible = true; P124.Visible = false;
                }
                if (ddl_desktop.SelectedItem.Text.ToString() == "printer1")
                {
                    P124.Visible = true; p123.Visible = false;
                }

                
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
                        Label1.Text = ddl_desktop.SelectedItem.Text;
                        PanMain.Visible = true;
                        if (ddl_desktop.SelectedItem.Text.ToString() == "CPU")
                        {
                            p123.Visible = true;
                        }
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
                                _load_view_brands_ddl();
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
                        Label1.Text = ddl_desktop.SelectedItem.Text;
                        if (ddl_desktop.SelectedIndex != 0)
                        {
                            _load_Asset_code();
                            _load_view_brands_ddl();
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
                        Label1.Text = ddl_desktop.SelectedItem.Text;
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
                        Label1.Text = "Hard disk";

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
                        Label1.Text = ddl_desktop.SelectedItem.Text;
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

        public void _load_view_brands_ddl()
        {
            objs.Pr_id = Convert.ToInt32(ViewState["ids"]);
            objs.Pr_type_id = Convert.ToInt32(ddl_desktop.SelectedValue);
            DataTable dt = amdb._load_Asset_brands_byprptrid(objs);
            ddl_ad_brand.DataSource = dt;
            ddl_ad_brand.DataTextField = "br_name";
            ddl_ad_brand.DataValueField = "br_id";
            ddl_ad_brand.DataBind();
            ddl_ad_brand.Items.Insert(0, new ListItem("Select", "0"));
        }

        public void _load_view_desktop_ddl()
        {
            DataTable dt = loadpagedata();
            ddl_desktop.DataSource = dt;
            ddl_desktop.DataTextField = "pr_type_name";
            ddl_desktop.DataValueField = "pr_type_id";
            ddl_desktop.DataBind();
            ddl_desktop.Items.Insert(0, new ListItem("-- Select type --", "0"));
        }

        public DataTable loadpagedata()
        {
            int ji = Convert.ToInt32(ViewState["ids"]);
            objs.Prfk_id = Convert.ToInt32(ViewState["ids"]);
            DataTable dt = amdb._load_Asset_Products_types_byid(objs);
            return dt;
        }

        public void _load_Asset_code()
        {
            objs.Pr_id = Convert.ToInt32(ViewState["ids"]);
            objs.Pr_type_id = Convert.ToInt32(ddl_desktop.SelectedValue);
            DataTable dt = amdb._view_assetCode_info_by_pr_and_prt_id(objs);
            ddl_new_Asset_id.DataSource = dt;
            ddl_new_Asset_id.DataTextField = "As_AssetCode";
            ddl_new_Asset_id.DataValueField = "ASId";
            ddl_new_Asset_id.DataBind();
            ddl_new_Asset_id.Items.Insert(0, new ListItem("Asset Code", "0"));
        }

        protected void btn_ad_save_Click(object sender, EventArgs e)
        {


            if (ddl_desktop.SelectedItem.Text == "printer1")
            {
                objs.At_type_id = Convert.ToInt32(ViewState["ids"]);
                objs.At_subtype_id = Convert.ToInt32(ddl_desktop.SelectedValue);
                objs.At_model_id = Convert.ToInt32(ddl_ad_brand_model.SelectedValue);
                objs.At_aseet_code_id = Convert.ToInt32(ddl_new_Asset_id.SelectedValue);
                objs.At_Assetcode = ddl_new_Asset_id.SelectedItem.Text.ToString();
                objs.At_productNumber = txt_ad_Product_Number.Text.ToString().Trim();
                objs.At_purchaseNumber = txt_ad_PR_Number.Text.ToString().Trim();
                objs.At_SerialNumber = txt_ad_Serial_Number.Text.ToString().Trim();
                objs.At_voucherNumber = txt_ad_Voucher_Number.Text.ToString().Trim();
                objs.At_receivedDate = Convert.ToDateTime(txt_ad_Receive_Date.Text.ToString());
                objs.At_wsd = Convert.ToDateTime(txt_ad_Warranty_Start_Date.ToString());
                objs.At_wed = Convert.ToDateTime(txt_ad_Warranty_End_Date.ToString());
                objs.At_cby = "1595";



                // objs.At_brandMake_id=Convert.ToInt32(ddl_ad_brand.SelectedValue);
                // objs.at
                                objs.Pr_createdby = "Ahammed syed";
                int i = amdb._insert_Asset_full_info(objs);
                //string strmessage = "";
                if (i == 1)
                {
                    //        strmessage = "New Asset  " + txt_product_amms.Text + "     Was Inserted";
                    //      ScriptManager.RegisterClientScriptBlock(btn_product_save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + strmessage + "');</script>", false);


                }
                else if (i == 0)
                {
                    //strmessage = txt_product_amms.Text + "  " + "  ---- Already we have -- Try a New One";
                    //ScriptManager.RegisterClientScriptBlock(btn_product_save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + strmessage + "');</script>", false);
                    //_load_products_grid();
                    //_load_products_ddl();
                    //txt_product_amms.Text = string.Empty;
                }
                else
                {
                    //ScriptManager.RegisterClientScriptBlock(btn_product_save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('Some Thing Went Wrong');</script>", false);
                    //txt_product_amms.Text = string.Empty;
                    //_load_products_grid();
                    //_load_products_ddl();
                }
            }
            else
            {
                //string textmess = "Please Enter Text";
                //ScriptManager.RegisterClientScriptBlock(btn_product_save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + textmess + "');</script>", false);
            }


            if (ddl_desktop.SelectedItem.Text == "cpu")
            {

                //  objs.Pr_Name = txt_product_amms.Text.ToString().TrimEnd().TrimStart();
                objs.Pr_createdby = "Ahammed syed";
                int i = amdb._insert_product_info(objs);
                string strmessage1 = "";
                if (i == 1)
                {
                    // strmessage = "New Asset  " + txt_product_amms.Text + "     Was Inserted";
                    //  ScriptManager.RegisterClientScriptBlock(btn_product_save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + strmessage + "');</script>", false);
                }

                else
                {
                    string textmessage1 = "Please Enter Text";
                    //   ScriptManager.RegisterClientScriptBlock(btn_product_save_amms, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + textmess + "');</script>", false);
                }
            }
        }
        /// <summary>
        /// insert in to printer///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_ad1_save_Click(object sender, EventArgs e)
        {
            if (ddl_desktop.SelectedItem.Text == "printer1")
            {
                int ids = 0;
                ids = Convert.ToInt32(ViewState["ids"]);
                objs.At_type_id = ids;
                objs.At_subtype_id = Convert.ToInt32(ddl_desktop.SelectedValue);
                objs.At_model_id = 1;
                objs.At_aseet_code_id = Convert.ToInt32(ddl_new_Asset_id.SelectedValue);
                objs.At_Assetcode = ddl_new_Asset_id.SelectedItem.Text.ToString();
                objs.At_productNumber = txt_ad_Product_Number.Text.ToString().Trim();
                objs.At_purchaseNumber = txt_ad_PR_Number.Text.ToString().Trim();
                objs.At_SerialNumber = txt_ad_Serial_Number.Text.ToString().Trim();
                objs.At_voucherNumber = txt_ad_Voucher_Number.Text.ToString().Trim();
                objs.At_receivedDate = Convert.ToDateTime(txt_ad_Receive_Date.Text.ToString());
                objs.At_wsd = Convert.ToDateTime(txt_ad_Warranty_Start_Date.Text);
                objs.At_wed = Convert.ToDateTime(txt_ad_Warranty_End_Date.Text);
                objs.At_cby = "1595";
                
                //objs.Pr_createdby = "Ahammed syed";
                int i = amdb._insert_Asset_full_info(objs);
                //string strmessage = "New Asset Was Inserted";
                strmessage = "New Asset Was Inserted";
                if (i == 1)
                {
                    //int i = amdb._insert_Asset_printer_info(objs);
                    //string strmessage = "";
                    strmessage = "New Asset Was Inserted";
                    _load_Asset_info();
                   // ScriptManager.RegisterClientScriptBlock(btn_ad1_save, this.GetType(), "AlertMsg", "<script language='javascript'>alert('" + strmessage + "');</script>", false);


                }
            }
        }
        
        public void _load_Asset_info()
        {
            DataTable dt = amdb._load_Asset_Fullinfo();
            gv_Assetinfo_ad.DataSource = dt;
            gv_Assetinfo_ad.DataBind();  
        }
        
        public void cleardetails()
        {
            txt_ad_hdd_model.Text = string.Empty;
            txt_ad_PR_Number.Text = string.Empty;
            txt_ad_Product_Number.Text = string.Empty;
            txt_ad_Serial_Number.Text = string.Empty;
            txt_ad_Voucher_Number.Text = string.Empty;
           
        }
        public bool CheckValidations()
        {
            if(txt_ad_PR_Number.Text.ToString().Trim().Replace("'","")=="")
            {

                strmessage = "Purchase Number Can't be Empty.";
                txt_ad_PR_Number.Focus();
                return false;
            }
            else if (txt_ad_PR_Number.Text.ToString().Trim().Replace("'", "") == "")
            {
                strmessage = "Enter Purchase Number.";
                txt_ad_PR_Number.Focus();
                return false;
            }
            else if (txt_ad_Product_Number.Text == "")
            {
                strmessage= "Enter Product Number.";
                txt_ad_Product_Number.Focus();
                return false;
            }
            else if (txt_ad_Serial_Number.Text.ToString().Trim().Replace("'", "") == "")
            {
                strmessage="Enter Serial No.";
                txt_ad_Serial_Number.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txt_ad_Voucher_Number.Text))
            {
                
                strmessage= "Enter Voucher No.";
                txt_ad_Voucher_Number.Focus();
                return false;
            }
            

            return true;
        }


        public string strmessage { get; set; }
    }
    
}



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


        

    ////    public void _load_dng()
    ////    {
    ////        DataTable dt = adt.view_dng_details();
    ////        ddl_ad_DNG.DataSource = dt;
    ////        ddl_ad_DNG.DataTextField = "dng_name";
    ////        ddl_ad_DNG.DataValueField = "dng_id";
    ////        ddl_ad_DNG.DataBind();
    ////    }




            
    //        if (ddl_desktop.SelectedIndex == 1)
    //        {
    //          //  _load_brand();
    //            if (ddl_new_Asset_id.SelectedIndex == 0)
    //            {
    //                ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "typething()();", true);

    //            }
    //            else
    //            {
                    
    //                //amcpu amct = new amcpu();
    //                //amct.CU_ASSETCODE = ddl_new_Asset_id.SelectedItem.Text.ToString();
    //                //amct.CU_MAKE = ddl_ad_brand.SelectedValue;
    //                //amct.CU_MODEL = ddl_ad_brand_model.SelectedValue;
    //                //amct.CU_SERVICETAG = txt_ad_Product_Number.Text.ToString();
    //                //amct.CU_EXPRESS_SERVICETAG = txt_ad_Serial_Number.Text.ToString();
    //                //amct.CU_PURCHASE_NUMBER = txt_ad_PR_Number.Text.ToString();
    //                //amct.CU_VOUCHER_NUMBER = txt_ad_Voucher_Number.Text.ToString();
    //                //amct.CU_RECIEVED_DATE = Convert.ToDateTime(txt_ad_Receive_Date.Text);
    //                //amct.CU_WARRANTY_STARTDATE = Convert.ToDateTime(txt_ad_Warranty_Start_Date.Text);
    //                //amct.CU_WARRANTY_ENDDATE = Convert.ToDateTime(txt_ad_Warranty_End_Date.Text);

    //                // below transaction differ to different load options
    //                //amct.CU_PROCESSOR = txt_ad_processor.Text;
    //                //amct.CU_IPADDRESS = txt_ad_ip_address.Text;
    //                //amct.CU_MAC = txt_ad_mac_address.Text;
    //                //amct.CU_HOST = txt_ad_HostName.Text;
    //                //amct.CU_HDD_MODEL = txt_ad_hdd_model.Text;
    //                //amct.CU_HDD_SERIAL = txt_ad_hdd_serial.Text;
    //                //amct.CU_HDD_SIZE = txt_ad_hdd_size.Text;
    //                //amct.Createdby = "";
    //                //amct.Createdtime = DateTime.Now;
    //                //cpu_insertions ci = new cpu_insertions();

    //                //int cpu = ci.insertCpuDetails(amct);
    //                //if (cpu == 0)
    //                //{
    //                //    ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "Messagefor();", true);
    //                //}
    //                //else if (cpu == 1)
    //                //{
    //                //    ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "cpuRecinserted();", true);
    //                //}
    //                //else
    //                //{
    //                //    ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "cpuRecninserted();", true);
    //                //}
    //            }
    //        }
    //        else if (ddl_desktop.SelectedIndex == 2)
    //        {
    //            ScriptManager.RegisterStartupScript(this, GetType(), "msgbox", "cpuRecinserted();", true);
    //        }
    //        else
    //        {
    //        }

    //    }

     


    //}