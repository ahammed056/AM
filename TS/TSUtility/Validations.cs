using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSUtility
{
    public class Validations
    {
        public static bool IsValid(System.Web.UI.Page Page)
        {            
            return ValidateInnerControls(Page);
        }

        public static bool ValidateControls(params System.Web.UI.Control[] controls)
        {

            foreach (System.Web.UI.Control subControl in controls)
            {
                if (ValidateInnerControls(subControl) == false)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ValidateInnerControls(System.Web.UI.Control control)
        {
            if (control.Visible == false)
            {
                return true;
            }

            if (control.HasControls())
            {
                foreach (System.Web.UI.Control subControl in control.Controls)
                {
                    if (ValidateInnerControls(subControl) == false)
                    {
                        return false;
                    }
                }
            }
            else 
            {
                if (control is System.Web.UI.WebControls.TextBox) 
                {
                    System.Web.UI.WebControls.TextBox objTxt = (System.Web.UI.WebControls.TextBox)control;

                    if(objTxt.Enabled == false ||
                        objTxt.ReadOnly == true)
                    {
                        return true;
                    }

                    if (objTxt.Attributes["IsTextType"] != null)
                    {
                        if (objTxt.Text.Trim().Length == 0)                        
                            return false;                        
                    }

                    if (objTxt.Text.Trim().Length > 0)
                    {
                        if (objTxt.Attributes["IsNumberType"] != null)
                        {
                            int result = 0;
                            bool isSuccess = int.TryParse(objTxt.Text.Trim(), out result);
                            if (isSuccess == false)
                                return false;
                        }

                        if (objTxt.Attributes["IsDateType"] != null)
                        {
                            DateTime result = new DateTime();
                            bool isSuccess = DateTime.TryParse(objTxt.Text.Trim(), out result);                            
                            if (isSuccess == false)
                                return false;
                        }

                        if (objTxt.Attributes["IsIPType"] != null)
                        {
                            System.Net.IPAddress result;
                            bool isSuccess = System.Net.IPAddress.TryParse(objTxt.Text.Trim(), out result);
                            if (isSuccess == false)
                                return false;
                        }

                        if (objTxt.Attributes["IsEmailType"] != null)
                        {
                            try
                            {
                                System.Net.Mail.MailAddress testMail = new System.Net.Mail.MailAddress(objTxt.Text.Trim());
                            }
                            catch
                            {
                                return false;
                            }
                        }                        
                    }
                }
                else if (control is System.Web.UI.WebControls.DropDownList)
                {
                    System.Web.UI.WebControls.DropDownList objDDL = (System.Web.UI.WebControls.DropDownList)control;

                    if (objDDL.Enabled == false || objDDL.Attributes["IsSelectType"] == null)
                    {
                        return true;
                    }

                    if (objDDL.SelectedIndex > 0)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else if (control is System.Web.UI.WebControls.CheckBox)
                {
                    System.Web.UI.WebControls.CheckBox objCtrl = (System.Web.UI.WebControls.CheckBox)control;

                    if (objCtrl.Enabled == false || objCtrl.Attributes["IsRequireType"] == null)
                    {
                        return true;
                    }

                    if (objCtrl.Checked)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else if (control is System.Web.UI.WebControls.RadioButton)
                {
                    System.Web.UI.WebControls.RadioButton objCtrl = (System.Web.UI.WebControls.RadioButton)control;

                    if (objCtrl.Enabled == false || objCtrl.Attributes["IsRequireType"] == null)
                    {
                        return true;
                    }

                    if (objCtrl.Checked)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else if (control is System.Web.UI.WebControls.CheckBoxList)
                {
                    System.Web.UI.WebControls.CheckBoxList objCtrl = (System.Web.UI.WebControls.CheckBoxList)control;

                    if (objCtrl.Enabled == false || objCtrl.Attributes["IsRequireType"] == null)
                    {
                        return true;
                    }

                    if (objCtrl.SelectedIndex != null && objCtrl.SelectedIndex != -1)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else if (control is System.Web.UI.WebControls.RadioButtonList)
                {
                    System.Web.UI.WebControls.RadioButtonList objCtrl = (System.Web.UI.WebControls.RadioButtonList)control;

                    if (objCtrl.Enabled == false || objCtrl.Attributes["IsRequireType"] == null)
                    {
                        return true;
                    }

                    if (objCtrl.SelectedIndex != null && objCtrl.SelectedIndex != -1)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else if (control is System.Web.UI.WebControls.ListBox)
                {
                    System.Web.UI.WebControls.ListBox objCtrl = (System.Web.UI.WebControls.ListBox)control;

                    if (objCtrl.Enabled == false || objCtrl.Attributes["IsRequireType"] == null)
                    {
                        return true;
                    }

                    if (objCtrl.SelectedIndex != null && objCtrl.SelectedIndex != -1)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }

            return true;
        }        

        public static bool IsControlDisplayed(System.Web.UI.Control control)
        {
            if (control.Visible == false)
                return false;
            else
            {
                if (control.Parent != null)
                {
                    return IsControlDisplayed(control.Parent);
                }
            }
            return true;
        }
    }
}
