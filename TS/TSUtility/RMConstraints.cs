using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSUtility
{
    public class RMConstraints
    {

        public RMConstraints()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region [ Page Names ]

        public const string WebPage_Login = "~/Login.aspx";
        public const string WebPage_Logout = "~/Logout.aspx";
        public const string WebPage_ResetPwd = "~/PasswordReset.aspx";
        public const string WebPage_Home = "~/RM/TS/Home.aspx";

        public const string WebPage_ITTS_Home = "~/RM/TS/TS_Home.aspx";
        public const string WebPage_ITTS_Management = "~/RM/TS/TS_Mgmt.aspx";
        public const string WebPage_ITTS_ManageMaster = "~/RM/TS/TS_ManageMaster.aspx";
        public const string WebPage_ITTS_Report = "~/RM/TS/TS_Report.aspx";

        public const string WebPage_ITPRO_Home = "~/RM/PRO/PRO_VisitMgmt.aspx";
        public const string WebPage_ITPRO_ManageMaster = "~/RM/PRO/PRO_ManageMaster.aspx";
        public const string WebPage_ITPRO_ManageVisitor = "~/RM/PRO/PRO_EditVisitor.aspx";
        public const string WebPage_ITPRO_AddVisitor = "~/RM/PRO/PRO_AddVisitForm.aspx";
                
        #endregion

        #region [ Page Titles ]

        public const string Page_Title_Main = "Time Sheet :: ";
        public const string Page_Title_PRO_Main = "PRO :: ";
        public const string Page_Title_Default = "Login";
        public const string Page_Title_Logout = "Logout";
        public const string Page_Title_Home = "Home";

        //Declared for Help Module
        public const string Page_Title_Help_Home = "Help Document";

        #endregion

        #region [ User Types [Roles] ]

        public const string UserType_General = "General";
        public const string UserType_Admin = "Admin";
        public const string UserType_NA = "NA";

        #endregion

        #region [ Module Names ]
               
        public const string Module_ITDAPs = "DAPS_CDR_";
       
        #endregion

        #region [ Page Themes ]

        public const string Page_Theme_Default = "DefaultTheme";

        #endregion

        #region [ Excel Export ]

        public const string ExcelExport_vbCr = "\r";
        public const string ExcelExport_vbLf = "\n";
        public const string ExcelExport_vbCrLf = "\r\n";
        public const string ExcelExport_vbTab = "\t";

        #endregion

        #region [ DropDownList Master DataFields ]

        public const string DropDownList_Master_DataValueField = "ID";
        public const string DropDownList_Master_DataTextField = "Name";

        public const string DropDownList_Master_DataCustomValueField = "MasterID";
        public const string DropDownList_Master_DataCustomTextField = "MasterName";

        public const string DropDownList_Master_DictionaryValueField = "Value";
        public const string DropDownList_Master_DictionaryTextField = "Key";

        #endregion

        #region [ Dictionary Objects ]

        #region [ Group Names ]

        public static Dictionary<string, string> GetGroupsDictionary()
        {
            Dictionary<string, string> DictObj = new Dictionary<string, string>();

            DictObj.Add("TSAdmin", RMConstraints.WebPage_ITTS_Management);
            DictObj.Add("TSGeneral", RMConstraints.WebPage_ITTS_Management);
            DictObj.Add("TSManager", RMConstraints.WebPage_ITTS_Report);
            DictObj.Add("Administrator", RMConstraints.WebPage_Home);

            DictObj.Add("PROGeneral", RMConstraints.WebPage_Home);
            DictObj.Add("PROAdmin", RMConstraints.WebPage_Home);

            return DictObj;
        }

        #endregion

        #region [ Approval Levels ]

        public static Dictionary<string, int> GetApprovalLevelDictionary()
        {
            Dictionary<string, int> DictObj = new Dictionary<string, int>();

            DictObj.Add("Approved Instances", 3);
            DictObj.Add("Pending for L1 Approval", 1);
            DictObj.Add("Pending for L2 Approval", 2);
            DictObj.Add("Deleted Instances", 5);
            DictObj.Add("Rejected Instances", 4);

            return DictObj;
        }

        #endregion

        #region [ Module Names ]

        public static Dictionary<string, int> GetModulesDictionary()
        {
            Dictionary<string, int> DictObj = new Dictionary<string, int>();
            DictObj.Add("TS", 1001);
            return DictObj;
        }

        #endregion

        #endregion

    }
}
