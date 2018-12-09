using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;

namespace TSUtility
{
    public class BindControls
    {

        public BindControls()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// "Author : Bhanu Teja"
        /// "Create date : 24-August-2012"
        /// "Description : Function to Bind DropdownList"
        /// <param name="ddList">DropDownList</param>
        /// <param name="dtab">DataTable to bind</param>
        /// <param name="textField">Text Field Name</param>
        /// <param name="valueField">Value Field Name</param>
        /// </summary>
        public static void BindDropDown(DropDownList ddList, DataTable dtab, string textField, string valueField)
        {
            ddList.DataSource = dtab;
            ddList.DataTextField = textField;
            ddList.DataValueField = valueField;
            ddList.DataBind();
        }

        /// <summary>
        /// "Author : Bhanu Teja"
        /// "Create date : 24-August-2012"
        /// "Description : Function to Bind DropdownList and append extra option like 'All','Select'"
        /// <param name="ddList">DropDownList</param>
        /// <param name="dtab">DataTable to bind</param>
        /// <param name="textField">Text Field Name</param>
        /// <param name="valueField">Value Field Name</param>
        /// <param name="ddlOption">DropDownOption Type to append</param>
        /// </summary>
        public static void BindDropDown(DropDownList ddList, DataTable dtab, string textField, string valueField, DropDownOption ddlOption)
        {
            // first bind the DataTable
            BindDropDown(ddList, dtab, textField, valueField);

            AddOptionalItem(ddList, ddlOption);
        }

        /// <summary>
        /// "Author : Bhanu Teja"
        /// "Create date : 24-August-2012"
        /// "Description : Function append extra option like 'All','Select'"
        /// <param name="ddList">DropDownList</param>
        /// <param name="ddlOption">DropDownOption Type to append</param>
        /// </summary>
        public static void AddOptionalItem(DropDownList ddList, DropDownOption ddlOption)
        {
            // Append the extra list-item in dropdown
            string strText = ddlOption.ToString().Replace("_", "");
            string strValue = ((Int32)ddlOption).ToString();
            int position = 0;
            if (ddlOption == DropDownOption._NA)
                position = ddList.Items.Count;
            ddList.Items.Insert(position, new ListItem(strText, strValue));
        }

        /// <summary>
        /// "Author : Bhanu Teja"
        /// "Create date : 24-SEP-2012"
        /// "Description : Function to Bind DropdownList and append extra option like 'All','Select'"
        /// </summary>
        public static void SetSelected(DropDownList ddList, string FindByValue)
        {
            ListItem li = ddList.Items.FindByValue(FindByValue);
            if (li != null)
            {
                ddList.ClearSelection();
                li.Selected = true;
            }
        }

        /// <summary>
        /// "Author : Bhanu Teja"
        /// "Create date : 10-Dec-2013"
        /// "Description : Function to Bind DropdownList and append extra option like 'All','Select'"
        /// </summary>
        public static void SetSelected(DropDownList ddList, bool FindByValue)
        {
            ListItem li;

            if (FindByValue)
                li = ddList.Items.FindByValue("1");
            else
                li = ddList.Items.FindByValue("0");

            if (li != null)
                li.Selected = true;
        }


        /// <summary>
        /// "Author : Bhanu Teja"
        /// "Create date : 19-Dec-2013"
        /// "Description : Function to Bind RadioButtonList and append extra option like 'All','Select'"
        /// </summary>
        public static void SetSelected(RadioButtonList rblList, string FindByValue)
        {
            ListItem li = rblList.Items.FindByValue(FindByValue);
            if (li != null)
                li.Selected = true;
        }

        /// <summary>
        /// "Author : Bhanu Teja"
        /// "Create date : 19-Dec-2013"
        /// "Description : Function to Bind RadioButtonList and append extra option like 'All','Select'"
        /// </summary>
        public static void SetSelected(RadioButtonList rblList, bool FindByValue)
        {
            ListItem li;

            if (FindByValue)
                li = rblList.Items.FindByValue("1");
            else
                li = rblList.Items.FindByValue("0");

            if (li != null)
                li.Selected = true;
        }

    }
}
