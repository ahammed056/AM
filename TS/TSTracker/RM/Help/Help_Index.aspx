<%@ Page Title="" Language="C#" MasterPageFile="~/CMDB_Master.Master" AutoEventWireup="true"
    CodeBehind="Help_Index.aspx.cs" Inherits="RMTracker.RM.Help.Help_Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="mainup" runat="server">
        <ContentTemplate>
            <div>
                <CMDBUC:Feedback ID="Feedback1" runat="server"></CMDBUC:Feedback>
            </div>
            <div class="breakDiv">
            </div>
            <div>
                <table width="40%">
                  <tr>
                        <td class="tdheader" style="width: 100%; font-size: small;">
                            Request Forms Help Documents
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <table cellpadding="2" cellspacing="2">
                                <tr align="left">
                                    <td>
                                        <asp:HyperLink ID="Hlink_SANHelpDoc" runat="server" CssClass="labels" NavigateUrl="~/Common/HelpDocs/SANStorage_UserGuidelines_1.1.pdf"
                                        Font-Bold="true" Target="_blank" ToolTip="Click to download SAN Request Forms Help Document.">SAN Help Document</asp:HyperLink>    
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td>
                                         <asp:HyperLink ID="Hlink_NASHelpDoc" runat="server" CssClass="labels" NavigateUrl="~/Common/HelpDocs/SANStorage_UserGuidelines_1.1.pdf"
                                        Font-Bold="true" Target="_blank" ToolTip="Click to download NAS Request Forms Help Document.">NAS Help Document</asp:HyperLink>    
                                            
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
        <Triggers>
            <%--<asp:AsyncPostBackTrigger ControlID="cbbydate" />--%>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

