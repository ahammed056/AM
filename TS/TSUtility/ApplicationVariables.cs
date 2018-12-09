using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace TSUtility
{

    /// <summary>
    /// "Author : Sk Samdani"
    /// "Create date : 23-August-2012"
    /// "Modified By : Sk Samdani"
    /// "Modified date : 01-August-2013"
    /// "Description : 'Set' & 'Get' application level variables"
    /// </summary>
    public class ApplicationVariables
    {

        #region [ Static Variables / Properties ]

        // Variable names used in "Application State"
        private static string p_ConnectionStringName = "DBConnString";
        private static string p_PageTitleName = "PageTitle";
        private static string p_LogFilePathName = "LogFilePath";
        //*******************************************

        public static string ConnectionString
        {
            get
            {
                if (HttpContext.Current.Application[p_ConnectionStringName] != null)
                    return HttpContext.Current.Application[p_ConnectionStringName].ToString();
                else
                    return "";
            }
        }

        public static string PageTitle
        {
            get
            {
                if (HttpContext.Current.Application[p_PageTitleName] != null)
                    return HttpContext.Current.Application[p_PageTitleName].ToString();
                else
                    return "";
            }
        }

        public static string LogFilePath
        {
            get
            {
                if (HttpContext.Current.Application[p_LogFilePathName] != null)
                {
                    string _filepath = HttpContext.Current.Server.MapPath(HttpContext.Current.Application[p_LogFilePathName].ToString());
                    _filepath = _filepath.Replace(".txt", DateTime.Now.ToString("_dd-MM-yyyy") + ".txt");
                    return _filepath;
                }
                else
                    return "";

            }
        }

        #endregion

        #region [ Create Static variables ]

        public void Set_ConnectionString(System.Web.HttpApplicationState Application, string value)
        {
            Application[p_ConnectionStringName] = value;
        }

        public void Set_PageTitle(System.Web.HttpApplicationState Application, string value)
        {
            Application[p_PageTitleName] = value;
        }

        public void Set_LogFilePath(System.Web.HttpApplicationState Application, string value)
        {
            Application[p_LogFilePathName] = value;
        }


        #endregion

        #region [ Constructors ]

        public ApplicationVariables()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region [ Methods ]

        public static void Add(string Name, string Value)
        {
            HttpContext.Current.Application[Name] = Value;
        }

        public static string Get(string Name)
        {
            if (HttpContext.Current.Application[Name] != null)
                return HttpContext.Current.Application[Name].ToString();
            else
                return "";
        }

        public static void Add(string Name, object Value)
        {
            HttpContext.Current.Application[Name] = Value;
        }

        public static object GetObject(string Name)
        {
            if (HttpContext.Current.Application[Name] != null)
                return HttpContext.Current.Application[Name];
            else
                return "";
        }

        public static void Remove(string Name)
        {
            Remove(HttpContext.Current.Application, Name);
        }

        public static void Remove(System.Web.HttpApplicationState Application, string Name)
        {
            if (Application[Name] != null)
                Application.Remove(Name);
        }

        #endregion
    }
}
