<%@ Page Title="" Language="C#" MasterPageFile="~/TS_Master.Master" AutoEventWireup="true"
    CodeBehind="PRO_AddVisitForm.aspx.cs" Inherits="TSTracker.RM.PRO.PRO_AddVisitForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css" rel="stylesheet">
        .errorHighlight
        {
            background-color: #F5A9A9;
        }
    </style>

    <script type="text/javascript" language="javascript" src="../../Common/Scripts/jquery-validate-min.js"></script>

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
            <div align="left">
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
                            Visit Request form
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Person Name
                        </td>
                        <td>
                            <asp:TextBox ID="txtPrName" runat="server" CssClass="textbox"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvtxtPrName" runat="server" ControlToValidate="txtPrName"
                                ErrorMessage="Please enter Visitor Name" SetFocusOnError="true" Text="*" ValidationGroup="g1"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            Father Name
                        </td>
                        <td>
                            <asp:TextBox ID="txtFatherName" runat="server" CssClass="textbox"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvtxtFatherName" runat="server" ControlToValidate="txtFatherName"
                                ErrorMessage="Please enter FatherName" SetFocusOnError="true" Text="*" ValidationGroup="g1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            District
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="ddClassMedium" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvddlDistrict" runat="server" ControlToValidate="ddlDistrict"
                                ErrorMessage="Please select District." Font-Bold="False" Font-Names="Tahoma"
                                Font-Size="8pt" InitialValue="-1" ValidationGroup="g1" SetFocusOnError="true"
                                Display="Dynamic">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            Mandal
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMandal" runat="server" CssClass="ddClassMedium" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvddlMandal" runat="server" ControlToValidate="ddlMandal"
                                ErrorMessage="Please select Mandal." Font-Bold="False" Font-Names="Tahoma" Font-Size="8pt"
                                InitialValue="-1" ValidationGroup="g1" SetFocusOnError="true" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Village
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlVillage" runat="server" CssClass="ddClassMedium">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvddlVillage" runat="server" ControlToValidate="ddlVillage"
                                ErrorMessage="Please select Village." Font-Bold="False" Font-Names="Tahoma" Font-Size="8pt"
                                InitialValue="-1" ValidationGroup="g1" SetFocusOnError="true" Display="Dynamic">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            Proof Type
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlProofType" runat="server" CssClass="ddClassMedium">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvddlProofType" runat="server" ControlToValidate="ddlProofType"
                                ErrorMessage="Please select Proof Type." Font-Bold="False" Font-Names="Tahoma"
                                Font-Size="8pt" InitialValue="-1" ValidationGroup="g1" SetFocusOnError="true"
                                Display="Dynamic">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Proof Id
                        </td>
                        <td>
                            <asp:TextBox ID="txtProofId" runat="server" CssClass="textbox"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvtxtProofId" runat="server" ControlToValidate="txtProofId"
                                ErrorMessage="Please enter ProofId" SetFocusOnError="true" Text="*" ValidationGroup="g1"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            Contact No
                        </td>
                        <td>
                            <asp:TextBox ID="txtContactNo" runat="server" CssClass="textbox"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvtxtContactNo" runat="server" ControlToValidate="txtContactNo"
                                ErrorMessage="Please enter ContactNo" SetFocusOnError="true" Text="*" ValidationGroup="g1"></asp:RequiredFieldValidator>
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
                            <asp:TextBox ID="txtVisitPurpose" runat="server" CssClass="textbox" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvtxtVisitPurpose" runat="server" ControlToValidate="txtVisitPurpose"
                                ErrorMessage="Please enter Visit Purpose" SetFocusOnError="true" Text="*" ValidationGroup="g1"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            Remarks
                        </td>
                        <td>
                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #DDECEF;" colspan="6" class="tdFooter">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="buttons" Text="Submit" ValidationGroup="g1"
                                OnClick="btnSubmit_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnReset" runat="server" CssClass="buttons cancel" Text="Reset" OnClick="btnReset_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #DDECEF;" colspan="6" class="tdFooter">
                            <asp:ValidationSummary ID="vsSubmitRecord" runat="server" ValidationGroup="g1" DisplayMode="List"
                                ShowMessageBox="true" ShowSummary="false" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSubmit" />
            <asp:AsyncPostBackTrigger ControlID="btnReset" />
            <asp:AsyncPostBackTrigger ControlID="ddlDistrict" />
            <asp:AsyncPostBackTrigger ControlID="ddlMandal" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
