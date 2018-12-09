<%@ Page Title="" Language="C#" MasterPageFile="~/TS_Master.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="register_complaints.aspx.cs" Inherits="TSTracker.RM.TS_Hardware.register_complaints" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   

 <style type="text/css">
        .no_rec_style
    {
        border:1px solid #dcdcdc;
        color:#606060;
        font-size:14px;
        text-align:center;
        padding:10px;
        background-color:#fafafa;
    }
 </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
    <table style="background-color: #006699;width: 100%; margin-left: -7px">
        <tr align="left">
            <td class="tdheader">
                Enter Complaint Information
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <a><span style="color:Red">*</span> System Number :</a>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txt_sysnumber" runat="server" CssClass="ddClassMedium"></asp:TextBox>
                <asp:HiddenField ID="hfieldupd" runat="server" Value="" />
                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_sysnumber" runat="server" ErrorMessage="*" ForeColor="red"></asp:RequiredFieldValidator>--%>
            </td>
            <td>
                <a><span style="color:Red">*</span>Issue Description :</a>
            </td>
            <td rowspan="2">
                <asp:TextBox ID="txt_issuedesc" runat="server" TextMode="MultiLine" CssClass="textboxMultiline"></asp:TextBox>
                <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txt_issuedesc" runat="server" ErrorMessage="*" ForeColor="red"></asp:RequiredFieldValidator>--%>
            </td>
            <td>
                <a>Impact Summary :</a>
            </td>
            <td rowspan="2">
                <asp:TextBox ID="txt_impact_summary" runat="server" TextMode="MultiLine" CssClass="textboxMultiline"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <a>Company / Department :</a>
            </td>
            <td>
            <asp:UpdatePanel ID="upddl" runat="server"><ContentTemplate>
                <asp:DropDownList ID="ddl_company" runat="server" Width="75px" 
                    CssClass="ddClassMedium" AutoPostBack="true"
                    onselectedindexchanged="ddl_company_SelectedIndexChanged">
                </asp:DropDownList>
                &nbsp;
                <asp:DropDownList ID="ddl_department" runat="server" Width="75px" CssClass="ddClassMedium">
                </asp:DropDownList>
                </ContentTemplate></asp:UpdatePanel>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <a>Issue Type :</a>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddl_issue_type" runat="server" CssClass="ddClassMedium">
                   <%-- <asp:ListItem Selected="True" Value="0">-- Select One --</asp:ListItem>
                    <asp:ListItem Value="1">System</asp:ListItem>
                    <asp:ListItem Value="2">Printer</asp:ListItem>
                    <asp:ListItem Value="3">Software</asp:ListItem>
                    <asp:ListItem Value="4">Network</asp:ListItem>
                    <asp:ListItem Value="5">Logs</asp:ListItem>
                    <asp:ListItem Value="6">Maintenance</asp:ListItem>
                    <asp:ListItem Value="7">Internet</asp:ListItem>
                    <asp:ListItem Value="8">Server</asp:ListItem>
                    <asp:ListItem Value="9">Application</asp:ListItem>--%>
                </asp:DropDownList>
            </td>
            <td>
                <a>Commited Wait Time to User :</a>
            </td>
            <td>         
                <asp:TextBox ID="txt_Commited_time" runat="server"   CssClass="textbox" Width="131px" style="float:left;" ></asp:TextBox> <img src="../calender.png" style="margin-top:2px; float:left;margin-left:4px;" />
            </td>
            <td>
                <a>Asset Details :</a>
            </td>
            <td rowspan="2">
                <asp:TextBox ID="txt_asset_deatils" runat="server" TextMode="MultiLine" CssClass="textboxMultiline"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <a>Priority :</a>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddl_priority" runat="server" CssClass="ddClassMedium">
                 <%--   <asp:ListItem Selected="True" Value="0">-- Select One --</asp:ListItem>
                    <asp:ListItem Value="1">Critical</asp:ListItem>
                    <asp:ListItem Value="2">High</asp:ListItem>
                    <asp:ListItem Value="3">Medium</asp:ListItem>
                    <asp:ListItem Value="4">Low</asp:ListItem>--%>
                </asp:DropDownList>
            </td>
            <td>
                <a>Expected Resolution Date :</a>
            </td>
            <td>
                <asp:TextBox ID="txt_resolution_time" runat="server" CssClass="textbox" IsDateType="true" Width="131px" style="float:left;" ></asp:TextBox> <img src="../calender.png" style="margin-top:2px; float:left;margin-left:4px;" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <a>Current Status :</a>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddl_current_status" runat="server" CssClass="ddClassMedium">
                   <%-- <asp:ListItem Selected="True" Value="0">-- Select One --</asp:ListItem>
                    <asp:ListItem Value="1">Open</asp:ListItem>
                    <asp:ListItem Value="2">Work In Progress</asp:ListItem>
                    <asp:ListItem Value="3">Closed</asp:ListItem>--%>
                </asp:DropDownList>
            </td>
            <td>
                <a>Esclation Required :</a>
            </td>
            <td>
                <asp:DropDownList ID="ddl_escalation_required" runat="server" CssClass="ddClassMedium">
                    <asp:ListItem Value="0">Yes</asp:ListItem>
                    <asp:ListItem Selected="True" Value="1">No</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <a>Action Steps :</a>
            </td>
            <td>
                <asp:TextBox ID="txt_action_steps" runat="server" TextMode="MultiLine" CssClass="textboxMultiline"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <a>Assigned To Engineeer :</a>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddl_assigned_to_engineer" runat="server" CssClass="ddClassMedium">
                </asp:DropDownList>
            </td>
            <td>
                <a>Issued Closed Engineer :</a>
            </td>
            <td>
                <asp:DropDownList ID="ddl_closed_engineer" runat="server" CssClass="ddClassMedium">
                </asp:DropDownList>
            </td>
            <td>
                <a>Issued closed Time :</a>
            </td>
            <td>
                <asp:TextBox ID="txt_issue_closed_time" runat="server" CssClass="textbox" IsDateType="true" Width="131px" style="float:left;" ></asp:TextBox> <img src="../calender.png" style="margin-top:2px; float:left;margin-left:4px;" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp; <a></a>
            </td>
            <td colspan="2">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr> <td colspan="7" align="center">           
                <asp:Button ID="btn_submit" runat="server" Text="Submit" Width="83px" CssClass="buttons" OnClick="btn_submit_onclick" /> &nbsp; &nbsp;
                <asp:Button ID="btn_reset" runat="server" Text="Reset" Width="83px" CssClass="buttons" OnClick = "btn_reset_OnClick" />
            </td>         
        </tr>
       <tr>
            <td colspan="7" >
               <div style="float:right; padding-right:20px;">
                <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
              
                    <asp:TextBox ID="txt_search" runat="server" placeholder="Search Complaint"></asp:TextBox>                
                
                    <asp:ImageButton ID="btn_search" runat="server" ImageUrl ="Styles/ico/if_icon-111-search_314689.ico" Width="24px" Height="23px" OnClick = "btn_search_OnClick" />
               </div>
                   
            </td>
        </tr>
        <tr>
            <td colspan="7" style="height:10px;">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="7"> 
                <div class="gridviewDiv">
        <asp:GridView ID="gv1" runat="server" AutoGenerateColumns = "false" Width="100%" 
                        AllowPaging="true" OnPageIndexChanging = "gv1indexchanging" PageSize = "10" 
                        onrowdatabound="gv1_RowDataBound" style="overflow:auto">
            <Columns>
            <asp:TemplateField HeaderText = "System Number">           
            <ItemTemplate >
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("ci_ProductName") %>'></asp:Label>            
                <asp:HiddenField ID="hfield" runat="server" Value='<%#Eval("ci_ComplaintIdinfo") %>' />
            </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText = "Company">           
                    <ItemTemplate >
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("c_company") %>'></asp:Label>            
                    </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText = "Issue Type">
           
            <ItemTemplate >
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("iss_type") %>'></asp:Label>            
            </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText = "Priority">
         
            <ItemTemplate >
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("pr_priority") %>'></asp:Label>            
            </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText = "Issue Status">
            
            <ItemTemplate >
                <asp:Label ID="Label5" runat="server" Text='<%# Eval("cs_status") %>'></asp:Label>    
                <asp:HiddenField ID="hfstatus" runat="server" Value='<%#Eval("cs_status") %>' />        
            </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText = "Assi. Engineer">
            <ItemTemplate >
                <asp:Label ID="Label6" runat="server" Text='<%# Eval("e_Name") %>'></asp:Label>            
            </ItemTemplate>
            </asp:TemplateField>
            
      
            <asp:TemplateField HeaderText = "Created Time">
         
            <ItemTemplate >
                   <asp:Label ID="Label7" runat="server" Text='<%# Eval("ci_CreatedTime") %>'></asp:Label>                       
            </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText = "Commited Time">
         
            <ItemTemplate >
                <asp:Label ID="Label8" runat="server" Text='<%# Eval("CommitedTime") %>'></asp:Label>
                         
            </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText = "Resolution Time">
         
            <ItemTemplate >
                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("ResolutionTime") %>'></asp:Label>
                         
            </ItemTemplate>
            </asp:TemplateField>
      
            <asp:TemplateField HeaderText = "Closed Time">
         
            <ItemTemplate >
                  <asp:Label ID="Label10" runat="server" Text='<%# Eval("ClosedTimeHH") %>'></asp:Label> 
                        
            </ItemTemplate>
            </asp:TemplateField>

        


             <asp:TemplateField HeaderText = "Edit" ShowHeader="true" ItemStyle-HorizontalAlign="Center">

             <ItemTemplate>                         
                <asp:ImageButton ID="btn_grid_edit" runat="server" ImageUrl ="../../App_Themes/DefaultTheme/Images/GridEdit.gif" Width="15px" Height="15px" OnClick="btn_grid_edit_OnClick" />
            </ItemTemplate>
            </asp:TemplateField>    
               

             <asp:TemplateField HeaderText = "Delete" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate >
                <asp:ImageButton ID="btn_grid_del" runat="server" ImageUrl = "../../App_Themes/DefaultTheme/Images/GridCancel.gif" Width="15px" Height="15px" OnClick="btn_grid_del_OnClick" />
            </ItemTemplate>
            </asp:TemplateField>
            </Columns>
            
                 <AlternatingRowStyle BackColor="White" CssClass="borderleft" />                                                        
                 <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" BackColor="#006699" Font-Bold="True" ForeColor="White" />
                 <RowStyle CssClass="borderleft" VerticalAlign="Middle" HorizontalAlign="Center" BackColor="#EFF3FB" />               
        </asp:GridView>
        <asp:Label ID="lblNoRec" runat="server" CssClass="no_rec_style" Visible="false" Text="No Records found" Width="97%"  />
    </div>
            </td>
        </tr>
        
    </table>
    <script type="text/javascript">
         $(document).ready(function() {
         $("#<%=txt_Commited_time.ClientID%>").dynDateTime({
                 showsTime: true,
                 ifFormat: "%d/%m/%Y %H:%M",
                 daFormat: "%l;%M %p, %e %m,  %Y",
                 align: "BR",
                 electric: false,
                 singleClick: false,
                 displayArea: ".siblings('.dtcDisplayArea')",
                 button: ".next()"
             });
         });

         $(document).ready(function() {
             $("#<%=txt_resolution_time.ClientID%>").dynDateTime({
                 showsTime: true,
                 ifFormat: "%d/%m/%Y %H:%M",
                 daFormat: "%l;%M %p, %e %m,  %Y",
                 align: "BR",
                 electric: false,
                 singleClick: false,
                 displayArea: ".siblings('.dtcDisplayArea')",
                 button: ".next()"
             });
         });

         $(document).ready(function() {
         $("#<%=txt_issue_closed_time.ClientID %>").dynDateTime({
                 showsTime: true,
                 ifFormat: "%d/%m/%Y %H:%M",
                 daFormat: "%l;%M %p, %e %m,  %Y",
                 align: "BR",
                 electric: false,
                 singleClick: false,
                 displayArea: ".siblings('.dtcDisplayArea')",
                 button: ".next()"
             });
         });
       
    </script>
</asp:Content>
