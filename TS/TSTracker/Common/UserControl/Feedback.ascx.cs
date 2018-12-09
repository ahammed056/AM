using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TSTracker.Common.UserControl
{
    public partial class Feedback : System.Web.UI.UserControl
    {

        private System.Collections.ArrayList m_arrErrors = new System.Collections.ArrayList(0);
        private System.Collections.ArrayList m_arrCompleted = new System.Collections.ArrayList(0);
        private System.Collections.ArrayList m_arrinfo = new System.Collections.ArrayList(0);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void addFailure(string strMessage)
        {
            m_arrErrors.Add(strMessage);
        }

        public void addSuccess(string strMessage)
        {
            m_arrCompleted.Add(strMessage);
        }

        public void addinfo(string strMessage)
        {
            m_arrinfo.Add(strMessage);
        }

        /**
         * Render the list of errors
         */
        public String renderErrorList(String strPrefix, String strSuffix)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            int nc = m_arrErrors.Count;
            for (int i = 0; i < nc; i++)
            {
                sb.AppendFormat("{0}{1}{2}",
                    strPrefix,
                    m_arrErrors[i],
                    strSuffix);
            }

            return sb.ToString();
        }

        /**
         * Render the list of errors
         */
        public String renderTasksCompleted(String strPrefix, String strSuffix)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            int nc = m_arrCompleted.Count;
            for (int i = 0; i < nc; i++)
            {
                sb.AppendFormat("{0}{1}{2}",
                    strPrefix,
                    m_arrCompleted[i],
                    strSuffix);
            }

            return sb.ToString();
        }

        /**
        * Render the list of errors
        */
        public String renderinfo(String strPrefix, String strSuffix)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            int nc = m_arrinfo.Count;
            for (int i = 0; i < nc; i++)
            {
                sb.AppendFormat("{0}{1}{2}",
                    strPrefix,
                    m_arrinfo[i],
                    strSuffix);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Tests if one or more errors has been added to the error collection.
        /// </summary>
        /// <returns>Returns true if one or more errors have been added to the error collection</returns>
        public bool hasErrors()
        {
            return m_arrErrors.Count > 0;
        }

        /// <summary>
        /// Returns "display:none" if the error collection is empty, else returns an empty string
        /// </summary>
        /// <returns>Returns "display:none" if the error collection is empty, else returns an empty string</returns>
        public string hideErrors()
        {
            return m_arrErrors.Count == 0 ? "display:none" : "";
        }

        /// <summary>
        /// Returns "display:none" if the task completed message collection is empty, else returns an empty string
        /// </summary>
        /// <returns>Returns "display:none" if the task completed message collection is empty, else returns an empty string</returns>
        public string hideTasksComplete()
        {
            return m_arrCompleted.Count == 0 ? "display:none" : "";
        }

        /// <summary>
        /// Returns "display:none" if the task completed message collection is empty, else returns an empty string
        /// </summary>
        /// <returns>Returns "display:none" if the task completed message collection is empty, else returns an empty string</returns>
        public string hideinfo()
        {
            return m_arrinfo.Count == 0 ? "display:none" : "";
        }

    }
}