using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace TSUtility
{
    public class SessionVariables
    {

        #region Private Variables

        // Variable names used in "Session State"
        private static string p_UserID = VIKINGV3.Cryptography.Encrypt("UID");
        private static string p_UserName = VIKINGV3.Cryptography.Encrypt("UN");
        private static string p_GroupID = VIKINGV3.Cryptography.Encrypt("GID");
        private static string p_GroupName = VIKINGV3.Cryptography.Encrypt("GN");
        private static string p_GroupEnumName = VIKINGV3.Cryptography.Encrypt("GEN");
        private static string p_UserEmail = VIKINGV3.Cryptography.Encrypt("UE");
        private static string p_HostName = VIKINGV3.Cryptography.Encrypt("HN");
        private static string p_StartDate = VIKINGV3.Cryptography.Encrypt("SD");
        private static string p_CurDate = VIKINGV3.Cryptography.Encrypt("CD");
        //*******************************************

        #endregion

        #region Constructors

        public SessionVariables()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public SessionVariables(string _userID, string _userName, string _groupID, string _groupName, string _groupEnumName, string _userEmail, string _hostName, string _startdate, string _curdate)
        {
            HttpContext.Current.Session[p_UserID] = _userID;
            HttpContext.Current.Session[p_UserName] = _userName;
            HttpContext.Current.Session[p_GroupID] = _groupID;
            HttpContext.Current.Session[p_GroupName] = _groupName;
            HttpContext.Current.Session[p_GroupEnumName] = _groupEnumName;
            HttpContext.Current.Session[p_UserEmail] = _userEmail;
            HttpContext.Current.Session[p_HostName] = _hostName;
            HttpContext.Current.Session[p_StartDate] = _startdate;
            HttpContext.Current.Session[p_CurDate] = _curdate;
       }

        //public SessionTSVariables(string _userID, string _userName, string _hostName)
        //{
        //    HttpContext.Current.Session[p_UserID] = _userID;
        //    HttpContext.Current.Session[p_UserName] = _userName;
        //    HttpContext.Current.Session[p_HostName] = _hostName;
        //}

        #endregion

        #region Properties

        public static string UserID
        {
            get
            {
                if (HttpContext.Current.Session[p_UserID] != null)
                    return HttpContext.Current.Session[p_UserID].ToString();
                else
                    return string.Empty;
            }
        }

        public static string UserName
        {
            get
            {
                if (HttpContext.Current.Session[p_UserName] != null)
                    return HttpContext.Current.Session[p_UserName].ToString();
                else
                    return string.Empty;
            }
        }

        public static string GroupID
        {
            get
            {
                if (HttpContext.Current.Session[p_GroupID] != null)
                    return HttpContext.Current.Session[p_GroupID].ToString();
                else
                    return string.Empty;
            }
        }

        public static string GroupName
        {
            get
            {
                if (HttpContext.Current.Session[p_GroupName] != null)
                    return HttpContext.Current.Session[p_GroupName].ToString();
                else
                    return string.Empty;
            }
        }

        public static string GroupEnumName
        {
            get
            {
                if (HttpContext.Current.Session[p_GroupEnumName] != null)
                    return HttpContext.Current.Session[p_GroupEnumName].ToString();
                else
                    return string.Empty;
            }
        }


        public static string UserEmail
        {
            get
            {
                if (HttpContext.Current.Session[p_UserEmail] != null)
                    return HttpContext.Current.Session[p_UserEmail].ToString();
                else
                    return string.Empty;
            }
        }

        public static string HostName
        {
            get
            {
                if (HttpContext.Current.Session[p_HostName] != null)
                    return HttpContext.Current.Session[p_HostName].ToString();
                else
                    return string.Empty;
            }
        }

        public static string StartDate
        {
            get
            {
                if (HttpContext.Current.Session[p_StartDate] != null)
                    return HttpContext.Current.Session[p_StartDate].ToString();
                else
                    return string.Empty;
            }
        }
        public static string CurDate
        {
            get
            {
                if (HttpContext.Current.Session[p_CurDate] != null)
                    return HttpContext.Current.Session[p_CurDate].ToString();
                else
                    return string.Empty;
            }
        }

        #endregion

        #region Methods

        public void Set_UserID(string value)
        {
            HttpContext.Current.Session[p_UserID] = value;
        }

        public void Set_UserName(string value)
        {
            HttpContext.Current.Session[p_UserName] = value;
        }

        public void Set_GroupID(string value)
        {
            HttpContext.Current.Session[p_GroupID] = value;
        }

        public void Set_GroupName(string value)
        {
            HttpContext.Current.Session[p_GroupName] = value;
        }

        public void Set_GroupEnumName(string value)
        {
            HttpContext.Current.Session[p_GroupEnumName] = value;
        }

        public void Set_UserEmail(string value)
        {
            HttpContext.Current.Session[p_UserEmail] = value;
        }

        public void Set_HostName(string value)
        {
            HttpContext.Current.Session[p_HostName] = value;
        }
        public void Set_StartDate(string value)
        {
            HttpContext.Current.Session[p_StartDate] = value;
        }
        public void Set_CurDate(string value)
        {
            HttpContext.Current.Session[p_CurDate] = value;
        }
        #endregion

    }
}
