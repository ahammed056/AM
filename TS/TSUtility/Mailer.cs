using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using TSEntity;

namespace TSUtility
{
    public class Mailer
    {

        #region [ HTML Tag Variables ]

        private string html_begin = "<html>";
        private string html_end = "</html>";

        private string html_head_begin = "<head>";
        private string html_head_end = "</head>";

        public static string html_contentTable_style = " TABLE.content_form { border-collapse: collapse; } " +
                                                " .content_form_col1 { white-space:wrap; border-right: #d1eafc 3px solid; border-top: #d1eafc 3px solid; padding-left: 9px; font-weight: bold; font-size: 12px; border-left: #d1eafc 3px solid; color: #333333; border-bottom: #d1eafc 3px solid; font-family: Arial; border-collapse: collapse; height: 21px; background-color: #b1ccfc; } " +
                                                " .content_form_col2 { white-space:wrap; border-right: #d1eafc 3px solid; border-top: #d1eafc 3px solid; padding-left: 9px; font-size: 12px; border-left: #d1eafc 3px solid; color: #333333; border-bottom: #d1eafc 3px solid; font-family: Arial; border-collapse: collapse; height: 21px; } ";

        private string html_style = "<style type='text/css'> " +
                                   " .head { font-size: 12px; color: #ffffff; font-family: Arial; } " +
                                   " .body { font-size: 12px; color: #ffffff; font-family: Arial; } " +
                                   " TABLE { text-align: left; font-size: 12px;color: #000000;font-family: Arial; } " +
                                   html_contentTable_style +
                                   "</style>";

        private string html_body_begin = "<body>";
        private string html_body_end = "</body>";

        private string html_mainTable_begin = "<table width='100%'>";
        private string html_contentTable_begin = "<table class='content_form' width='58%'>";
        private string html_table_end = "</table>";

        private string html_tr_begin = "<tr>";
        private string html_tr_end = "</tr>";

        private string html_td_begin = "<td>";
        private string html_tdLeft_begin = "<td class='content_form_col1' width='28%'>";
        private string html_tdRigth_begin = "<td class='content_form_col2'>";
        private string html_tdFooter_begin = "<td class='content_footer_text'>";
        private string html_td_end = "</td>";

        private string html_emptyrow = "<tr><td>&nbsp;</td></tr>";

        #endregion

        #region [ Variables ]

        private string SMTP_Address = "xxxxx";
        private MailAddress AdminMailAddress = new MailAddress("admin@krishnapatnamport.com", "Admin, Epms");
        private MailAddress BccMailAddress = new MailAddress("epms_support@krishnapatnamport.com", "@Epms Support Team");
        //private string DOMAIN_URL = "http://182.94.176.21/requestmanagement/";

        #endregion

        #region [ Contructors ]

        public Mailer()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region [ Methods / Functions ]

        #region [ ITTS ]

        /// <summary>
        /// "Author : Shaik Samdani Basha"
        /// "Create date : 17-Sep-2013"
        /// "Description : Send Email to L1 Level for Approval of an Update Instance"
        /// </summary>
        //public void ITDAPs_InstanceNotification(ITDAPsBO objITDAPsBO, string strStatusID)
        //{
        //    try
        //    {
        //        string lsmailSubject = string.Empty;
        //        string lsmailBody = string.Empty;
        //        StringBuilder sbEmailBody = new StringBuilder();
        //        ApprovalStatus approvalStatus = (ApprovalStatus)Convert.ToInt32(strStatusID);

        //        // built Subject & Content
        //        if (approvalStatus == ApprovalStatus.Addition_Pending_for_L1_Approval)
        //        {
        //            lsmailSubject = "DAPS CDR :: Instance Approval Request for Addition - Server IP: " + objITDAPsBO.ServerIP;
        //            lsmailBody = " added a new instance with details as below and it is pending for L1 approval";
        //        }
        //        else if (approvalStatus == ApprovalStatus.Addition_Approved_by_L1)
        //        {
        //            lsmailSubject = "DAPS CDR :: Instance Approval Request for Addition - Server IP: " + objITDAPsBO.ServerIP;
        //            lsmailBody = " added a new instance with details as below and it is pending for L2 approval";
        //        }
        //        else if (approvalStatus == ApprovalStatus.Addition_Rejected_by_L1)
        //        {
        //            lsmailSubject = "DAPS CDR :: Instance Rejected - Server IP: " + objITDAPsBO.ServerIP;
        //            lsmailBody = " added a new instance with details as below and it is rejected by L1";
        //        }
        //        else if (approvalStatus == ApprovalStatus.Addition_Approved_by_L2)
        //        {
        //            lsmailSubject = "DAPS CDR :: Instance Approval Request for Addition - Server IP: " + objITDAPsBO.ServerIP;
        //            lsmailBody = " added a new instance with details as below and it is approved by L2";
        //        }
        //        else if (approvalStatus == ApprovalStatus.Addition_Rejected_by_L2)
        //        {
        //            lsmailSubject = "DAPS CDR :: Instance Rejected - Server IP: " + objITDAPsBO.ServerIP;
        //            lsmailBody = " added a new instance with details as below and it is rejected by L2";
        //        }
        //        else if (approvalStatus == ApprovalStatus.Updation_Pending_for_L1_Approval)
        //        {
        //            lsmailSubject = "DAPS CDR :: Instance Approval Request for Updation - Server IP: " + objITDAPsBO.ServerIP;
        //            lsmailBody = " updated existing instance with details as below and it is pending for L1 approval";
        //        }
        //        else if (approvalStatus == ApprovalStatus.Updation_Approved_by_L1)
        //        {
        //            lsmailSubject = "DAPS CDR :: Instance Approval Request for Updation - Server IP: " + objITDAPsBO.ServerIP;
        //            lsmailBody = " updated existing instance with details as below and it is pending for L2 approval";
        //        }
        //        else if (approvalStatus == ApprovalStatus.Updation_Rejected_by_L1)
        //        {
        //            lsmailSubject = "DAPS CDR :: Instance Rejected - Server IP: " + objITDAPsBO.ServerIP;
        //            lsmailBody = " updated existing instance with details as below and it is rejected by L1";
        //        }
        //        else if (approvalStatus == ApprovalStatus.Updation_Approved_by_L2)
        //        {
        //            lsmailSubject = "DAPS CDR :: Instance Approval Request for Updation - Server IP: " + objITDAPsBO.ServerIP;
        //            lsmailBody = " updated existing instance with details as below and it is approved by L2";
        //        }
        //        else if (approvalStatus == ApprovalStatus.Updation_Rejected_by_L2)
        //        {
        //            lsmailSubject = "DAPS CDR :: Instance Rejected - Server IP: " + objITDAPsBO.ServerIP;
        //            lsmailBody = " updated existing instance with details as below and it is rejected by L2";
        //        }
        //        else if (approvalStatus == ApprovalStatus.Deletion_Pending_for_L1_Approval)
        //        {
        //            lsmailSubject = "DAPS CDR :: Instance Approval Request for Deletion - Server IP: " + objITDAPsBO.ServerIP;
        //            lsmailBody = " deleted a instance with details as below and it is pending for L1 approval";
        //        }
        //        else if (approvalStatus == ApprovalStatus.Deletion_Approved_by_L1)
        //        {
        //            lsmailSubject = "DAPS CDR :: Instance Approval Request for Deletion - Server IP: " + objITDAPsBO.ServerIP;
        //            lsmailBody = " deleted a instance with details as below and it is pending for L2 approval";
        //        }
        //        else if (approvalStatus == ApprovalStatus.Deletion_Rejected_by_L1)
        //        {
        //            lsmailSubject = "DAPS CDR :: Instance Rejected - Server IP: " + objITDAPsBO.ServerIP;
        //            lsmailBody = " deleted a instance with details as below and it is rejected by L1";
        //        }
        //        else if (approvalStatus == ApprovalStatus.Deletion_Approved_by_L2)
        //        {
        //            lsmailSubject = "DAPS CDR :: Instance Approval Request for Deletion - Server IP: " + objITDAPsBO.ServerIP;
        //            lsmailBody = " deleted a instance with details as below and it is approved by L2";
        //        }
        //        else if (approvalStatus == ApprovalStatus.Deletion_Rejected_by_L2)
        //        {
        //            lsmailSubject = "DAPS CDR :: Instance Rejected - Server IP: " + objITDAPsBO.ServerIP;
        //            lsmailBody = " deleted a instance with details as below and it is rejected by L2";
        //        }

        //        // begin html
        //        sbEmailBody.Append(html_begin);
        //        // append head tag with style
        //        sbEmailBody.Append(GetHTML_HeaderWithStyles());
        //        // body begin
        //        sbEmailBody.Append(html_body_begin);
        //        // main table begin
        //        sbEmailBody.Append(html_mainTable_begin);
        //        // append header row like "Dear HR, " etc
        //        sbEmailBody.Append(GetHTML_HeaderRowWithContent("Dear Team, "));

        //        sbEmailBody.Append(html_emptyrow);

        //        // Add purpose of the mail in table row -------------------------------------------
        //        sbEmailBody.Append(html_tr_begin);
        //        sbEmailBody.Append(html_td_begin);
        //        sbEmailBody.Append(GetHTML_ContentRow_DisplayName(objITDAPsBO.CreatedBy) + lsmailBody);
        //        sbEmailBody.Append(html_td_end);
        //        sbEmailBody.Append(html_tr_end);
        //        // --------------------------------------------------------------------------------

        //        sbEmailBody.Append(html_emptyrow);

        //        // Row of contents begin ----------------------------------------------------------
        //        sbEmailBody.Append(html_tr_begin);
        //        sbEmailBody.Append(html_td_begin);
        //        // Add content table
        //        sbEmailBody.Append(html_contentTable_begin);
        //        // Add content rows with data
        //        sbEmailBody.Append(GetHTML_ContentRow("Server IP", objITDAPsBO.ServerIP));
        //        sbEmailBody.Append(GetHTML_ContentRow("Client IP", objITDAPsBO.ClientIP));
        //        sbEmailBody.Append(GetHTML_ContentRow("Host Name", objITDAPsBO.Hostname));
        //        sbEmailBody.Append(GetHTML_ContentRow("Location", objITDAPsBO.LocationName));
        //        // close the content table
        //        sbEmailBody.Append(html_table_end);
        //        sbEmailBody.Append(html_td_end);
        //        sbEmailBody.Append(html_tr_end);
        //        // End of row of contents -----------------------------------------------------------

        //        sbEmailBody.Append(html_emptyrow);

        //        // Add footer text or link for action
        //        sbEmailBody.Append(GetHTML_FooterTextRow("For approval/more details, kindly login to <a href='http://182.94.176.21/CDR/' target='_blank'>Click Here</a> from intranet"));
        //        sbEmailBody.Append(html_emptyrow);

        //        // Add footer ( multiple rows with "do not reply" , "Regards" )
        //        sbEmailBody.Append(GetHTML_FooterRow());

        //        // close maintable, body & html
        //        sbEmailBody.Append(html_table_end);
        //        sbEmailBody.Append(html_body_end);
        //        sbEmailBody.Append(html_end);

        //        MailMessage mail = new MailMessage();
        //        mail.Subject = lsmailSubject.Trim();
        //        mail.IsBodyHtml = true;
        //        mail.Body = sbEmailBody.ToString();
        //        mail.From = AdminMailAddress;

        //        //****** split To Emails which are separated by comma(,) *******
        //        if (objITDAPsBO.ToEmail.ToString() != "")
        //        {
        //            string strToEmail = objITDAPsBO.ToEmail;
        //            string[] strToEmails = strToEmail.Split(',');
        //            foreach (string ToEmail in strToEmails)
        //            {
        //                if (ToEmail != "")
        //                {
        //                    mail.To.Add(ToEmail);
        //                }
        //            }
        //        }
        //        //****** Ended code here ******************

        //        //****** split CC Emails which are separated by comma(,) *******
        //        if (objITDAPsBO.CCEmail.ToString() != "")
        //        {
        //            string strCCEmail = objITDAPsBO.CCEmail;
        //            string[] strCCEmails = strCCEmail.Split(',');
        //            foreach (string CCEmail in strCCEmails)
        //            {
        //                if (CCEmail != "")
        //                {
        //                    mail.CC.Add(CCEmail);
        //                }
        //            }
        //        }
        //        //****** Ended code here ******************
        //        mail.Bcc.Add("genpactautomationteam@genpact.com");

        //        if (mail.To.Count > 0)
        //        {
        //            SmtpClient SmtpMail = new SmtpClient(SMTP_Address);
        //            SmtpMail.Send(mail);
        //            System.Threading.Thread.Sleep(1000);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        #endregion

        #endregion

        #region [ HTML Methods ]

        /// <summary>
        /// "Author : Bhanu Teja"
        /// "Create date : 11-SEP-2012"
        /// "Description : HTML header including style"
        /// </summary>
        private string GetHTML_HeaderWithStyles()
        {
            return html_head_begin +
                        html_style +
                   html_head_end;
        }

        /// <summary>
        /// "Author : Bhanu Teja"
        /// "Create date : 11-SEP-2012"
        /// "Description : HTML header row"
        /// <param name="heading">string like "Dear User, " etc </param>
        /// </summary>
        private string GetHTML_HeaderRowWithContent(string heading)
        {
            return html_tr_begin +
                        html_td_begin +
                            "<strong> " + heading + " </strong>" +
                        html_td_end +
                   html_tr_end;
        }

        /// <summary>
        /// "Author : Bhanu Teja"
        /// "Create date : 11-SEP-2012"
        /// "Description : HTML Content row"
        /// <param name="LabelName">string like "Employee Name : " etc </param>
        /// <param name="Data">Value to display</param>
        /// </summary>
        private string GetHTML_ContentRow(string LabelName, string Data)
        {
            return html_tr_begin +
                        html_tdLeft_begin +
                            LabelName +
                        html_td_end +
                        html_tdRigth_begin +
                            Data +
                        html_td_end +
                   html_tr_end;
        }

        /// <summary>
        /// "Author : Bhanu Teja"
        /// "Create date : 24-SEP-2012"
        /// "Description : HTML Content row"
        /// <param name="LabelName">string like "Employee Name : " etc </param>
        /// <param name="PreviousData">Value to display</param>
        /// </summary>
        private string GetHTML_ContentRow2(string LabelName, string PreviousData, string NewData)
        {
            if (PreviousData == string.Empty)
                PreviousData = "NA";
            if (NewData == string.Empty)
                NewData = "NA";
            return html_tr_begin +
                        html_tdLeft_begin +
                            LabelName +
                        html_td_end +
                        html_tdRigth_begin +
                            PreviousData +
                        html_td_end +
                        html_tdRigth_begin +
                            NewData +
                        html_td_end +
                   html_tr_end;
        }

        /// <summary>
        /// "Author : Bhanu Teja"
        /// "Create date : 24-SEP-2012"
        /// "Description : HTML Content row"
        /// <param name="LabelName">string like "Employee Name : " etc </param>
        /// <param name="PreviousData">Value to display</param>
        /// </summary>
        private string GetHTML_DiffContentRow(string LabelName, string PreviousData, string NewData)
        {
            if (PreviousData.Trim().ToLower() == NewData.Trim().ToLower())
                return "";
            else
                return GetHTML_ContentRow2(LabelName, PreviousData, NewData);
        }

        /// <summary>
        /// "Author : Bhanu Teja"
        /// "Create date : 24-SEP-2012"
        /// "Description : HTML Content row"
        /// <param name="header1">string like "Employee Name : " etc </param>
        /// <param name="header2">Value to display</param>
        /// </summary>
        private string GetHTML_ContentHeader2(string header1, string header2)
        {
            return html_tr_begin +
                        html_tdRigth_begin +
                            "&nbsp;" +
                        html_td_end +
                        html_tdLeft_begin +
                            header1 +
                        html_td_end +
                        html_tdLeft_begin +
                            header2 +
                        html_td_end +
                   html_tr_end;
        }

        /// <summary>
        /// "Author : Bhanu Teja"
        /// "Create date : 11-SEP-2012"
        /// "Description : HTML Footer text row i.e, an external link or etc"
        /// <param name="Data">Text or Link to display</param>
        /// </summary>
        private string GetHTML_FooterTextRow(string Data)
        {
            return html_tr_begin +
                        html_tdFooter_begin +
                            Data +
                        html_td_end +
                   html_tr_end;
        }

        /// <summary>
        /// "Author : Bhanu Teja"
        /// "Create date : 11-SEP-2012"
        /// "Description : HTML Footer Row i.e, Regards, do not reply etc"
        /// </summary>
        private string GetHTML_FooterRow()
        {
            return html_tr_begin +
                        html_td_begin +
                            "This is an automatically generated email, please do not reply ***" +
                        html_td_end +
                   html_tr_end +
                   html_emptyrow +
                   html_tr_begin +
                        html_td_begin +
                            "Regards," +
                        html_td_end +
                   html_tr_end +
                   html_tr_begin +
                        html_td_begin +
                            "CDR Administrator" +
                        html_td_end +
                   html_tr_end;
        }

        private string GetHTML_DAPsFooterRow()
        {
            return html_tr_begin +
                        html_td_begin +
                            "This is an automatically generated email, please do not reply ***" +
                        html_td_end +
                   html_tr_end +
                   html_emptyrow +
                   html_tr_begin +
                        html_td_begin +
                            "Regards," +
                        html_td_end +
                   html_tr_end +
                   html_tr_begin +
                        html_td_begin +
                            "DAPs Administrator" +
                        html_td_end +
                   html_tr_end;
        }
        private string GetHTML_StorageFooterRow()
        {
            return html_tr_begin +
                        html_td_begin +
                            "This is an automatically generated email, please do not reply ***" +
                        html_td_end +
                   html_tr_end +
                   html_emptyrow +
                   html_tr_begin +
                        html_td_begin +
                            "Regards," +
                        html_td_end +
                   html_tr_end +
                   html_tr_begin +
                        html_td_begin +
                            "Storage Administrator" +
                        html_td_end +
                   html_tr_end;
        }


        private string GetHTML_ContentRow_DisplayName(string strCreatedBy)
        {
            try
            {
                return "<strong> " + SessionVariables.UserName + " [" + SessionVariables.UserID + "]" + " </strong>";
            }
            catch (Exception)
            {
                return "<strong> " + strCreatedBy + " </strong>";
            }
        }

        #endregion

    }
}
