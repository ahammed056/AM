<%@ Page Language="C#" MasterPageFile="~/CMDB_Master.Master" AutoEventWireup="true"
    CodeBehind="Email_Configuration.aspx.cs" Inherits="TSTracker.RM.Menu.Email_Configuration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <CMDBUC:Feedback ID="Feedback" runat="server"></CMDBUC:Feedback>
    </div>
    <div>
        <fieldset>
            <legend>Email Configuration</legend>
            <div>
                <table width="80%">
                    <tr>
                        <td align="center">
                            <table cellpadding="2" cellspacing="2">
                                <tr align="left">
                                    <td>
                                        <asp:Label ID="lblSelectModule" runat="server" Text="Select Module" CssClass="labels"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlModule" runat="server" CssClass="ddClass" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlModule_SelectedIndexChanged">
                                            <asp:ListItem Value="-1" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1001" Text="ITDBA"></asp:ListItem>
                                            <asp:ListItem Value="1002" Text="ITDAPs"></asp:ListItem>
                                            <asp:ListItem Value="1003" Text="ITMW"></asp:ListItem>
                                            <asp:ListItem Value="1004" Text="ITSOC"></asp:ListItem>
                                            <asp:ListItem Value="1005" Text="ITStorage"></asp:ListItem>
                                            <asp:ListItem Value="1006" Text="ITUNIX"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblApprovalLevel" runat="server" Text="Approval Level" CssClass="labels"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlApprovalLevel" runat="server" CssClass="ddClass" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlApprovalLevel_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="L1" Text="L1"></asp:ListItem>
                                            <asp:ListItem Value="L2" Text="L2"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <%-- <td align="left">
                                        <asp:RequiredFieldValidator ID="rfvddlApprovalLevel" runat="server" ControlToValidate="ddlApprovalLevel"
                                            ErrorMessage="Please select Approval Level." ValidationGroup="AddNewRecord" InitialValue="-1"
                                            SetFocusOnError="true" Display="Dynamic">*</asp:RequiredFieldValidator>
                                    </td>--%>
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
                                    <tr id="traddnewfields" runat="server" visible="false">
                                        <td align="center">
                                            <fieldset>
                                                <legend>
                                                    <asp:Label ID="lblAddNew" runat="server" Text="Add New"></asp:Label>
                                                </legend>
                                                <table>
                                                    <tr id="trEmailentry" runat="server" visible="false">
                                                        <td align="left">
                                                            <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="labels"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="textboxMultiline" TextMode="MultiLine"></asp:TextBox>
                                                        </td>
                                                        <td align="left">
                                                            <asp:RequiredFieldValidator ID="rfvtxtEmail" runat="server" ControlToValidate="txtEmail"
                                                                ErrorMessage="Please enter EmailId separated by comma(,)." ValidationGroup="AddNewRecord"
                                                                Display="Dynamic">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr id="trEmailsubmit" runat="server" visible="false">
                                                        <td align="left">
                                                            <asp:ValidationSummary ID="vsSubmitRecord" runat="server" ValidationGroup="AddNewRecord"
                                                                DisplayMode="List" ShowMessageBox="true" ShowSummary="false" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="AddNewRecord"
                                                                CssClass="buttons" />
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                        </td>
                                    </tr>
                                    <%-- <tr>
                                        <td align="center">
                                            &nbsp;
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td align="center">
                                            <fieldset>
                                                <legend>
                                                    <asp:Label ID="lblLegend" runat="server" Text="Manage Emails"></asp:Label>
                                                </legend>
                                                <div>
                                                    <asp:Label ID="lblRecords" runat="server" Text="" CssClass="labels"></asp:Label>
                                                </div>
                                                <div class="gridviewDiv">
                                                    <asp:GridView ID="gvMaster" runat="server" CssClass="GridViewStyle" OnRowEditing="gvMaster_RowEditing"
                                                        OnRowUpdating="gvMaster_RowUpdating" OnRowCancelingEdit="gvMaster_RowCancelingEdit"
                                                        AllowPaging="true" PageSize="10" OnPageIndexChanging="gvMaster_PageIndexChanging"
                                                        AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Approver Level">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAprLevel" runat="server" Text='<%# Bind("ApprovalType") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Email ID('s)" ItemStyle-Width="460px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("EmailID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblEditEmail" runat="server" Text='<%# Bind("EmailID") %>' Style="display: none;"></asp:Label>
                                                                    <asp:TextBox ID="txtEditEmail" runat="server" CssClass="textboxLongMultiline" TextMode="MultiLine"
                                                                        Width="400px" Height="50px" Text='<%# Bind("EmailID") %>'></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvtxtEditEmail" runat="server" ControlToValidate="txtEditEmail"
                                                                        ErrorMessage="Please enter Email ID('s)" ValidationGroup="EditRecord" SetFocusOnError="true"
                                                                        Text="*"></asp:RequiredFieldValidator>
                                                                </EditItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Modify" ItemStyle-Width="60px">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="imgbtnEdit" runat="server" CommandName="Edit" ToolTip="Edit"
                                                                        AlternateText="Edit" ImageUrl="~/App_Themes/DefaultTheme/Images/GridEdit.gif" />
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:ImageButton ID="imgbtnUpdate" runat="server" CommandName="Update" CommandArgument='<%# Eval("ApprovalType") %>'
                                                                        ValidationGroup="EditRecord" ToolTip="Update" AlternateText="Update" ImageUrl="~/App_Themes/DefaultTheme/Images/GridUpdate.gif" />
                                                                    <asp:ValidationSummary ID="vsEditMaster" runat="server" ValidationGroup="EditRecord"
                                                                        ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
                                                                    <asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" ToolTip="Cancel Edit"
                                                                        AlternateText="Cancel Edit" ImageUrl="~/App_Themes/DefaultTheme/Images/GridCancel.gif" />
                                                                </EditItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <FooterStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <RowStyle CssClass="RowStyle_lowheight" Width="90%" />
                                                        <FooterStyle CssClass="FooterStyle" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                        <PagerStyle CssClass="PagerStyle" />
                                                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                                                        <HeaderStyle CssClass="HeaderStyle" />
                                                        <EditRowStyle CssClass="EditRowStyle" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <AlternatingRowStyle CssClass="AltRowStyle_lowheight" />
                                                    </asp:GridView>
                                                </div>
                                                <br />
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
