<%@ Page Title="" Language="C#" MasterPageFile="~/TS_Master.Master" AutoEventWireup="true"
    CodeBehind="TS_Mgmt.aspx.cs" Inherits="TSTracker.RM.TS.TS_Mgmt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">

        function AfterPostBackInit() {

            var dtDate = new Date();
            var curr_year = dtDate.getFullYear();
            curr_year = curr_year + 40;

            // ** Add Validation rules for controls of type "Date" ** //
            $("*[IsDateType]").each(function() {
                //Add datepicker
                $(this).datepicker({
                    yearRange: '1960:' + curr_year,
                    dateFormat: 'dd/mm/yy',
                    changeMonth: true,
                    changeYear: true,
                    gotoCurrent: true,
                    showButtonPanel: false,
                    onClose: function() {
                        $(this).focus();
                    },
                    showOn: 'button'
                }).next('button').css('height', '15px').text('').button({
                    icons: { primary: 'ui-icon-calendar' },
                    text: false
                });
                //Restrict Textbox Entry
                $(this).keydown(function(e) {
                    var charCode = e.keyCode || e.which;
                    if (charCode == 9)
                        return true;
                    else
                        return false;
                });
                //Decrease the textbox width
                $(this).css("width", "120px");
            });

            // ** Add class for td  ** //
            $("table.labels tbody tr td:nth-child(1)").addClass("tdLabels");
            $("table.labels tbody tr td:nth-child(2)").addClass("tdControls");
            $("table.labels tbody tr td:nth-child(3)").addClass("tdErrors");
            $("table.labels tbody tr td:nth-child(4)").addClass("tdLabels");
            $("table.labels tbody tr td:nth-child(5)").addClass("tdControls");
            $("table.labels tbody tr td:nth-child(6)").addClass("tdErrors");
            $(".tdheader").css("background-color", "#006699");
            $(".trheader").css("background-color", "#006699");
        }

        // Run AfterPostBackInit() when the page loads and after every post-back.
        Sys.Application.add_load(AfterPostBackInit);

    </script>

    <asp:UpdatePanel ID="mainup" runat="server">
        <ContentTemplate>
            <div>
                <CMDBUC:Feedback ID="Feedback" runat="server"></CMDBUC:Feedback>
            </div>
            <%--   <div class="breakDiv">
            </div>--%>
            <table style="width: 90%;">
                <tr>
                    <td align="left">
                        <div id="divMaster" runat="server">
                            <table width="90%">
                                <tr>
                                    <td class="tdheader">
                                        Enter Effort Details
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <table>
                                            <tr>
                                                <td>
                                                    Task Name
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlTask" runat="server" CssClass="ddClassMedium">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfvddlTask" runat="server" ControlToValidate="ddlTask"
                                                        ErrorMessage="Please select Task." Font-Bold="False" Font-Names="Tahoma" Font-Size="8pt"
                                                        InitialValue="-1" ValidationGroup="g1" SetFocusOnError="true" Display="Dynamic">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Project
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlApp" runat="server" CssClass="ddClassMedium">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfvddlApp" runat="server" ControlToValidate="ddlApp"
                                                        ErrorMessage="Please select Application." Font-Bold="False" Font-Names="Tahoma"
                                                        Font-Size="8pt" InitialValue="-1" ValidationGroup="g1" SetFocusOnError="true"
                                                        Display="Dynamic">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Description
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Height="50px" CssClass="textboxMultiline"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfvtxtDesc" runat="server" ControlToValidate="txtDesc"
                                                        ErrorMessage="Please enter Description." ValidationGroup="g1" SetFocusOnError="true"
                                                        Text="*"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Date
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDate" runat="server" CssClass="textbox" IsDateType="true"></asp:TextBox>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Effort
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTime" runat="server" CssClass="textbox"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfvtxtTime" runat="server" ControlToValidate="txtTime"
                                                        ErrorMessage="Please enter Time." ValidationGroup="g1" SetFocusOnError="true"
                                                        Text="*"></asp:RequiredFieldValidator>
                                                    <%--"^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$"--%>
                                                    <asp:RegularExpressionValidator runat="server" ID="rextxtTime" ValidationExpression="^([0-9]|1[0-9]|2[0-3]):[0-5][0-9]$"
                                                        ControlToValidate="txtTime" ErrorMessage="please enter the time in (HH:MM) format for example 1:10, 1:01, 1:00."
                                                        SetFocusOnError="true" ValidationGroup="g1" Display="Dynamic" Text="*"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3">
                                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="g1" OnClick="btnSubmit_Click"
                                                        CssClass="buttons" />
                                                    &nbsp;
                                                    <asp:Button ID="btnReset" runat="server" CssClass="buttons" Text="Reset" OnClick="btnReset_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:ValidationSummary ID="vsSubmitRecord" runat="server" ValidationGroup="g1" DisplayMode="List"
                                                        ShowMessageBox="true" ShowSummary="false" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdheader">
                                        Manage Effort Details
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lblRecords" runat="server" Text="" CssClass="labelsFormatted"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <div class="gridviewDiv">
                                            <asp:GridView ID="gvMaster" runat="server" CssClass="GridViewStyle" OnRowEditing="gvMaster_RowEditing"
                                                OnRowCancelingEdit="gvMaster_RowCancelingEdit" AutoGenerateColumns="false" Width="98%">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="TSId" HeaderText="TSId" Visible="false" />
                                                    <asp:BoundField DataField="TSDateDisplay" HeaderText="Date" />
                                                    <asp:BoundField DataField="TaskId" HeaderText="TaskId" Visible="false" />
                                                    <asp:BoundField DataField="TaskName" HeaderText="Task" />
                                                    <asp:BoundField DataField="ApplicationId" HeaderText="ApplicationId" Visible="false" />
                                                    <asp:BoundField DataField="ApplicationName" HeaderText="Application" />
                                                    <asp:BoundField DataField="Description" HeaderText="Description" />
                                                    <asp:BoundField DataField="TSHrs" HeaderText="Time Spent" />
                                                    <asp:BoundField DataField="Createddate" HeaderText="Created Date" />
                                                    <asp:BoundField DataField="Modifieddate" HeaderText="Modified Date" />
                                                    <asp:TemplateField HeaderText="Modify" ItemStyle-Width="60px">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgbtnEdit" runat="server" CommandName="Edit" ToolTip="Edit"
                                                                CommandArgument='<%# Eval("TSId") %>' AlternateText="Edit" ImageUrl="~/App_Themes/DefaultTheme/Images/GridEdit.gif" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <FooterStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <RowStyle CssClass="RowStyle_lowheight_wrap" Width="90%" />
                                                <FooterStyle CssClass="FooterStyle" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                                <PagerStyle CssClass="PagerStyle" />
                                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                                                <HeaderStyle CssClass="HeaderStyle_lowheight" />
                                                <EditRowStyle CssClass="EditRowStyle" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <AlternatingRowStyle CssClass="AltRowStyle_lowheight_wrap" />
                                            </asp:GridView>
                                        </div>
                                        <asp:HiddenField ID="hdnTSId" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSubmit" />
            <asp:AsyncPostBackTrigger ControlID="btnReset" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
