<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PRO_ManageVisitor.aspx.cs"
    Inherits="TSTracker.RM.PRO.PRO_ManageVisitor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>CMDB Traker</title>
    <link href="../../App_Themes/DefaultTheme/StyleSheet.css" rel="Stylesheet" type="text/css" />
    <link href="../../App_Themes/DefaultTheme/GridViewStyle.css" rel="Stylesheet" type="text/css" />
    <link href="../../App_Themes/DefaultTheme/jquery-ui-redmond.css" rel="stylesheet"
        type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="6000000">
    </asp:ScriptManager>

    <script type="text/javascript" language="javascript" src="../../Common/Scripts/jquery-min.js"></script>

    <script type="text/javascript" language="javascript" src="../../Common/Scripts/jquery-ui-min.js"></script>

    <script type="text/javascript" language="javascript" src="../../Common/Scripts/jquery-validate-min.js"></script>

    <script type="text/javascript" language="javascript">

        function AfterPostBackInit() {
        
            var dtDate = new Date();
            var curr_year = dtDate.getFullYear();
            curr_year = curr_year + 40;

            // ** Add custom validator to validate DropDownlist ** //
            $.validator.addMethod("selectNone", function(value, element) {
                return this.optional(element) || element.selectedIndex != 0;
            });

            //custom validator to validate IP V4
            $.validator.addMethod("IP4Checker", function(value, element) {
                return this.optional(element) || /^(25[0-5]|2[0-4]\d|[01]?\d\d?)\.(25[0-5]|2[0-4]\d|[01]?\d\d?)\.(25[0-5]|2[0-4]\d|[01]?\d\d?)\.(25[0-5]|2[0-4]\d|[01]?\d\d?)$/i.test(value);
            });

            //custom validator to validate IP V6
            $.validator.addMethod("IP6Checker", function(value, element) {
                return this.optional(element) || /^((([0-9A-Fa-f]{1,4}:){7}[0-9A-Fa-f]{1,4})|(([0-9A-Fa-f]{1,4}:){6}:[0-9A-Fa-f]{1,4})|(([0-9A-Fa-f]{1,4}:){5}:([0-9A-Fa-f]{1,4}:)?[0-9A-Fa-f]{1,4})|(([0-9A-Fa-f]{1,4}:){4}:([0-9A-Fa-f]{1,4}:){0,2}[0-9A-Fa-f]{1,4})|(([0-9A-Fa-f]{1,4}:){3}:([0-9A-Fa-f]{1,4}:){0,3}[0-9A-Fa-f]{1,4})|(([0-9A-Fa-f]{1,4}:){2}:([0-9A-Fa-f]{1,4}:){0,4}[0-9A-Fa-f]{1,4})|(([0-9A-Fa-f]{1,4}:){6}((\b((25[0-5])|(1\d{2})|(2[0-4]\d)|(\d{1,2}))\b)\.){3}(\b((25[0-5])|(1\d{2})|(2[0-4]\d)|(\d{1,2}))\b))|(([0-9A-Fa-f]{1,4}:){0,5}:((\b((25[0-5])|(1\d{2})|(2[0-4]\d)|(\d{1,2}))\b)\.){3}(\b((25[0-5])|(1\d{2})|(2[0-4]\d)|(\d{1,2}))\b))|(::([0-9A-Fa-f]{1,4}:){0,5}((\b((25[0-5])|(1\d{2})|(2[0-4]\d)|(\d{1,2}))\b)\.){3}(\b((25[0-5])|(1\d{2})|(2[0-4]\d)|(\d{1,2}))\b))|([0-9A-Fa-f]{1,4}::([0-9A-Fa-f]{1,4}:){0,5}[0-9A-Fa-f]{1,4})|(::([0-9A-Fa-f]{1,4}:){0,6}[0-9A-Fa-f]{1,4})|(([0-9A-Fa-f]{1,4}:){1,7}:))$/i.test(value);
            });

            // ** Add Form Validation ** //
            $("#form1").validate({
                errorPlacement: function(error, element) {
                    element.closest("td").next("td").append(error);
                }
            });
            // ** Add Validation rules for controls of type "Free Text" ** //
            $("*[IsTextType]").each(function() {
                $(this).rules("add", { required: true, messages: { required: "<span  style='color:red'>*</span>"} });
            });
            // ** Add Validation rules for controls of type "IP Address" ** //
            $("*[IsIPType]").each(function() {
                $(this).rules("add", { required: true, IP4Checker: true, messages: { required: "<span  style='color:red'>*</span>", IP4Checker: "<span  style='color:red'>* Invalid IP *</span>"} });
            });
            // ** Add Validation rules for controls of type "DropDownlist/Select" ** //
            $("*[IsSelectType]").each(function() {
                $(this).rules("add", { selectNone: true, messages: { selectNone: "<span  style='color:red'>*</span>"} });
            });
            // ** Add Validation rules for controls of type "Number/Numeric/OHRID" ** //
            $("*[IsNumberType]").each(function() {
                $(this).rules("add", { required: true, number: true, messages: { required: "<span  style='color:red'>*</span>", number: "<span  style='color:red'>* Invalid number *</span>"} });
                //Restrict Textbox Entry [Allow Number/Numeric only]
                $(this).keydown(function(e) {
                    var charCode = e.keyCode || e.which;
                    if (charCode != 8 && charCode != 9 && charCode != 0 && charCode != 18 && (charCode < 48 || charCode > 57) && (charCode < 96 || charCode > 105)) {
                        return false;
                    }
                });
            });

            // ** Add Validation rules for controls of type "Date" ** //
            $("*[IsDateType]").each(function() {
                $(this).rules("add", { required: true, messages: { required: "<span  style='color:red'>*</span>"} });
                //Add datepicker
                $(this).datepicker({
                    yearRange: '1960:' + curr_year,
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
            $("table.labels tbody tr td:nth-child(1)").addClass("tdControls");
            $("table.labels tbody tr td:nth-child(2)").addClass("tdControls");
            $("table.labels tbody tr td:nth-child(3)").addClass("tdErrors");
            $("table.labels tbody tr td:nth-child(4)").addClass("tdControls");
            $("table.labels tbody tr td:nth-child(5)").addClass("tdControls");
            $("table.labels tbody tr td:nth-child(6)").addClass("tdErrors");
            $(".tdheader").css("background-color", "#006699");
            $(".trheader").css("background-color", "#006699");

        }

        function closeIframeDialog() {
            alert("Instance updated successfully");
            window.parent.closeIframe();
        }

        // Run AfterPostBackInit() when the page loads and after every post-back.
        Sys.Application.add_load(AfterPostBackInit);
        
    </script>

    <asp:UpdatePanel ID="mainup" runat="server">
        <ContentTemplate>
            <table class="labels" cellpadding="3" cellspacing="3" style="width: 100%; background-color: #eaf4ff;">
                    <tr>
                        <td colspan="6" align="center">
                            <span style="width: 90%; text-align: center">
                                <CMDBUC:Feedback ID="Feedback" runat="server"></CMDBUC:Feedback>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdheader" colspan="6">
                            Manage Visit Request form
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Person Id
                        </td>
                        <td>
                            <asp:TextBox ID="txtPrId" runat="server" CssClass="textbox" IsTextType="True"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                        <td>
                            Transaction Id
                        </td>
                        <td>
                            <asp:TextBox ID="txtTranId" runat="server" CssClass="textbox" IsTextType="True"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Person Name
                        </td>
                        <td>
                            <asp:TextBox ID="txtPrName" runat="server" CssClass="textbox" IsTextType="True"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                        <td>
                            Father Name
                        </td>
                        <td>
                            <asp:TextBox ID="txtFatherName" runat="server" CssClass="textbox"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            District
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="ddClassMedium" 
                                IsSelectType="True" onselectedindexchanged="ddlDistrict_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                        <td>
                            Mandal
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMandal" runat="server" CssClass="ddClassMedium" 
                                IsSelectType="True" onselectedindexchanged="ddlMandal_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Village
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlVillage" runat="server" CssClass="ddClassMedium" IsSelectType="True">
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                        <td>
                            Proof Type
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlProofType" runat="server" CssClass="ddClassMedium" IsSelectType="True">
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Proof Id
                        </td>
                        <td>
                            <asp:TextBox ID="txtProofId" runat="server" CssClass="textbox" IsTextType="True"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                        <td>
                            Contact No
                        </td>
                        <td>
                            <asp:TextBox ID="txtContactNo" runat="server" CssClass="textbox" IsTextType="True"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Visit Date
                        </td>
                        <td>
                            <asp:TextBox ID="txtVisitDate" runat="server" CssClass="textbox" IsDateType="true"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                        <td>
                            Next Call Date
                        </td>
                        <td>
                            <asp:TextBox ID="txtNextCallDate" runat="server" CssClass="textbox" IsDateType="true"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Visit Purpose
                        </td>
                        <td>
                            <asp:TextBox ID="txtVisitPurpose" runat="server" CssClass="textbox" TextMode="MultiLine"
                                IsTextType="True"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                        <td>
                            Remarks
                        </td>
                        <td>
                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" TextMode="MultiLine"
                                IsTextType="True"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            Status
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="ddClassMedium" IsSelectType="True">
                            </asp:DropDownList>
                        </td>
                        <td colspan="4">
                        </td>
                    </tr>
                    
                    <tr>
                        <td style="background-color: #DDECEF;" colspan="6" class="tdFooter">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="buttons" Text="Submit" OnClick="btnSubmit_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnReset" runat="server" CssClass="buttons cancel" Text="Reset" OnClick="btnReset_Click" />
                        </td>
                    </tr>
                </table>
            <asp:HiddenField ID="hdnPrID" runat="server" />
            <asp:HiddenField ID="hdnTransId" runat="server" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlDistrict" />
            <asp:AsyncPostBackTrigger ControlID="ddlMandal" />
            <asp:PostBackTrigger ControlID="btnSubmit" />
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
