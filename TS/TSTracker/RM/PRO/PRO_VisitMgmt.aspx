<%@ Page Title="" Language="C#" MasterPageFile="~/TS_Master.Master" AutoEventWireup="true"
    CodeBehind="PRO_VisitMgmt.aspx.cs" Inherits="TSTracker.RM.PRO.PRO_VisitMgmt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css" rel="stylesheet">
        .errorHighlight
        {
            background-color: #F5A9A9;
        }
    </style>

    <script type="text/javascript">

        //        function openIframe(obj) {
        //            alert(obj);
        //            $("#dialog").dialog({
        //                height: 380,
        //                width: 800,
        //                modal: false
        //            });
        //        }

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
            $("table.labels tbody tr td:nth-child(7)").addClass("tdLabels");
            $("table.labels tbody tr td:nth-child(8)").addClass("tdControls");
            $("table.labels tbody tr td:nth-child(9)").addClass("tdErrors");
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
            <div align="right">
                <table style="width: 100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="right">
                            Search By &nbsp;
                            <asp:TextBox ID="txtSearchVal" runat="server" CssClass="textbox" IsIPType="True"></asp:TextBox>
                            &nbsp;
                            <asp:Button ID="btnSearch" runat="server" CssClass="buttons" Width="30px" OnClick="btnSearch_Click"
                                Text="Go" />
                             <%--   <asp:ImageButton ID="ImgSearch" runat="server" 
                                ImageUrl="~/App_Themes/DefaultTheme/Images/Search.ico" 
                                onclick="ImgSearch_Click" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblRecords" runat="server" Text="" CssClass="labels"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <div class="gridviewDiv">
                                <asp:GridView ID="gvVisitDtls" runat="server" CssClass="GridViewStyle" Width="98%"
                                    AutoGenerateColumns="false" AllowPaging="true">
                                    <RowStyle CssClass="RowStyle_lowheight" Width="98%" />
                                    <FooterStyle CssClass="FooterStyle" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                    <PagerStyle CssClass="PagerStyle" />
                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                    <HeaderStyle CssClass="HeaderStyle_lowheight" />
                                    <EditRowStyle CssClass="EditRowStyle" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <AlternatingRowStyle CssClass="AltRowStyle_lowheight" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Modify" ItemStyle-Width="50px">
                                            <ItemTemplate>
                                                <%--<a id="lnkModify" href="PRO_ManageVisitor.aspx?InsID=<%# Eval("TransId") %>" name="Modify Instance"
                                                    ismodal="true">ASD</a> --%>
                                                <a id="A1" href="PRO_EditVisitor.aspx?InsID=<%# Eval("TransId") %>"
                                                        name="Modify Visitor">
                                                        <img src="../../App_Themes/DefaultTheme/Images/GridEdit.gif" alt="Modify Visitor"
                                                            border="0" />
                                                </a>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="PrId" HeaderText="Person Id" />
                                        <asp:BoundField DataField="TransId" HeaderText="Transaction Id" />
                                        <asp:BoundField DataField="VisitorName" HeaderText="Visitor Name" />
                                        <asp:BoundField DataField="NextCallDate" HeaderText="Next Call Date" />
                                        <asp:BoundField DataField="StatusName" HeaderText="Status" />
                                        <asp:BoundField DataField="VisitPurpose" HeaderText="Visit Purpose" />
                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                        <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <%-- <div style="padding: 5px; height: 20px; vertical-align: middle; text-align: center;">
                    <table width="99%">
                        <tr>
                            <td style="width: 35%" align="center">
                                <asp:Label ID="lblRecords" runat="server" Text="" CssClass="labels"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>--%>
                <%-- <div class="gridviewDiv">
                    <asp:GridView ID="gvVisitDtls" runat="server" CssClass="GridViewStyle" Width="98%"
                        AutoGenerateColumns="false" AllowPaging="true">
                        <RowStyle CssClass="RowStyle_lowheight" Width="90%" />
                        <FooterStyle CssClass="FooterStyle" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <PagerStyle CssClass="PagerStyle" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <HeaderStyle CssClass="HeaderStyle_lowheight" />
                        <EditRowStyle CssClass="EditRowStyle" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <AlternatingRowStyle CssClass="AltRowStyle_lowheight" />
                        <Columns>
                            <asp:TemplateField HeaderText="Modify" ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <a id="lnkModify" href="PRO_ManageVisitor.aspx?InsID=<%# Eval("TransId") %>" name="Modify Instance"
                                        ismodal="true">ASD</a>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="PrId" HeaderText="Person Id" />
                            <asp:BoundField DataField="TransId" HeaderText="Transaction Id" />
                            <asp:BoundField DataField="VisitorName" HeaderText="Visitor Name" />
                            <asp:BoundField DataField="NextCallDate" HeaderText="Next Call Date" />
                            <asp:BoundField DataField="StatusName" HeaderText="Status" />
                            <asp:BoundField DataField="VisitPurpose" HeaderText="Visit Purpose" />
                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                            <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" />
                        </Columns>
                    </asp:GridView>
                </div>--%>
            </div>
            <div id="dialog" style="display: none;">
                <%-- <iframe style="border: 0px;" src="PRO_ManageVisitor.aspx" width="100%" height="100%">
                </iframe>--%>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
