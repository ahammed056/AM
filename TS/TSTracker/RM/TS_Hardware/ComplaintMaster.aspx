<%@ Page Title="" Language="C#" MasterPageFile="~/TS_Master.Master" AutoEventWireup="true" EnableEventValidation = "false"  
    CodeBehind="ComplaintMaster.aspx.cs" Inherits="TSTracker.RM.TS_Hardware.ComplaintMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .container
        {
            width: 990px;
            margin: 0 auto;
        }
        .tab-link
        {
            overflow: hidden;
        }
        .tab-link:hover
        {
            overflow: hidden;
        }
        ul.tabs
        {
            margin: 0px;
            padding: 0px;
            margin-right: 510px;
            list-style: none;
        }
        ul.tabs li
        {
            display: inline-block;
            padding: 10px 15px;
            cursor: pointer;
            font-weight: bold;
        }
        ul.tabs li.current
        {
            background: #ededed;
            color: blue;
        }
        .tab-content
        {
            display: none;
            font-size: 11px; /*  background: #ededed; */
            padding: 15px;
            float: left;
        }
        .tab-content.current
        {
            display: inherit;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="container">
<!-- menu tabs Start  -->
            <ul class="tabs">
                <li class="tab-link" data-tab="tab-1">Log History</li>
                <li class="tab-link" data-tab="tab-2">Add Company</li>
                <li class="tab-link" data-tab="tab-3">Add Employee</li>
                <li class="tab-link" data-tab="tab-4">Tab Four</li>
                <li class="tab-link" data-tab="tab-5">Tab five</li>
            </ul>           
<!-- menu tabs end  -->


<!-- tab-1 Start Complaint History -->

            <div id="tab-1" class="tab-content current">
            <table><tr><td>
                <asp:GridView ID="gv_cm_id_complaint_history" runat="server" 
                    AutoGenerateColumns ="false" OnRowDataBound = "OnRowDataBound_id_complaint_history" OnSelectedIndexChanged = "gv_id_OnSelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("ci_CreatedTime") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="id">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("ci_ComplaintIdinfo") %>'></asp:Label>
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Assert Name">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("ci_ProductName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Company">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("c_company") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Given by">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("ci_ComplaintGivenBy") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("cs_status") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <AlternatingRowStyle BackColor="White" CssClass="borderleft" />                                                        
                 <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" BackColor="#006699" Font-Bold="True" ForeColor="White" />
                 <RowStyle CssClass="borderleft" VerticalAlign="Middle" HorizontalAlign="Center" BackColor="#EFF3FB" />               
                </asp:GridView></td><td>
                <asp:GridView ID="gv_cm_full_complaint_history" runat="server">
                </asp:GridView>
               </td></tr></table>
            </div>
            
<!-- tab-1 End Complaint History -->            
   
<!-- tab-2 Start Add Company & Dept -->  

             
            <div id="tab-2" class="tab-content">
                <table>
                    <tr>
                        <td valign="top">
      <!-- tab-2 Start Add Company  -->
                            <table style="background-color: #006699; width: 102%; margin-left: -7px">
                                <tr align="left">
                                    <td class="tdheader">
                                        Add <span style="color: Red;">&</span> Search Company
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr align="left">
                                    <td class=" ">
                                    </td>
                                </tr>
                            </table>
                            <table style="background-color: #006699; width: 100%; margin-left: -7px">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="cm_txt_companyName" runat="server" placeholder="Enter Company Name" CssClass="textbox"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="cm_txt_company_id" runat="server" placeholder="Company id" Width="90px" CssClass="textbox"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="cm_company_submit" runat="server" Text="Submit" CssClass="buttons" />
                                    </td>
                                    <td>
                                        <asp:Button ID="cm_company_search" runat="server" Text="Search" CssClass="buttons" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" style="text-align: center; color: Red; background-color: white">
                                        <asp:Label ID="lbl_company_message" runat="server" Text="ahammed" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" style="margin-top: 20px;">
                                        <asp:GridView ID="cm_gv_companydetails" runat="server" Width="100%" AutoGenerateColumns="false"
                                            AllowPaging="true" PageSize="15">
                                            <%--OnRowDataBound="gv_cm_employee_RowDataBound" OnPageIndexChanging="gvcm_employee_OnPageIndexChanging"--%>
                                            <Columns>
                                                <asp:TemplateField HeaderText="Company">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("c_company") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Company Code">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("c_did") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Created Time">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("c_created_time") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <AlternatingRowStyle BackColor="White" CssClass="borderleft" />
                                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" BackColor="#006699"
                                                Font-Bold="True" ForeColor="White" />
                                            <RowStyle CssClass="borderleft" VerticalAlign="Middle" HorizontalAlign="Center" BackColor="#EFF3FB" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                            
    <!-- tab-2 Start End Company  -->                            


                            
                        </td>
                        <td></td>      
    <!-- tab-2 Start Add Department  --> 
                        <td>
                            <table style="background-color: #006699; width: 95%; margin-left:37px;">
                                <tr align="left">
                                    <td class="tdheader">
                                        Add <span style="color: Red;">&</span> Search Department
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr align="left">
                                    <td class=" ">
                                    </td>
                                </tr>
                            </table>
                            <table style="background-color: #006699; width: 95%; margin-left:37px;">
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="cm_dll_comapny_name" runat="server" CssClass="ddClassMedium" Width="110px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_cm_dept_name" runat="server" placeholder="Department Name" CssClass="textbox"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btn_cm_dept_submit" runat="server" Text="Submit"  />
                                    </td>
                                    <td>
                                        <asp:Button ID="btn_cm_dept_search" runat="server" Text="Search" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" style="text-align: center; color: Red; background-color: white;padding-bottom:15px;">
                                        <asp:Label ID="Label6" runat="server" Text="ahammed" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" style="margin-top: 20px;">
                                        <asp:GridView ID="gv_cm_department" runat="server" Width="100%" AutoGenerateColumns="true"
                                            AllowPaging="true" PageSize="15">                                   
                                            <AlternatingRowStyle BackColor="White" CssClass="borderleft" />
                                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" BackColor="#006699"
                                                Font-Bold="True" ForeColor="White" />
                                            <RowStyle CssClass="borderleft" VerticalAlign="Middle" HorizontalAlign="Center" BackColor="#EFF3FB" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        
    <!-- tab-2 End Add Company & Dept -->    
                    </tr>
                </table>
            </div>
            
            
            
         
                      
            
       <div id="tab-3" class="tab-content">
                <table style="background-color: #006699; width: 101%; margin-left: -7px">
                    <tr align="left">
                        <td class="tdheader">
                            Add <span style="color: Red;">&</span> Search Employee
                        </td>
                    </tr>
                </table>
                <table>
                    <tr align="left">
                        <td class=" ">
                        </td>
                    </tr>
                </table>
                <table style="background-color: #006699; width: 100%; margin-left: -7px">
                    <tr>
                        <td>
                            <asp:TextBox ID="cm_txt_empname" runat="server" placeholder="Enter Employee Name"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="cm_txt_Dept" runat="server" placeholder="Enter Employee Department"></asp:TextBox>
                        </td>
                        <td>
                            <asp:DropDownList ID="cm_dll_role" runat="server">
                                <asp:ListItem Selected="True" Value="0">Admin</asp:ListItem>
                                <asp:ListItem Value="1">User</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="cm_btn_submit" runat="server" Text="Submit" />
                        </td>
                        <td>
                            <asp:Button ID="cm_btn_search" runat="server" Text="Search" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" style="text-align: center; color: Red; background-color: white">
                            <asp:Label ID="cm_lbl_employe_Message" runat="server" Text="ahammed" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" style="margin-top: 20px;">
                            <asp:GridView ID="gv_employee" runat="server" Width="100%" AutoGenerateColumns="false"
                                OnRowDataBound="gv_cm_employee_RowDataBound" OnPageIndexChanging="gvcm_employee_OnPageIndexChanging"
                                AllowPaging="true" PageSize="15">
                                <Columns>
                                    <asp:TemplateField HeaderText="Employee Name">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("e_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Department">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("e_designation") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Created Time">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("e_created_time") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Authorized By">
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("created_by") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee Status">
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("isactive") %>'></asp:Label>
                                            <asp:HiddenField ID="hfempstatus" runat="server" Value='<%#Eval("isactive") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <AlternatingRowStyle BackColor="White" CssClass="borderleft" />
                                <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" BackColor="#006699"
                                    Font-Bold="True" ForeColor="White" />
                                <RowStyle CssClass="borderleft" VerticalAlign="Middle" HorizontalAlign="Center" BackColor="#EFF3FB" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
            <%--<div id="tab-4" class="tab-content">
                Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim
                veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo
                consequat.
            </div>--%>
        </div>
        <!-- container -->
    </div>

    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/2.0.0/jquery.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            $('ul.tabs li').click(function() {
                var tab_id = $(this).attr('data-tab');
                $('ul.tabs li').removeClass('current');
                $('.tab-content').removeClass('current');
                $(this).addClass('current');
                $("#" + tab_id).addClass('current');
            });
        });
    </script>

</asp:Content>
