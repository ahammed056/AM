<%@ Page Title="" Language="C#" MasterPageFile="~/TS_Master.Master" AutoEventWireup="true"
    CodeBehind="TS_ManageMaster.aspx.cs" Inherits="TSTracker.RM.TS.TS_ManageMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <CMDBUC:Feedback ID="Feedback" runat="server"></CMDBUC:Feedback>
    </div>
    <div class="breakDiv">
    </div>
    <div>
        <fieldset>
            <legend>TS :: Master Configuration</legend>
            <div>
                <table width="80%">
                    <tr>
                        <td align="center">
                            <table cellpadding="2" cellspacing="2">
                                <tr align="left">
                                    <td>
                                        <asp:Label ID="lblSelectMaster" runat="server" Text="Select Master" CssClass="labels"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlMaster" runat="server" CssClass="ddClass" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlMaster_SelectedIndexChanged">
                                            <asp:ListItem Value="-1" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1001" Text="Task"></asp:ListItem>
                                            <asp:ListItem Value="1002" Text="Application"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <div id="divMaster" runat="server" visible="false">
                                <table width="90%">
                                    <tr>
                                        <td align="center">
                                            <fieldset>
                                                <legend>
                                                    <asp:Label ID="lblAddNew" runat="server" Text="Add New"></asp:Label>
                                                </legend>
                                                <table>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblName" runat="server" Text="Name" CssClass="labels"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtName" runat="server" CssClass="textbox"></asp:TextBox>
                                                        </td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="rfvtxtName" runat="server" ControlToValidate="txtName"
                                                                ErrorMessage="Please enter name" ValidationGroup="SubmitRecord" SetFocusOnError="true"
                                                                Text="*"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="labels"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtDescription" runat="server" CssClass="textbox"></asp:TextBox>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:ValidationSummary ID="vsSubmitRecord" runat="server" ValidationGroup="SubmitRecord"
                                                                DisplayMode="List" ShowMessageBox="true" ShowSummary="false" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="SubmitRecord"
                                                                OnClick="btnSubmit_Click" CssClass="buttons" />
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <fieldset>
                                                <legend>
                                                    <asp:Label ID="lblLegend" runat="server" Text="Manage Master"></asp:Label>
                                                </legend>
                                                <div>
                                                    <asp:Label ID="lblRecords" runat="server" Text="" CssClass="labelsFormatted"></asp:Label>
                                                </div>
                                                <div class="gridviewDiv">
                                                    <asp:GridView ID="gvMaster" runat="server" CssClass="GridViewStyle" OnRowEditing="gvMaster_RowEditing"
                                                        OnRowUpdating="gvMaster_RowUpdating" OnRowDeleting="gvMaster_RowDeleting" OnRowCancelingEdit="gvMaster_RowCancelingEdit"
                                                        AutoGenerateColumns="false" AllowPaging="true" PageSize="15" OnPageIndexChanging="gvMaster_PageIndexChanging">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblEditName" runat="server" Text='<%# Bind("Name") %>' Style="display: none;"></asp:Label>
                                                                    <asp:TextBox ID="txtEditName" runat="server" CssClass="textbox" Text='<%# Bind("Name") %>'></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvtxtEditName" runat="server" ControlToValidate="txtEditName"
                                                                        ErrorMessage="Please enter name" ValidationGroup="EditRecord" SetFocusOnError="true"
                                                                        Text="*"></asp:RequiredFieldValidator>
                                                                </EditItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Description">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtEditDescription" runat="server" CssClass="textbox" Text='<%# Bind("Description") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Modify" ItemStyle-Width="60px">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="imgbtnEdit" runat="server" CommandName="Edit" ToolTip="Edit"
                                                                        AlternateText="Edit" ImageUrl="~/App_Themes/DefaultTheme/Images/GridEdit.gif" />
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:ImageButton ID="imgbtnUpdate" runat="server" CommandName="Update" CommandArgument='<%# Eval("ID") %>'
                                                                        ValidationGroup="EditRecord" ToolTip="Update" AlternateText="Update" ImageUrl="~/App_Themes/DefaultTheme/Images/GridUpdate.gif" />
                                                                    <asp:ValidationSummary ID="vsEditMaster" runat="server" ValidationGroup="EditRecord"
                                                                        ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
                                                                    <asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" ToolTip="Cancel Edit"
                                                                        AlternateText="Cancel Edit" ImageUrl="~/App_Themes/DefaultTheme/Images/GridCancel.gif" />
                                                                </EditItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <FooterStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete" ItemStyle-Width="60px" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="imgbtnDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("ID") %>'
                                                                        ToolTip="Delete" AlternateText="Delete" ImageUrl="~/App_Themes/DefaultTheme/Images/GridDelete.gif"
                                                                        OnClientClick="return confirm('Are you sure you want to continue?');" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <RowStyle CssClass="RowStyle_lowheight_wrap" Width="90%" />
                                                        <FooterStyle CssClass="FooterStyle" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                        <PagerStyle CssClass="PagerStyle" />
                                                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                                                        <HeaderStyle CssClass="HeaderStyle" />
                                                        <EditRowStyle CssClass="EditRowStyle" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <AlternatingRowStyle CssClass="AltRowStyle_lowheight_wrap" />
                                                    </asp:GridView>
                                                </div>
                                            </fieldset>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </fieldset>
    </div>
</asp:Content>
