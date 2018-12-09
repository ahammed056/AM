<%@ Page Title="" Language="C#" MasterPageFile="~/TS_Master.Master" AutoEventWireup="true"
    CodeBehind="Menu_Manage.aspx.cs" Inherits="TSTracker.RM.Menu.Menu_Manage" %>

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
                    <legend>Manage Menus</legend>
                    <div>
                        <table width="100%">
                            <tr>
                                <td align="center">
                                    <table cellpadding="2" cellspacing="2">
                                        <tr>
                                            <td align="left" valign="middle">
                                                <asp:Label ID="Label1" CssClass="labels" Text="Menu Name" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSearchbox" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                                                <aspx:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtSearchbox"
                                                    FilterMode="InvalidChars" InvalidChars="'!,@?>[]<*{}:\&;=^%$#@~`)(+_-./|" runat="server" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="buttons" OnClick="btnSearch_Click" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="buttons" OnClick="btnClear_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:Label ID="lblEmpty" CssClass="EmptyRowStyle" Text="No Data Found" runat="server"
                                                    Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:UpdatePanel ID="updatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:Panel ID="Panel1" runat="server">
                                                <table cellpadding="2" cellspacing="2">
                                                    <tr>
                                                        <td style="width: 1%">
                                                        </td>
                                                        <td align="left" valign="middle" style="width: 10%">
                                                            <asp:Label ID="lblHeading" CssClass="labels" runat="server" Text="Add Menu"></asp:Label>
                                                        </td>
                                                        <td style="width: 1%">
                                                        </td>
                                                        <td align="left" valign="middle" style="width: 10%">
                                                            <asp:Label ID="lblMainMenu" CssClass="labels" runat="server" Text="Main Menu"></asp:Label>
                                                        </td>
                                                        <td style="width: 1%">
                                                        </td>
                                                        <td align="left" valign="middle" style="width: 10%">
                                                            <asp:Label ID="lblSubMenu" CssClass="labels" runat="server" Text="Sub Menu" Visible="False"></asp:Label>
                                                        </td>
                                                        <td style="width: 1%">
                                                        </td>
                                                        <td align="left" valign="middle" style="width: 10%">
                                                            <asp:Label ID="lblChildMenu" CssClass="labels" runat="server" Text="Present Child Menus"
                                                                Visible="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 1%">
                                                        </td>
                                                        <td align="left" valign="top" style="width: 10%">
                                                            &nbsp;
                                                        </td>
                                                        <td style="width: 1%">
                                                        </td>
                                                        <td align="left" valign="top" style="width: 10%">
                                                            <asp:DropDownList ID="ddlMainMenu" runat="server" AutoPostBack="true" CssClass="ddClass"
                                                                OnSelectedIndexChanged="ddlMainMenu_SelectedIndexChanged" Style="width: 95%">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 1%">
                                                        </td>
                                                        <td align="left" valign="top" style="width: 10%">
                                                            <asp:DropDownList ID="ddlSubMenu" runat="server" AutoPostBack="true" CssClass="ddClass"
                                                                OnSelectedIndexChanged="ddlSubMenu_SelectedIndexChanged" Style="width: 95%" Visible="False">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 1%">
                                                        </td>
                                                        <td align="left" valign="top" style="width: 10%">
                                                            <asp:DropDownList ID="ddlChildMenu" runat="server" AutoPostBack="false" CssClass="ddClass"
                                                                Style="width: 95%" Visible="False">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 1%">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 1%">
                                                        </td>
                                                        <td align="left" valign="middle" style="width: 10%">
                                                            <asp:Label ID="lblManuName" runat="server" CssClass="labels" Text="Enter Menu Name"></asp:Label>
                                                        </td>
                                                        <td style="width: 1%">
                                                        </td>
                                                        <td align="left" valign="middle" style="width: 10%">
                                                            <asp:Label ID="lblManuUrl" runat="server" CssClass="labels" Text="Enter Menu URL"></asp:Label>
                                                        </td>
                                                        <td style="width: 1%">
                                                        </td>
                                                        <td align="left" valign="middle" style="width: 10%">
                                                            <asp:Label ID="lblToolTip" runat="server" CssClass="labels" Text="Tool Tip Text"></asp:Label>
                                                        </td>
                                                        <td style="width: 1%">
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 1%">
                                                        </td>
                                                        <td align="left" valign="top" style="width: 10%">
                                                            <asp:TextBox ID="txtMenuName" runat="server" CssClass="textbox" Style="width: 95%"> </asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvmenuname" runat="server" ControlToValidate="txtMenuName"
                                                                Display="Dynamic" ErrorMessage="Menu Name" Font-Bold="False" Font-Size="8pt"
                                                                ValidationGroup="VGSubmit">*</asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="erevreport_menuname" runat="server" ErrorMessage="Name cannot contain special characters"
                                                                ValidationGroup="VGSubmit" SetFocusOnError="true" ControlToValidate="txtMenuName"
                                                                ValidationExpression="^[a-zA-Z0-9 ]+$">*</asp:RegularExpressionValidator>
                                                            <aspx:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txtMenuName"
                                                                FilterMode="InvalidChars" InvalidChars="'!,@?>[]<*{}:\&;=^%$#@~`)(+-|" runat="server" />
                                                        </td>
                                                        <td style="width: 1%">
                                                        </td>
                                                        <td align="left" valign="top" style="width: 10%">
                                                            <asp:TextBox ID="txtManuURL" runat="server" CssClass="textbox" Style="width: 95%">
                                                            </asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvmenuurl" runat="server" ControlToValidate="txtManuURL"
                                                                Display="Dynamic" ErrorMessage="Menu URL" Font-Bold="False" Font-Size="8pt" ValidationGroup="VGSubmit">*</asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Name cannot contain special characters"
                                                                ValidationGroup="VGSubmit" SetFocusOnError="true" ControlToValidate="txtManuURL"
                                                                ValidationExpression="^[a-zA-Z0-9./~_]+$">*</asp:RegularExpressionValidator>
                                                            <aspx:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txtManuURL"
                                                                FilterMode="InvalidChars" InvalidChars="'!,@>[]<*{}:\;^%$#`)(+|" runat="server" />
                                                        </td>
                                                        <td style="width: 1%">
                                                        </td>
                                                        <td align="left" valign="top" style="width: 10%">
                                                            <asp:TextBox ID="txtToolTip" runat="server" CssClass="textbox" Style="width: 95%"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvtooltip" runat="server" ControlToValidate="txtToolTip"
                                                                Display="Dynamic" ErrorMessage="Tool Tip" Font-Bold="False" Font-Size="8pt" ValidationGroup="VGSubmit">*</asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="ToolTip cannot contain special characters"
                                                                ValidationGroup="VGSubmit" SetFocusOnError="true" ControlToValidate="txtToolTip"
                                                                ValidationExpression="^[a-zA-Z0-9 ]+$">*</asp:RegularExpressionValidator>
                                                            <aspx:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" TargetControlID="txtToolTip"
                                                                FilterMode="InvalidChars" InvalidChars="'!,@?>[]<*{}:\&;=^%$#@~`)(+_-./|" runat="server" />
                                                        </td>
                                                        <td style="width: 1%">
                                                        </td>
                                                        <td align="left">
                                                            <asp:Button ID="btnADD" runat="server" Text="Add Menu" CssClass="buttons" ValidationGroup="VGSubmit"
                                                                OnClick="btnADD_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <div style="clear: none; overflow: auto; width: auto; height: 400px">
                                        <asp:GridView ID="gvComapny" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                                            ShowFooter="false" OnRowCommand="gvComapny_RowCommand" CssClass="GridViewStyle"
                                            OnRowCancelingEdit="gvComapny_RowCancelingEdit" AllowPaging="true" PageSize="10"
                                            OnRowEditing="gvComapny_RowEditing" OnRowUpdating="gvComapny_RowUpdating" OnRowDeleting="gvComapny_RowDeleting"
                                            BorderWidth="1" Width="96%" HeaderStyle-CssClass="HeaderStyle" OnPageIndexChanging="gvComapny_PageIndexChanging"
                                            EmptyDataText="No Data Found" OnRowDataBound="gvComapny_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="SlNo" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSno0" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblciID0" runat="server" maxlength="8" Text='<%# Bind("ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Parent Menu Name" SortExpression="Parent_menu_name"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lbleditParent_menu_name0" runat="server" Text='<%# Bind("Parent_menu_name") %>'
                                                            Width="150"></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblParent_menu_name0" runat="server" Text='<%# Bind("Parent_menu_name") %>'
                                                            Width="150"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Menu Name" SortExpression="menu_name" ItemStyle-HorizontalAlign="Left">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEditmenu_name" runat="server" CssClass="textbox" MaxLength="200"
                                                            Text='<%# Bind("menu_name") %>'></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="erfvEditmenu_name0" runat="server" ErrorMessage="Enter ACTIVITY_DESCRIPTION"
                                                            ValidationGroup="CompEdit" SetFocusOnError="true" ControlToValidate="txtEditmenu_name">*</asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator runat="server" ID="erevEditmenu_name0" ValidationExpression="^[a-zA-Z0-9.,-_()&$; ]*$"
                                                            ErrorMessage="Report Name is not Valid" ValidationGroup="CompEdit" ControlToValidate="txtEditmenu_name">*</asp:RegularExpressionValidator>
                                                        <aspx:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" TargetControlID="txtEditmenu_name"
                                                            FilterMode="InvalidChars" InvalidChars="'!,@?>[]<*{}:\&;=^%$#@~`)(+_-./|" runat="server" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblmenu_name0" runat="server" Text='<%# Bind("menu_name") %>' Width="150"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Menu URL" SortExpression="menu_url" ItemStyle-HorizontalAlign="Left">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEditmenu_url" runat="server" CssClass="textbox" MaxLength="200"
                                                            Text='<%# Bind("menu_url") %>'></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="erfvEditmenu_url0" runat="server" ErrorMessage="Enter ACTIVITY_DESCRIPTION"
                                                            ValidationGroup="CompEdit" SetFocusOnError="true" ControlToValidate="txtEditmenu_url">*</asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator runat="server" ID="erevEditmenu_url0" ValidationExpression="^[a-zA-Z0-9.,-_()&$#/.~; ]*$"
                                                            ErrorMessage="Report Name is not Valid" ValidationGroup="CompEdit" ControlToValidate="txtEditmenu_url">*</asp:RegularExpressionValidator>
                                                        <aspx:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txtEditmenu_url"
                                                            FilterMode="InvalidChars" InvalidChars="'!,@>[]<*{}:\;^%$#`)(+|" runat="server" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblmenu_url0" runat="server" Text='<%# Bind("menu_url") %>' Width="150"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tool Tip Text" SortExpression="tool_tip_text" ItemStyle-HorizontalAlign="Left">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEdittool_tip_text" runat="server" CssClass="textbox" MaxLength="200"
                                                            Text='<%# Bind("tool_tip_text") %>'></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="erfvEdittool_tip_text0" runat="server" ErrorMessage="Enter ACTIVITY_DESCRIPTION"
                                                            ValidationGroup="CompEdit" SetFocusOnError="true" ControlToValidate="txtEdittool_tip_text">*</asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator runat="server" ID="erevEdittool_tip_text0" ValidationExpression="^[a-zA-Z0-9.,-_()&$; ]*$"
                                                            ErrorMessage="Report Name is not Valid" ValidationGroup="CompEdit" ControlToValidate="txtEdittool_tip_text">*</asp:RegularExpressionValidator>
                                                        <aspx:FilteredTextBoxExtender ID="ssfsdfs" TargetControlID="txtEdittool_tip_text"
                                                            FilterMode="InvalidChars" InvalidChars="'!,@?>[]<*{}:\&;=^%$#@~`)(+_-./|" runat="server" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbltool_tip_text0" runat="server" Text='<%# Bind("tool_tip_text") %>'
                                                            Width="150"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Modify">
                                                    <EditItemTemplate>
                                                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="True" ValidationGroup="CompEdit"
                                                            ToolTip="Save" CommandName="Update" Text="Update"><img alt="Save" src="../../App_Themes/DefaultTheme/Images/GridUpdate.gif"  style="border:0px;" /></asp:LinkButton>
                                                        &nbsp;<asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" ToolTip="Cancel"
                                                            CommandName="Cancel" Text="Cancel"><img alt="Cancel" src="../../App_Themes/DefaultTheme/Images/GridCancel.gif" style="border:0px;" /></asp:LinkButton>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="False" ToolTip="Modify"
                                                            CommandName="Edit" Text="Edit"><img alt="Edit" src="../../App_Themes/DefaultTheme/Images/GridEdit.gif" style="border:0px;"/></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <FooterStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" ButtonType="Image"
                                                    DeleteImageUrl="../../App_Themes/DefaultTheme/Images/GridDelete.gif" Visible="false" />
                                            </Columns>
                                            <RowStyle CssClass="RowStyle_lowheight" />
                                            <FooterStyle CssClass="FooterStyle" HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                            <PagerStyle CssClass="PagerStyle" />
                                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                                            <HeaderStyle CssClass="HeaderStyle" />
                                            <EditRowStyle CssClass="EditRowStyle" HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <AlternatingRowStyle CssClass="AltRowStyle_lowheight" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </fieldset>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
