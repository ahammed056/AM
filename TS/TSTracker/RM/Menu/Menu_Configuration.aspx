<%@ Page Title="" Language="C#" MasterPageFile="~/TS_Master.Master" AutoEventWireup="true"
    CodeBehind="Menu_Configuration.aspx.cs" Inherits="TSTracker.RM.Menu.Menu_Configuration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="mainup" runat="server">
        <ContentTemplate>
            <div>
                <CMDBUC:Feedback ID="Feedback" runat="server"></CMDBUC:Feedback>
            </div>
            <div class="breakDiv">
            </div>
            <div>
                <fieldset>
                    <legend>Menu Configuration</legend>
                    <div>
                        <table width="100%">
                            <tr>
                                <td align="center">
                                    <table cellpadding="2" cellspacing="2">
                                        <tr>
                                            <td>
                                                Group Name
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlLevel" runat="server" AutoPostBack="True" ValidationGroup="Level"
                                                    CssClass="ddClassLong" OnSelectedIndexChanged="ddlLevel_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvLevel" runat="server" ControlToValidate="ddlLevel"
                                                    Display="None" ErrorMessage="&lt;b&gt;Required Field &lt;/b&gt;&lt;br /&gt; Select Level."
                                                    InitialValue="-1" ValidationGroup="Level">*</asp:RequiredFieldValidator>
                                                <aspx:ValidatorCalloutExtender ID="VldcallLevel" runat="Server" HighlightCssClass="validatorCalloutHighlight"
                                                    TargetControlID="rfvLevel" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnSubmit" runat="server" CssClass="buttons" Text="Save" ValidationGroup="Level"
                                                    OnClick="btnSubmit_Click" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lbloutput" runat="server" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="text-align: left; margin-left: 6%;">
                                    <div style="overflow: auto; margin-left: 50px; margin-top: 0px; height: 80%">
                                        <asp:TreeView ID="tvMenu" runat="server" ExpandDepth="1" Font-Names="Consolas" Font-Size="Small"
                                            ForeColor="Black" ShowCheckBoxes="All" ShowExpandCollapse="True" Height="400px"
                                            OnSelectedNodeChanged="tvMenu_SelectedNodeChanged">
                                            <SelectedNodeStyle Font-Names="Arial" Font-Size="Small" ForeColor="Black" />
                                        </asp:TreeView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </fieldset>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSubmit" />
        </Triggers>
    </asp:UpdatePanel>

    <script type="text/javascript">
        function OnTreeClick(evt) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            var isChkBoxClick = (src.tagName.toLowerCase() == "input" && src.type == "checkbox");
            if (isChkBoxClick) {
                var parentTable = GetParentByTagName("table", src);
                var nxtSibling = parentTable.nextSibling;

                if (nxtSibling && nxtSibling.nodeType == 1)//check if nxt sibling is not null & is an element node
                {
                    if (nxtSibling.tagName.toLowerCase() == "div") //if node has children
                    {
                        //check or uncheck children at all levels
                        CheckUncheckChildren(parentTable.nextSibling, src.checked);
                    }
                }
                //check or uncheck parents at all levels
                CheckUncheckParents(src, src.checked);
            }
        }
        function CheckUncheckChildren(childContainer, check) {

            var childChkBoxes = childContainer.getElementsByTagName("input");
            var childChkBoxCount = childChkBoxes.length;
            for (var i = 0; i < childChkBoxCount; i++) {
                //      alert(i);
                childChkBoxes[i].checked = check;
            }
        }

        function CheckUncheckParents(srcChild, check) {
            var parentDiv = GetParentByTagName("div", srcChild);
            var parentNodeTable = parentDiv.previousSibling;

            if (parentNodeTable) {
                var checkUncheckSwitch;

                if (check) //checkbox checked
                {
                    var isAllSiblingsChecked = AreAllSiblingsChecked(srcChild);
                    //if(isAllSiblingsChecked)
                    checkUncheckSwitch = true;
                    //else    
                    // return; //do not need to check parent if any(one or more) child not checked
                }
                else //checkbox unchecked
                {
                    var isAllSiblingsUnChecked = AreAllSiblingsUnChecked(srcChild);
                    if (isAllSiblingsUnChecked)
                        checkUncheckSwitch = false;
                    else
                        return;
                }

                var inpElemsInParentTable = parentNodeTable.getElementsByTagName("input");
                if (inpElemsInParentTable.length > 0) {
                    var parentNodeChkBox = inpElemsInParentTable[0];
                    parentNodeChkBox.checked = checkUncheckSwitch;
                    //do the same recursively
                    CheckUncheckParents(parentNodeChkBox, checkUncheckSwitch);
                }
            }
        }

        function AreAllSiblingsChecked(chkBox) {
            var parentDiv = GetParentByTagName("div", chkBox);
            var childCount = parentDiv.childNodes.length;
            for (var i = 0; i < childCount; i++) {
                if (parentDiv.childNodes[i].nodeType == 1) //check if the child node is an element node
                {
                    if (parentDiv.childNodes[i].tagName.toLowerCase() == "table") {
                        var prevChkBox = parentDiv.childNodes[i].getElementsByTagName("input")[0];
                        //if any of sibling nodes are not checked, return false
                        if (!prevChkBox.checked) {
                            return false;
                        }
                    }
                }
            }
            return true;
        }



        function AreAllSiblingsUnChecked(chkBox) {
            var parentDiv = GetParentByTagName("div", chkBox);
            var childCount = parentDiv.childNodes.length;
            for (var i = 0; i < childCount; i++) {
                if (parentDiv.childNodes[i].nodeType == 1) //check if the child node is an element node
                {
                    if (parentDiv.childNodes[i].tagName.toLowerCase() == "table") {
                        var prevChkBox = parentDiv.childNodes[i].getElementsByTagName("input")[0];
                        //if any of sibling nodes are not checked, return false
                        if (prevChkBox.checked) {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        //utility function to get the container of an element by tagname
        function GetParentByTagName(parentTagName, childElementObj) {

            var parent = childElementObj.parentNode;
            while (parent.tagName.toLowerCase() != parentTagName.toLowerCase()) {
                parent = parent.parentNode;
            }

            return parent;
        }

    </script>

</asp:Content>
