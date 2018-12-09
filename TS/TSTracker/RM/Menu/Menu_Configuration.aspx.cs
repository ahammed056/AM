using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TSBAL;
using TSEntity;
using TSUtility;
using System.Collections;

namespace TSTracker.RM.Menu
{
    public partial class Menu_Configuration : System.Web.UI.Page
    {

        #region [ Public Variables/Declarations ]

        MenuBAL objMenuBAL;
        string gstrMenuID = string.Empty;
        string gstrchildID = string.Empty;
        ArrayList garrMenuIDS = new ArrayList();

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                objMenuBAL = new MenuBAL();
                Page.Header.DataBind();
                lbloutput.Visible = false;
                tvMenu.Attributes.Add("onclick", "OnTreeClick(event)");
                if (!IsPostBack)
                {
                    TreeNode loTreeNode = new TreeNode();
                    loTreeNode = null;
                    LoadLevels();
                    loTreeNode = Buildtree(loTreeNode, 0, 4, true);
                    tvMenu.Nodes.Add(loTreeNode);

                    tvMenu.CollapseAll();
                    tvMenu.Nodes[0].Expand();
                    for (int licount = 0; licount <= tvMenu.Nodes.Count - 1; licount++)
                    {
                        checklist(tvMenu.Nodes[licount], ddlLevel.SelectedValue);
                    }

                    try
                    {
                        if (tvMenu.SelectedNode != null)
                        {
                            tvMenu.SelectedNode.Selected = false;
                            ArrayList list = new ArrayList();
                            Session["SettingsList"] = SaveTreeViewState(tvMenu.Nodes, list);
                        }
                    }
                    catch (Exception ex)
                    {
                        CommonBAL.SaveException(ex);
                    }
                }

                try
                {
                    if (Session["SettingsList"] != null)
                    {
                        RestoreTreeViewState(tvMenu.Nodes, (ArrayList)Session["SettingsList"]);
                    }
                }
                catch (Exception ex)
                {
                    CommonBAL.SaveException(ex);
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        public void LoadLevels()
        {
            try
            {
                //Loading Access Levles
                DataSet dsContent = objMenuBAL.GetAccessLevels();
                BindControls.BindDropDown(ddlLevel, dsContent.Tables[0], "Group Name", "Group ID", DropDownOption._Select);
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                gstrMenuID = "";
                garrMenuIDS.Clear();
                int licount = 0;
                string lstrCheckedIds = null;
                for (licount = 0; licount <= tvMenu.Nodes.Count - 1; licount++)
                {
                    //Get checked list of each node
                    GetChecklist(tvMenu.Nodes[0]);
                }
                if (gstrMenuID.Length == 0)
                {
                    lstrCheckedIds = "No Item checked";
                }
                else
                {
                    lstrCheckedIds = gstrMenuID;
                }
                if (!string.IsNullOrEmpty(ddlLevel.SelectedValue) & !string.IsNullOrEmpty(gstrMenuID))
                {
                    //if already exists it will delete the entries
                    string lsquery = "";
                    lsquery = "USP_GetMenuAccessList " + ddlLevel.SelectedValue;
                    DataSet loDataSet = new DataSet();
                    loDataSet = objMenuBAL.GetDataSet(lsquery);
                    if (loDataSet.Tables[0].Rows.Count != 0)
                    {
                        lsquery = "usp_InsUpd_MenuAccess 2," + SessionVariables.UserID + "," + ddlLevel.SelectedValue;
                        objMenuBAL.ExecNonQuery(lsquery);
                    }
                    for (licount = 0; licount <= garrMenuIDS.Count - 1; licount++)
                    {
                        lsquery = "usp_InsUpd_MenuAccess 1," + SessionVariables.UserID + ",'" + ddlLevel.SelectedValue + "'," + garrMenuIDS[licount] + "";
                        objMenuBAL.ExecNonQuery(lsquery);
                    }
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        private void checklist(TreeNode node, string levelID)
        {
            try
            {
                int licount = 0;
                for (licount = 0; licount <= node.ChildNodes.Count - 1; licount++)
                {
                    //call recursively for all childnodes
                    checklist(node.ChildNodes[licount], levelID);
                }
                int lintvalue = 0;
                lintvalue = Convert.ToInt32(node.Value);
                string lsquery = "";
                lsquery = "USP_GetMenuAccessList " + levelID + "," + lintvalue + "";
                System.Data.DataView loview = default(System.Data.DataView);
                DataSet loDataSet = new DataSet();
                loDataSet = objMenuBAL.GetDataSet(lsquery);
                loview = loDataSet.Tables[0].DefaultView;
                if (loview.Table.Rows.Count == 0)
                {
                    node.Checked = false;
                }
                else
                {
                    node.Checked = true;
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        private string GetChecklist(TreeNode node)
        {
            //To get list of nodes which are checked 
            try
            {
                int licount = 0;
                for (licount = 0; licount <= node.ChildNodes.Count - 1; licount++)
                {
                    //call recursively for all childnodes
                    GetChecklist(node.ChildNodes[licount]);
                }
                if (node.Checked)
                {
                    gstrMenuID = gstrMenuID + " " + node.Value;
                    garrMenuIDS.Add(node.Value);
                    return node.Value;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
                return "";
            }
        }

        protected void tvMenu_SelectedNodeChanged(object sender, EventArgs e)
        {
            try
            {
                tvMenu.SelectedNode.ToggleExpandState();
                tvMenu.SelectedNode.Selected = false;
                ArrayList list = new ArrayList();
                Session["SettingsList"] = SaveTreeViewState(tvMenu.Nodes, list);
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        protected void ddlLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                for (int licount = 0; licount <= tvMenu.Nodes.Count - 1; licount++)
                {
                    checklist(tvMenu.Nodes[0], ddlLevel.SelectedValue);
                }
                tvMenu.Nodes[0].ExpandAll();
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
        }

        public TreeNode Buildtree(TreeNode rootnode, int index, int LevelID, bool SettingsPage)
        {
            //recursive build tree function to get the menus according to the access level
            DataView loview = new DataView();
            string lsSqlQuery = "";
            try
            {
                if (SettingsPage)
                {
                    lsSqlQuery = "USP_GetMenus " + index;
                }
                else
                {
                    lsSqlQuery = "USP_GetMenuTreeList " + index + "," + LevelID;
                }
                DataSet loDataSet = new DataSet();
                loDataSet = objMenuBAL.GetDataSet(lsSqlQuery);
                loview = loDataSet.Tables[0].DefaultView;

                if (rootnode == null)
                {
                    if (loview.Table.Rows.Count > 0)
                    {
                        rootnode = new TreeNode();
                        rootnode.Text = loview.Table.Rows[0]["menuname"].ToString();
                        rootnode.Value = loview.Table.Rows[0]["MenuMstId"].ToString();
                        rootnode.Target = loview.Table.Rows[0]["menulink"].ToString();
                        Buildtree(rootnode, Convert.ToInt32(rootnode.Value), LevelID, false);
                    }
                }
                else
                {
                    for (int intCountRemoveCNote = 0; intCountRemoveCNote <= rootnode.ChildNodes.Count - 1; intCountRemoveCNote++)
                    {
                        rootnode.ChildNodes.RemoveAt(0);
                    }
                    for (int licount = 0; licount <= loview.Table.Rows.Count - 1; licount++)
                    {
                        TreeNode loTreeNode = new TreeNode();
                        loTreeNode.Text = loview.Table.Rows[licount]["menuname"].ToString();
                        loTreeNode.Value = loview.Table.Rows[licount]["MenuMstId"].ToString();
                        loTreeNode.Target = loview.Table.Rows[licount]["menulink"].ToString();
                        loTreeNode.Checked = rootnode.Checked;
                        rootnode.ChildNodes.Add(loTreeNode);
                        Buildtree(loTreeNode, Convert.ToInt32(loTreeNode.Value), LevelID, SettingsPage);
                    }
                }
            }
            catch (Exception ex)
            {
                CommonBAL.SaveException(ex);
            }
            return rootnode;
        }

        public ArrayList SaveTreeViewState(TreeNodeCollection nodes, ArrayList list)
        {
            //// Recursivley record all expanded nodes in the List.
            foreach (TreeNode node in nodes)
            {
                if ((node.ChildNodes != null))
                {
                    if (node.Expanded.HasValue)
                        if (node.Expanded.Value == true)
                            list.Add(node.Text);
                    SaveTreeViewState(node.ChildNodes, list);
                }
            }
            return list;
        }

        public void RestoreTreeViewState(TreeNodeCollection nodes, ArrayList list)
        {
            foreach (TreeNode node in nodes)
            {
                // Restore the state of one node.
                if (list.Contains(node.Text))
                {
                    if (((node.ChildNodes != null) & node.ChildNodes.Count != 0))
                    {
                        //And node.Expanded.GetValueOrDefault = False
                        if (node.Expanded.HasValue)
                        {
                            if (node.Expanded.Value == false)
                                node.Expand();
                        }
                        else
                        {
                            node.Expand();
                        }
                    }
                }
                else
                {
                    if ((node.ChildNodes != null) && (node.ChildNodes.Count != 0) && (node.Expanded.GetValueOrDefault()))
                    {
                        if (node.Expanded.Value == true)
                            node.Collapse();
                    }
                }
                // If the node has child nodes, restore their state, too.
                if (((node.ChildNodes != null) & node.ChildNodes.Count != 0))
                    RestoreTreeViewState(node.ChildNodes, list);
            }
        }

    }
}
