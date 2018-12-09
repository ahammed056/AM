<%@ Page Title="" Language="C#" MasterPageFile="~/TS_Master.Master" AutoEventWireup="true"
    CodeBehind="Menu_ManageUser.aspx.cs" Inherits="TSTracker.RM.Menu.Menu_ManageUser" %>

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
                    <legend>Manage Users</legend>
                    <div>
                        <table width="100%">
                            <tr>
                                <td align="center">
                                    <table cellpadding="2" cellspacing="2">
                                        <tr>
                                            <td align="left" valign="middle">
                                                <asp:Label ID="Label1" CssClass="labels" Text="User ID" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSearchbox" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                                                <aspx:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" TargetControlID="txtSearchbox"
                                                    FilterMode="InvalidChars" InvalidChars="'!,@?>[]<*{}:\&;=^%$#@~`)(+_-./|" runat="server" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="buttons" OnClick="btnSearch_OnClick" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="buttons" OnClick="btnClear_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Label ID="lblEmpty" CssClass="EmptyRowStyle" Text="No Data Found" runat="server"
                                                    Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <div style="clear: none; overflow: auto; width: auto; height: 400px">
                                        <asp:GridView ID="gvComapny" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                                            ShowFooter="true" OnRowCommand="gvComapny_RowCommand" CssClass="GridViewStyle"
                                            OnRowCancelingEdit="gvComapny_RowCancelingEdit" AllowPaging="true" PageSize="10"
                                            OnRowEditing="gvComapny_RowEditing" OnRowUpdating="gvComapny_RowUpdating" OnRowDeleting="gvComapny_RowDeleting"
                                            BorderWidth="1" Width="96%" HeaderStyle-CssClass="HeaderStyle" OnPageIndexChanging="gvComapny_PageIndexChanging"
                                            EmptyDataText="No Data Found" OnRowDataBound="gvComapny_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblciID" runat="server" maxlength="8" Text='<%# Bind("ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="User ID" SortExpression="UserID" ItemStyle-HorizontalAlign="Left">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEditUserID" runat="server" CssClass="textbox" MaxLength="200"
                                                            Text='<%# Bind("UserID") %>'></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="erfvEditUserID" runat="server" ErrorMessage="*" ValidationGroup="CompEdit"
                                                            SetFocusOnError="true" ControlToValidate="txtEditUserID">*</asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator runat="server" ID="erevEditUserID" ValidationExpression="^[a-zA-Z0-9.,-_()&$; ]*$"
                                                            ErrorMessage="*" ValidationGroup="CompEdit" ControlToValidate="txtEditUserID"></asp:RegularExpressionValidator>
                                                        <aspx:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" TargetControlID="txtEditUserID"
                                                            FilterMode="InvalidChars" InvalidChars="'!,@?>[]<*{}:\&;=^%$#@~`)(+_-./|" runat="server" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblUserID" Text="" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtUserID" runat="server" CssClass="textbox" MaxLength="200" Width="150"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="erfvUserID" runat="server" SetFocusOnError="true"
                                                            ValidationGroup="CompAdd" ErrorMessage="Enter Company Name" ControlToValidate="txtUserID">*</asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator runat="server" ID="erevEditUserID" ValidationExpression="^[a-zA-Z0-9.,-_()&$; ]*$"
                                                            ErrorMessage="*" ValidationGroup="CompAdd" ControlToValidate="txtUserID"></asp:RegularExpressionValidator>
                                                        <aspx:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" TargetControlID="txtUserID"
                                                            FilterMode="InvalidChars" InvalidChars="'!,@?>[]<*{}:\&;=^%$#@~`)(+_-./|" runat="server" />
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUserID" runat="server" Text='<%# Bind("UserID") %>' Width="150"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="User Name" SortExpression="UserName" ItemStyle-HorizontalAlign="Left">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEditUserName" runat="server" CssClass="textbox" MaxLength="200"
                                                            Text='<%# Bind("UserName") %>'></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="erfvEditUserName" runat="server" ErrorMessage="*"
                                                            ValidationGroup="CompEdit" SetFocusOnError="true" ControlToValidate="txtEditUserName">*</asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator runat="server" ID="erevEditUserName" ValidationExpression="^[a-zA-Z0-9.,-_()&$; ]*$"
                                                            ErrorMessage="*" ValidationGroup="CompEdit" ControlToValidate="txtEditUserName">*</asp:RegularExpressionValidator>
                                                        <aspx:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txtEditUserName"
                                                            FilterMode="InvalidChars" InvalidChars="'!@?>[]<*{}:\&;=^%$#@~`)(+_-./|" runat="server" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblUserName" Text="" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtUserName" runat="server" CssClass="textbox" MaxLength="200" Width="150"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="erfvUserName" runat="server" SetFocusOnError="true"
                                                            ValidationGroup="CompAdd" ErrorMessage="Enter Company Name" ControlToValidate="txtUserName">*</asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator runat="server" ID="erevEditUserName" ValidationExpression="^[a-zA-Z0-9.,-_()&$; ]*$"
                                                            ErrorMessage="User Name is not Valid" ValidationGroup="CompAdd" ControlToValidate="txtUserName">*</asp:RegularExpressionValidator>
                                                        <aspx:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txtUserName"
                                                            FilterMode="InvalidChars" InvalidChars="'!@?>[]<*{}:\&;=^%$#@~`)(+_-./|" runat="server" />
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("UserName") %>' Width="150"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Password" Visible="false" SortExpression="Password"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEditPassword" runat="server" CssClass="textbox" MaxLength="200"
                                                            Text="" TextMode="Password"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblPassword" Text="" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="textbox" MaxLength="200" Width="150"
                                                            TextMode="Password" Text=""></asp:TextBox>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPassword" runat="server" Text='**************' Width="150"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Group Name" SortExpression="GroupID_fk" ItemStyle-HorizontalAlign="Left">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddleditGroupID_fk" runat="server" CssClass="ddClassLong">
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlGroupID_fk" runat="server" CssClass="ddClassLong">
                                                        </asp:DropDownList>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGroupID_fk" runat="server" Text='<%# Bind("GroupID_fk") %>' Width="150"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Domain" SortExpression="Domain" ItemStyle-HorizontalAlign="Left" Visible="false">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="txtEditDomain" runat="server" CssClass="ddClassLong">
                                                            <asp:ListItem Text="Indcorp" Value="Indcorp" />
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddldomain_footer" runat="server" CssClass="ddClassLong">
                                                            <asp:ListItem Text="Indcorp" Value="Indcorp" />
                                                        </asp:DropDownList>
                                                        <asp:Label ID="lblGroupID_fk" runat="server" Text='<%# Bind("GroupID_fk") %>'></asp:Label>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDomain" runat="server" Text='<%# Bind("Domain") %>' Width="150"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Modify">
                                                    <EditItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" ValidationGroup="CompEdit"
                                                            ToolTip="Save" CommandName="Update" Text="Update"><img alt="Save" src="../../App_Themes/DefaultTheme/Images/GridUpdate.gif"  style="border:0px;" /></asp:LinkButton>
                                                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" ToolTip="Cancel"
                                                            CommandName="Cancel" Text="Cancel"><img alt="Cancel" src="../../App_Themes/DefaultTheme/Images/GridCancel.gif" style="border:0px;" /></asp:LinkButton>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:LinkButton ID="LinkButton3" runat="server" CommandName="AddNew" CausesValidation="true"
                                                            ValidationGroup="CompAdd" ToolTip="Add New Company"><img alt="Add New" src="../../App_Themes/DefaultTheme/Images/GridAdd.gif" style="border-color:White" /></asp:LinkButton>
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" ToolTip="Modify"
                                                            CommandName="Edit" Text="Edit"><img alt="Edit" src="../../App_Themes/DefaultTheme/Images/GridEdit.gif" style="border:0px;"/></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <FooterStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" ButtonType="Image"
                                                    DeleteImageUrl="../../App_Themes/DefaultTheme/Images/GridDelete.gif" Visible="false" />
                                            </Columns>
                                            <RowStyle CssClass="RowStyle_lowheight" />
                                            <FooterStyle CssClass="FooterStyle" HorizontalAlign="Left" VerticalAlign="Top" />
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
