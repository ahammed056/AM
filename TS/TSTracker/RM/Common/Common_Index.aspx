<%@ Page Title="" Language="C#" MasterPageFile="~/CMDB_Master.Master" AutoEventWireup="true"
    CodeBehind="Common_Index.aspx.cs" Inherits="RMTracker.RM.Common.Common_Index"
    ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .subHeaderRow
        {
            background-color: #c4cfcf;
            height: 15px;
            text-align: center;
            border: solid 1px #DEDFDE;
            border-collapse: collapse;
            font-size: 8pt;
        }
        .subHeaderRow th
        {
            padding: 2px;
            color: Black;
            text-align: center;
            white-space: nowrap;
            border: solid 1px #DEDFDE;
            border-collapse: collapse;
        }
        .MainRowStyle_lowheight td, .MainAltRowStyle_lowheight td
        {
            height: 20px;
            line-height: 20px;
            font-size: 8pt;
            font-weight: bold;
            background-color: #5c9ccc;
            color: White;
            white-space: nowrap;
            padding-left: 5px;
        }
        .EmptyRowStyle td
        {
            padding-left: 15px;
            padding-right: 15px;
            font-size: 8pt;
        }
        .spanStyle
        {
            padding-left: 3px;
            color: Blue;
            font-size: 9pt;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">

        $(document).ready(function() {
            // ** Client side Expand Collapse functionality using jQuery ** //
            $("[src*=Expand]").live("click", function() {
                $(this).closest("tr").next().show();
                $(this).attr("src", "../../App_Themes/DefaultTheme/Images/Collapse_New.png");
            });

            $("[src*=Collapse]").live("click", function() {
                $(this).attr("src", "../../App_Themes/DefaultTheme/Images/Expand_New.png");
                $(this).closest("tr").next().hide();
            });

            $(".ExpandAll").live("click", function() {
                $("[src*=Expand]").each(function() {
                    $(this).closest("tr").next().show();
                    $(this).attr("src", "../../App_Themes/DefaultTheme/Images/Collapse_New.png");
                });
            });

            $(".CollapseAll").live("click", function() {
                $("[src*=Collapse]").each(function() {
                    $(this).attr("src", "../../App_Themes/DefaultTheme/Images/Expand_New.png");
                    $(this).closest("tr").next().hide();
                });
            });

            $("[src*=Expand]").each(function() {
                $(this).closest("tr").next().show();
                $(this).attr("src", "../../App_Themes/DefaultTheme/Images/Collapse_New.png");
            });

            if ($(".gridviewDiv IMG").length > 0) {
                $("#divExpandCollapse").show();
            }
            else {
                $("#divExpandCollapse").hide();
            }

            //            $("input[id*=btnSearch]").live("click", function() {
            //                var innerIP = $("input[id*=txtIPAddress]").val();
            //            });

            $("input[id*=btnExport]").live("click", function() {
                var innerHtml = $(".gridviewDiv")[0].innerHTML;
                innerHtml = $.strRemove("IMG", innerHtml);
                $("input[id*=hdnInnerHtml]").val(innerHtml);
            });

        });

        (function($) { $.strRemove = function(theTarget, theString) { return $("<div/>").append($(theTarget, theString).remove().end()).html(); }; })(jQuery); 
        
    </script>

    <div>
        <CMDBUC:Feedback ID="Feedback" runat="server"></CMDBUC:Feedback>
    </div>
    <div class="breakDiv">
    </div>
    <div>
        <fieldset>
            <legend>Filter Instance</legend>
            <table style="width: 100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">
                        <table style="margin-top: 10px; margin-bottom: 10px;" cellpadding="1" cellspacing="2">
                            <tr>
                                <td align="left">
                                    IP Address
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtIPAddress" runat="server" CssClass="textbox" IsIPType="True"></asp:TextBox>
                                </td>
                                <td align="left">
                                    &nbsp;
                                </td>
                                <td align="left">
                                    Hostname
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtHostname" runat="server" CssClass="textbox" IsTextType="True"></asp:TextBox>
                                </td>
                                <td align="left">
                                    &nbsp;
                                </td>
                                <td align="left" colspan="6">
                                    <asp:Button ID="btnSearch" runat="server" CssClass="buttons" Text="Submit" OnClick="btnSearch_Click" />
                                    &nbsp;
                                    <asp:Button ID="btnReset" runat="server" CssClass="buttons" Text="Reset" OnClick="btnReset_Click" />
                                    &nbsp;
                                    <asp:Button ID="btnExport" runat="server" CssClass="buttons" Text="Export" OnClick="btnExport_Click"
                                        Enabled="false" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    <div class="breakDiv">
    </div>
    <div>
        <fieldset>
            <div style="padding: 8px; padding-left: 40px; vertical-align: middle; text-align: left;"
                visible="false" id="divExpandCollapse">
                <a class="ExpandAll" style="cursor: pointer; text-decoration: underline;">[Expand All]</a>
                &nbsp;|&nbsp; <a class="CollapseAll" style="cursor: pointer; text-decoration: underline;">
                    [Collapse All]</a>
            </div>
            <div class="gridviewDiv">
                <asp:GridView ID="gvModule" runat="server" CssClass="GridViewStyle" Width="98%" AutoGenerateColumns="false"
                    OnRowDataBound="gvModule_RowDataBound" ShowHeader="false" ShowFooter="false">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" style="border: Solid 1px #74C2E1; width: 100%;">
                                    <tr class="MainRowStyle_lowheight">
                                        <td style="width: 14px;">
                                            <img alt="" style="cursor: pointer; padding: 3px;" src="../../App_Themes/DefaultTheme/Images/Expand_New.png" />
                                        </td>
                                        <td align="left">
                                            <%# Eval("Key")%>
                                            <asp:Label ID="lblModuleID" runat="server" Text='<%# Eval("Value") %>' Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="display: none; background-color: White;">
                                        <td style="width: 14px;">
                                        </td>
                                        <td align="left">
                                            <asp:Panel ID="pnlInstance" runat="server">
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </fieldset>
    </div>
    <asp:HiddenField ID="hdnInnerHtml" runat="server" />
</asp:Content>
