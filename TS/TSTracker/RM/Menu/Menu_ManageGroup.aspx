<%@ Page Title="" Language="C#" MasterPageFile="~/TS_Master.Master" AutoEventWireup="true"
    CodeBehind="Menu_ManageGroup.aspx.cs" Inherits="TSTracker.RM.Menu.Menu_ManageGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div>
                <CMDBUC:Feedback ID="Feedback" runat="server"></CMDBUC:Feedback>
            </div>
            <div class="breakDiv">
            </div>
            <div>
                <fieldset>
                    <legend>Manage Groups</legend>
                    <div>
                        <table width="100%">
                            <tr>
                                <td align="center">
                                    <table cellpadding="2" cellspacing="2">
                                        <tr>
                                            <td align="left" valign="middle">
                                                <asp:Label ID="Label1" CssClass="labels" Text="Group Name" runat="server"></asp:Label>
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:TextBox ID="txtSearchbox" CssClass="textbox" runat="server" MaxLength="50"></asp:TextBox>
                                                <aspx:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="txtSearchbox"
                                                    FilterMode="InvalidChars" InvalidChars="'!,@?>[]<*{}:\&;=^%$#@~`)(+_-./|" runat="server" />
                                            </td>
                                            <td align="left" valign="middle">
                                                &nbsp;
                                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="buttons" OnClick="btnSearch_OnClick" />
                                            </td>
                                            <td align="left" valign="middle">
                                                &nbsp;
                                                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="buttons" OnClick="btnClear_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Label ID="lblEmpty" CssClass="EmptyRowStyle" Text="No Group Found" runat="server"
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
                                                <asp:TemplateField HeaderText="S.No" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="90px">
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
                                                <asp:TemplateField HeaderText="Group Name" SortExpression="Group_Name" ItemStyle-HorizontalAlign="Left">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEditGroup_Name" runat="server" CssClass="textbox" MaxLength="50"
                                                            Text='<%# Bind("GroupName") %>'></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="erfvreport_name" runat="server" ErrorMessage="Enter ACTIVITY_DESCRIPTION"
                                                            ValidationGroup="CompEdit" SetFocusOnError="true" ControlToValidate="txtEditGroup_Name">*</asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator runat="server" ID="erevreport_name" ValidationExpression="^[a-zA-Z0-9.,-_()&$; ]*$"
                                                            ErrorMessage="Group Name is not Valid" ValidationGroup="CompEdit" ControlToValidate="txtEditGroup_Name">*</asp:RegularExpressionValidator>
                                                        <aspx:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="txtEditGroup_Name"
                                                            FilterMode="InvalidChars" InvalidChars="'!,@?>[]<*{}:\&;=^%$#@~`)(+_-./|" runat="server" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblreport_name" Text="" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtGroup_Name" runat="server" MaxLength="50" CssClass="textbox"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="frfvreport_name" runat="server" SetFocusOnError="true"
                                                            ValidationGroup="CompAdd" ErrorMessage="Enter Company Name" ControlToValidate="txtGroup_Name">*</asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator runat="server" ID="frevreport_name" ValidationExpression="^[a-zA-Z0-9.,-_()&$; ]*$"
                                                            ErrorMessage="Group Name is not Valid" ValidationGroup="CompAdd" ControlToValidate="txtGroup_Name">*</asp:RegularExpressionValidator>
                                                        <aspx:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="txtGroup_Name"
                                                            FilterMode="InvalidChars" InvalidChars="'!,@?>[]<*{}:\&;=^%$#@~`)(+_-./|" runat="server" />
                                                    </FooterTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblreport_name" runat="server" Text='<%# Bind("GroupName") %>' Width="150"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Modify" HeaderStyle-Width="90px">
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
                                                    <ItemStyle HorizontalAlign="Center" />
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
