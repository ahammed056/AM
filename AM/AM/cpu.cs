using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Management;
using System.Management.Instrumentation;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Collections;
using System.Net;
using System.Configuration;

namespace AM
{
    public class assets_info
    {
        public int Asset_id { get; set; }
        private String as_assetcode; public String AS_ASSETCODE { get { return as_assetcode; } set { as_assetcode = value; } }
        private String as_type; public String AS_TYPE { get { return as_type; } set { as_type = value; } }
        private Boolean as_isactive; public Boolean AS_ISACTIVE { get { return as_isactive; } set { as_isactive = value; } }
        private String as_createdby; public String AS_CREATEDBY { get { return as_createdby; } set { as_createdby = value; } }
        private DateTime as_createdtime; public DateTime AS_CREATEDTIME { get { return as_createdtime; } set { as_createdtime = value; } }
    }
    
     public class userdetails
        {
            string createdby;

            public string Createdby
            {
                get { return createdby; }
                set { createdby = value; }
            }
            DateTime createdtime;

            public DateTime Createdtime
            {
                get { return createdtime; }
                set { createdtime = value; }
            }

            bool isactive;

            public bool Isactive
            {
                get { return isactive; }
                set { isactive = value; }
            }
        }
     public class amcpu:userdetails
    {
        private Int32 cu_id; public Int32 CU_ID { get { return cu_id; } set { cu_id = value; } }
        private String cu_assetcode; public String CU_ASSETCODE { get { return cu_assetcode; } set { cu_assetcode = value; } }
        private String cu_host; public String CU_HOST { get { return cu_host; } set { cu_host = value; } }
        private String cu_make; public String CU_MAKE { get { return cu_make; } set { cu_make = value; } }
        private String cu_model; public String CU_MODEL { get { return cu_model; } set { cu_model = value; } }
        private String cu_mac; public String CU_MAC { get { return cu_mac; } set { cu_mac = value; } }
        private String cu_ipaddress; public String CU_IPADDRESS { get { return cu_ipaddress; } set { cu_ipaddress = value; } }
        private String cu_processor; public String CU_PROCESSOR { get { return cu_processor; } set { cu_processor = value; } }
        private String cu_servicetag; public String CU_SERVICETAG { get { return cu_servicetag; } set { cu_servicetag = value; } }
        private String cu_express_servicetag; public String CU_EXPRESS_SERVICETAG { get { return cu_express_servicetag; } set { cu_express_servicetag = value; } }
        private String cu_hdd_model; public String CU_HDD_MODEL { get { return cu_hdd_model; } set { cu_hdd_model = value; } }
        private String cu_hdd_serial; public String CU_HDD_SERIAL { get { return cu_hdd_serial; } set { cu_hdd_serial = value; } }
        private String cu_hdd_size; public String CU_HDD_SIZE { get { return cu_hdd_size; } set { cu_hdd_size = value; } }
        private String cu_purchase_number; public String CU_PURCHASE_NUMBER { get { return cu_purchase_number; } set { cu_purchase_number = value; } }
        private String cu_voucher_number; public String CU_VOUCHER_NUMBER { get { return cu_voucher_number; } set { cu_voucher_number = value; } }
        private DateTime cu_recieved_date; public DateTime CU_RECIEVED_DATE { get { return cu_recieved_date; } set { cu_recieved_date = value; } }
        private DateTime cu_warranty_startdate; public DateTime CU_WARRANTY_STARTDATE { get { return cu_warranty_startdate; } set { cu_warranty_startdate = value; } }
        private DateTime cu_warranty_enddate; public DateTime CU_WARRANTY_ENDDATE { get { return cu_warranty_enddate; } set { cu_warranty_enddate = value; } }
        private String cu_created_by; public String CU_CREATED_BY { get { return cu_created_by; } set { cu_created_by = value; } }
        private DateTime cu_created_time; public DateTime CU_CREATED_TIME { get { return cu_created_time; } set { cu_created_time = value; } }
        private Boolean cu_isactive; public Boolean CU_ISACTIVE { get { return cu_isactive; } set { cu_isactive = value; } }
        private Boolean cu_isrepaired; public Boolean CU_ISREPAIRED { get { return cu_isrepaired; } set { cu_isrepaired = value; } }
    }
     public class cpu_transactions
     {

         /// <summary>
         /// To get the mac Address
         /// </summary>
         /// <returns></returns>
         public static string GetMACAddress()
         {
             ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
             ManagementObjectCollection moc = mc.GetInstances();
             string MACAddress = String.Empty;
             foreach (ManagementObject mo in moc)
             {
                 if (MACAddress == String.Empty)
                 {
                     if ((bool)mo["IPEnabled"] == true) MACAddress = mo["MacAddress"].ToString();
                 }
                 mo.Dispose();
             }

             MACAddress = MACAddress.Replace(":", "");
             return MACAddress;
         }
         /// <summary>
         /// to get the ip Address
         /// </summary>
         /// <param name="_type"></param>
         /// <returns></returns>
         public static string[] GetAllLocalIPv4(NetworkInterfaceType _type)
         {
             List<string> ipAddrList = new List<string>();
             foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
             {
                 if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                 {
                     foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                     {
                         if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                         {
                             ipAddrList.Add(ip.Address.ToString());
                         }
                     }
                 }
             }
             return ipAddrList.ToArray();
         }
         /// <summary>
         /// To get the Product Number
         /// </summary>
         /// <returns></returns>
         /// 
         public static string GetServiceTag()
         {
             string servicetag = "UNKNOWN";

             ManagementClass wmi = new ManagementClass("Win32_Bios");
             foreach (ManagementObject bios in wmi.GetInstances())
             {
                 servicetag = bios.Properties["Serialnumber"].Value.ToString().Trim();
             }
             return servicetag;
         }
         /// <summary>
         /// Get the cpu model
         /// </summary>
         /// <returns></returns>
         public static string GetModel()
         {
             string model = "UNKNOWN";

             ManagementClass wmi = new ManagementClass("Win32_ComputerSystem");
             foreach (ManagementObject computer in wmi.GetInstances())
             {
                 model = computer.Properties["Model"].Value.ToString().Trim();
             }
             return model;
         }
         /// <summary>
         /// Get Barnd of CPU BOX
         /// </summary>
         /// <returns></returns>
         public static string Getbarnd()
         {
             string brand = "UNKNOWN";
             ManagementClass wmi = new ManagementClass("Win32_ComputerSystem");
             ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
             ManagementObjectCollection moc = mc.GetInstances();
             if (moc.Count != 0)
             {

                 foreach (ManagementObject mo in mc.GetInstances())
                 {
                    // label1.Text = System.Environment.MachineName;
                     brand = mo["Manufacturer"].ToString();
                 }
             }
             return brand;
         }
         /// <summary>
         /// Get the procesor information         
         /// </summary>
         /// <returns></returns>
         public static string Getprocessor()
         {
             string ComputerName = "localhost";
             ManagementScope Scope;
             Scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", ComputerName), null);
             Scope.Connect();
             ObjectQuery Query = new ObjectQuery("SELECT Name FROM Win32_Processor");
             ManagementObjectSearcher Searcher = new ManagementObjectSearcher(Scope, Query);
             foreach (ManagementObject WmiObject in Searcher.Get())
             {
                 ComputerName = WmiObject["Name"].ToString();
             }
             return ComputerName;
         }
         /// <summary>
         /// To Get Harddisk informtion
         /// </summary>
         /// <returns></returns>
         public static string gethddmodel()
         {

             string hddmodel = string.Empty;
             ArrayList hardDriveDetails = new ArrayList();
             ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
             foreach (ManagementObject wmi_HD in moSearcher.Get())
             {
                 HardDrive hd = new HardDrive();  // User Defined Class
                 hd.Model = wmi_HD["Model"].ToString();  //Model Number
                 hd.Type = wmi_HD["InterfaceType"].ToString();  //Interface Type
                 hd.SerialNo = wmi_HD["SerialNumber"].ToString().Trim().TrimStart().TrimEnd(); // Serial Number
                 hardDriveDetails.Add(hd);
                 hddmodel = hd.Model;// +"      Serial Number : " + ;                 
             }
             return hddmodel;
         }
         public static string gethddSerial()
         {

             string hddserial = string.Empty;
             ArrayList hardDriveDetails = new ArrayList();
             ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
             foreach (ManagementObject wmi_HD in moSearcher.Get())
             {
                 HardDrive hd = new HardDrive();  // User Defined Class
                 hd.Model = wmi_HD["Model"].ToString();  //Model Number
                 hd.Type = wmi_HD["InterfaceType"].ToString();  //Interface Type
                 hd.SerialNo = wmi_HD["SerialNumber"].ToString(); // Serial Number
                 hardDriveDetails.Add(hd);
                 hddserial = hd.SerialNo;
                
             }
             return hddserial;
         }
         public static ArrayList GetRamInformation()
         {             
             ArrayList ram = new ArrayList();
             ManagementObjectSearcher searcher = new
                   ManagementObjectSearcher("select * from Win32_PhysicalMemory");
             
             foreach (ManagementObject obj in searcher.Get())
             {
                 raminfo ri = new raminfo();
                 ri.RserialNo = obj["SerialNumber"].ToString();
                 object rcap= obj["Capacity"].ToString();
                 string capacitys = rcap.ToString();
                 long capacity = Convert.ToInt64(capacitys) / 1024 / 1024 / 1024;
                 ri.Capacity = capacity.ToString() + "Gb";                 
                 ram.Add(ri);       
                    
                 // use full to dispaly list to string;


                 //ram += (String.IsNullOrEmpty(ram) ? "" : " ~~ ") +
                     
                 // (serial == null ? String.Empty : serial.ToString().Trim()) + " - " +
                 // (cap2 == null ? String.Empty : cap2.ToString().Trim());
             }
             return ram;
         }
         public List<amcpu> cpu()
         {
            List<amcpu> ampu = new List<amcpu>();
            
            

             

            return ampu;
         }            
     }
     public class HardDrive
     {
         
         private string model = null;
         private string type = null;
         private string serialNo = null;
         public string Model
         {
             get { return model; }
             set { model = value; }
         }
         public string Type
         {
             get { return type; }
             set { type = value; }
         }
         public string SerialNo
         {
             get { return serialNo; }
             set { serialNo = value; }
         }

         public string Model1 { get; set; }
     }




    /// <summary>
    /// ram information getting the data
    /// </summary>
     public class raminfo
     {
         private string capacity;

         public string Capacity
         {
             get { return capacity; }
             set { capacity = value; }
         }
                 
         private string rserialNo = null;

         public string RserialNo
         {
             get { return rserialNo; }
             set { rserialNo = value; }
         }
     }

     public class cpu_insertions
     {
         /// <summary>
         /// SQL Connection for am2
         /// </summary>
         SqlConnection amons = new SqlConnection(ConfigurationManager.ConnectionStrings["am"].ConnectionString.ToString());

         /// <summary>
         /// inserting the cpu Details for cpu
         /// </summary>
         /// <param name="cd"></param>
         /// <returns></returns>
         public int insertCpuDetails(amcpu cd)
         {
             try
             {
                  int i = 0;
                  SqlCommand cmd = new SqlCommand("pro_insert_cpu_details", amons);
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.Add(new SqlParameter("@cu_AssetCode", cd.CU_ASSETCODE));
                 cmd.Parameters.Add(new SqlParameter("@cu_Host", cd.CU_HOST));
                 cmd.Parameters.Add(new SqlParameter("@cu_Make", cd.CU_MAKE));
                 cmd.Parameters.Add(new SqlParameter("@cu_model", cd.CU_MODEL));
                 cmd.Parameters.Add(new SqlParameter("@cu_mac", cd.CU_MAC));
                 cmd.Parameters.Add(new SqlParameter("@cu_ipAddress", cd.CU_IPADDRESS));
                 cmd.Parameters.Add(new SqlParameter("@cu_processor", cd.CU_PROCESSOR));
                 cmd.Parameters.Add(new SqlParameter("@cu_serviceTag", cd.CU_SERVICETAG));
                 cmd.Parameters.Add(new SqlParameter("@cu_Express_serviceTag", cd.CU_EXPRESS_SERVICETAG));
                 cmd.Parameters.Add(new SqlParameter("@cu_Hdd_Model", cd.CU_HDD_MODEL));
                 cmd.Parameters.Add(new SqlParameter("@cu_Hdd_serial", cd.CU_HDD_SERIAL));
                 cmd.Parameters.Add(new SqlParameter("@cu_Hdd_size", cd.CU_HDD_SIZE));
                 cmd.Parameters.Add(new SqlParameter("@cu_purchase_number", cd.CU_PURCHASE_NUMBER));
                 cmd.Parameters.Add(new SqlParameter("@cu_Voucher_number", cd.CU_VOUCHER_NUMBER));
                 cmd.Parameters.Add(new SqlParameter("@cu_recieved_date", cd.CU_RECIEVED_DATE));
                 cmd.Parameters.Add(new SqlParameter("@cu_warranty_Startdate", cd.CU_WARRANTY_STARTDATE));
                 cmd.Parameters.Add(new SqlParameter("@cu_warranty_enddate", cd.CU_WARRANTY_ENDDATE));
                 cmd.Parameters.Add(new SqlParameter("@cu_created_by", cd.Createdby));
                 amons.Open();
                 i = (int)cmd.ExecuteScalar();
                 return i;
             }
             catch (Exception)
             {
                 throw;
             }
             finally
             {
                 amons.Close();
             }


         }

         public DataTable loaddesktopdataddl(int i)
         {
             try
             {
                 SqlCommand cmd = new SqlCommand("pro_view_desktop_ddl", amons);
                 cmd.Parameters.Add(new SqlParameter("@bm_type", i));
                 cmd.CommandType = CommandType.StoredProcedure;
                 SqlDataAdapter da = new SqlDataAdapter(cmd);
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 return dt;
             }
             catch (Exception)
             {

                 throw;
             }
         }


         public DataTable load_Assetcode_by_type(assets_info ac)
         {
             try
             {
                 SqlCommand cmd = new SqlCommand("ProviewAssetCodebyDDL", amons);
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.Add(new SqlParameter("@As_type", ac.AS_TYPE));
                 SqlDataAdapter da = new SqlDataAdapter(cmd);
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 return dt;
             }
             catch (Exception)
             {
                 throw;
             }
         }



       

     }

}