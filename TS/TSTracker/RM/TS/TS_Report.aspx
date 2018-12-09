<%@ Page Title="" Language="C#" MasterPageFile="~/TS_Master.Master" AutoEventWireup="true"
    CodeBehind="TS_Report.aspx.cs" Inherits="TSTracker.RM.TS.TS_Report" %>

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
                    dateFormat: 'mm/dd/yy',
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
                <CMDBUC:Feedback ID="Feedback1" runat="server"></CMDBUC:Feedback>
            </div>
          <%--  <div class="breakDiv">
            </div>--%>
            <div>
                <div style="padding: 5px; height: 10px; vertical-align: middle; text-align: center;">
                    <asp:Label ID="lblRecords" runat="server" Text="" CssClass="labels"></asp:Label>
                </div>
                <div align="left">
                    <table class="labels" cellpadding="3" cellspacing="3" style="width: 100%; background-color: #eaf4ff;">
                        <tr>
                            <td>
                                From Date
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromDate" CssClass="textbox" runat="server" IsDateType="true"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                                To Date
                            </td>
                            <td>
                                <asp:TextBox ID="txtToDate" runat="server" CssClass="textbox" IsDateType="true"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Employee Id
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmpId" CssClass="textbox" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td style="background-color: #DDECEF;" colspan="3" align="left">
                                <asp:Button ID="btnSearch" runat="server" CssClass="buttons" Text="Search" OnClick="btnSearch_Click" />
                                &nbsp;
                                <asp:Button ID="btnExport" runat="server" CssClass="buttons" Text="Export" OnClick="btnExport_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="gridviewDiv" style="height:600px; width:990px;">
                    <asp:GridView ID="gvReport" runat="server" CssClass="GridViewStyle" Width="98%" AutoGenerateColumns="false">
                        <RowStyle CssClass="RowStyle_lowheight" Width="100%" />
                        <FooterStyle CssClass="FooterStyle" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <PagerStyle CssClass="PagerStyle" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <EditRowStyle CssClass="EditRowStyle" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <AlternatingRowStyle CssClass="AltRowStyle_lowheight" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblSno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="TSDateDisplay" HeaderText="Date" />
                            <asp:BoundField DataField="EMPId" HeaderText="Emp Id" />
                            <asp:BoundField DataField="EMPName" HeaderText="Emp Name" />
                            <asp:BoundField DataField="TaskName" HeaderText="Task" />
                            <asp:BoundField DataField="ApplicationName" HeaderText="Application" />
                            <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-Wrap="true" ItemStyle-Width="500px" />
                            <asp:BoundField DataField="TSHrs" HeaderText="Time Spent" />
                            <asp:BoundField DataField="Createddate" HeaderText="Created Date" />
                            <asp:BoundField DataField="Modifieddate" HeaderText="Modified Date" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSearch" />
            <asp:PostBackTrigger ControlID="btnExport" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
