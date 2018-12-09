using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TSUtility
{

    /// <summary>
    /// [ Description : Common Methods ]
    /// [ Author : Bhanu Teja ]
    /// [ Created date : 6-Dec-2013 ] 
    /// </summary>
    public class CommonMethods
    {
        public CommonMethods()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// "Author : Bhanu Teja"
        /// "Create date : 24-SEP-2012"
        /// "Description : Get Status Text"
        /// </summary>
        public static string getStatusText(bool status)
        {
            if (status)
                return "Yes";
            else
                return "No";
        }

        /// <summary>
        /// "Author : Bhanu Teja"
        /// "Create date : 24-SEP-2012"
        /// "Description : Get Status Text"
        /// </summary>
        public static string getStatusText(int status)
        {
            if (status == 0)
                return "No";
            else if (status == 1)
                return "Yes";
            else
                return "NA";
        }

        /// <summary>
        /// "Author : Bhanu Teja"
        /// "Create date : 24-SEP-2012"
        /// "Description : Get Status Text"
        /// </summary>
        public static string getStatusText(int status, string statusText)
        {
            if (status == 0)
                return "Not " + statusText;
            else if (status == 1)
                return statusText;
            else
                return "NA";
        }

        /// <summary>
        /// "Author : Bhanu Teja"
        /// "Create date : 24-SEP-2012"
        /// "Description : Get Status Text"
        /// </summary>
        public static string getStatusText(int status, string statusText, bool includeYesNo)
        {
            if (status == 0)
                return "No";
            else if (status == 1)
                return "Yes";
            else if (status == 2)
                return "Not " + statusText;
            else
                return "NA";
        }

        /// <summary>
        /// "Author : Bhanu Teja"
        /// "Create date : 6-Dec-2013"
        /// "Description : Get Status Text"
        /// </summary>
        public static bool getBoolean(string statusText)
        {
            if (statusText == "0" || statusText == "" || statusText.ToLower() == "no" || statusText.ToLower() == "false")
                return false;         
            else
                return true;
        }

        /// <summary>
        /// "Author : Bhanu Teja"
        /// "Create date : 24-SEP-2012"
        /// "Description : Get Date String"
        /// </summary>
        public static string getDateString(DateTime objDate)
        {
            if (objDate == null)
                return "";
            if (objDate.ToString("MM/dd/yyyy") == "01/01/1900" || objDate.ToString("MM/dd/yyyy") == "01/01/0001")
                return "";
            else
                return objDate.ToString("MM/dd/yyyy");
        }

        /// <summary>
        /// "Author : Bhanu Teja"
        /// "Create date : 24-SEP-2012"
        /// "Description : Get Date String"
        /// </summary>
        public static string getDateString(DateTime objDate, string emptyText)
        {
            if (objDate == null)
                return emptyText;
            if (objDate.ToString("MM/dd/yyyy") == "01/01/1900" || objDate.ToString("MM/dd/yyyy") == "01/01/0001")
                return emptyText;
            else
                return objDate.ToString("MM/dd/yyyy");
        }

        /// <summary>
        /// "Author : Bhanu Teja"
        /// "Create date : 27-SEP-2012"
        /// "Description : Get Date Time from String"
        /// </summary>
        public static DateTime getDateTime(string DateString)
        {
            try
            {
                if (DateString == string.Empty)
                    return new DateTime(1900, 1, 1);
                else
                    return DateTime.Parse(DateString);
            }
            catch
            {
                return new DateTime(1900, 1, 1);
            }
        }

        /// <summary>
        /// "Author : Bhanu Teja"
        /// "Create date : 6-Dec-2013"
        /// "Description : Get Date Time from String"
        /// </summary>
        public static string getStringNull(string readerValue)
        {
            if ((string.IsNullOrEmpty(readerValue.ToString())))
            {
                return null;
            }
            else
            {
                return readerValue;
            }
        }

        /// <summary> 
        /// "Author : Bhanuprakash" 
        /// "Create date : 13-April-2012" 
        /// "Description : Validate email address" 
        /// </summary> 
        /// <param name="strFileName">Output File Name</param> 
        public static Boolean isValidEmail(string inputEmail)
        {
            Regex objRegex = new Regex(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@(?:genpact).com)$");
            return objRegex.IsMatch(inputEmail);
        } 


    }
}
