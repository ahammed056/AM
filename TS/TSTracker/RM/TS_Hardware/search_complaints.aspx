<%@ Page Title="" Language="C#" MasterPageFile="~/TS_Master.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="search_complaints.aspx.cs" Inherits="TSTracker.RM.TS_Hardware.search_complaints" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ui-autocomplete
        {
            max-height: 300px; /*overflow-y: auto;
                                overflow-x: hidden;*/
        }
        #left_menu
        {
            top: 50px; /* right: 7px; */
            z-index: 5;
            width: 964px;
            float: left;
            overflow: auto;
            font-family: Segoe UI; /* font-size: 12px; */
            background-color: #E8E8E8; /* border-radius: 6px;*/
            font-weight: bold;
            border: steelblue 1px solid;
        }
        .itemVeh
        {
            background-color: #fafafa;
            color: Black;
            padding: 5px;
            border: 1px solid #dcdcdc;
            margin: 3px; /*  border-radius: 3px; */
        }
        .item_selected
        {
            background-color: #5272b5;
            color: White;
            cursor: pointer;
        }
        .no_rec_style
        {
            
            color: #606060;
            font-size: 14px;
            text-align: center;
            padding: 10px;
            background-color: #fafafa;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table style="background-color: #006699; width: 98%;">
            <tr align="left">
                <td class="tdheader">
                    Search Complaint Information
                    <div style="float: right; padding-right: 20px;">
                        <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
                        <asp:TextBox ID="txt_search" runat="server" placeholder="Search Complaint"></asp:TextBox>
                        <asp:ImageButton ID="ibtn_search" runat="server" ImageUrl="Styles/ico/if_icon-111-search_314689.ico"
                            Width="24px" Height="23px" OnClick="ibtn_search_onclick" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="left_menu" style="padding: 5px 2px; margin-top: 7px; margin-left: 10px; margin-bottom:15px;">
        <table style="float: left;">
            <thead>
                <tr>
                    <td>
                        <label>
                            From</label>
                    </td>
                    <td>
                        <label>
                            To</label>
                    </td>
                    <td>
                        <label>
                            By Engineer</label>
                    </td>
                    <td>
                        <label>
                            By Status</label>
                    </td>
                    <td>
                        <label>
                            By Priority</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txt_from" runat="server" CssClass="textbox" IsDateType="true" Style="float: left;"
                            OnTextChanged="txt_from_TextChanged" AutoPostBack="true"></asp:TextBox>
                        &nbsp;
                        <img src="../calender.png" style="margin-top: 2px; float: left; margin-left: 4px;" />
                        <%--style="float:left;" ></asp:TextBox> <img src="../calender.png" style="margin-top:2px; float:left;margin-left:4px;" />--%>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_to" runat="server" CssClass="textbox" IsDateType="true" Style="float: left;"></asp:TextBox>
                        &nbsp;<img src="../calender.png" style="margin-top: 2px; float: left; margin-left: 4px;" />
                    </td>
                    <td>
                            
                                <asp:DropDownList ID="sd_byengineer" runat="server" CssClass="ddClassMedium" OnSelectedIndexChanged="sd_byengineer_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                          
                    </td>
                    <td>
                        
                                <asp:DropDownList ID="sd_bystatus" runat="server" CssClass="ddClassMedium" OnSelectedIndexChanged="sd_bystatus_SelectedIndexChanged"
                                    AutoPostBack="true">
                                    <asp:ListItem Selected="True" Value="0">-- Select One --</asp:ListItem>
                                    <asp:ListItem Value="1">Open</asp:ListItem>
                                    <asp:ListItem Value="2">Work In Progress</asp:ListItem>
                                    <asp:ListItem Value="3">Closed</asp:ListItem>
                                </asp:DropDownList>
                         
                    </td>
                    <td>
                       
                                <asp:DropDownList ID="sd_bypriority" runat="server" CssClass="ddClassMedium" OnSelectedIndexChanged = "sd_bypriority_index_changed"
                                    AutoPostBack="true">
                                    <asp:ListItem Selected="True" Value="0">-- Select One --</asp:ListItem>
                                    <asp:ListItem Value="1">Critical</asp:ListItem>
                                    <asp:ListItem Value="2">High</asp:ListItem>
                                    <asp:ListItem Value="3">Medium</asp:ListItem>
                                    <asp:ListItem Value="4">Low</asp:ListItem>
                                </asp:DropDownList>
                           
                    </td>
                    <td>
                        <asp:Button ID="btn_search" runat="server" Text="Search" CssClass="buttons" OnClick="btn_search_onclick" Width="80px" />&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="ImageButton1" runat="server" onclick="ImageButton1_Click" ImageUrl="~/RM/TS_Hardware/exicon.png" style="height:20px;width:20px;float: right;" />            
                    </td>
                </tr>
               
            </thead>
            
        </table>
    </div>   
    <div style="float:right; padding-right:5px;">
                     
     </div>
    <div style="width: 98%; height: 400px; overflow: scroll"><%--overflow:auto--%>
        <asp:GridView ID="gv_search" runat="server" AutoGenerateColumns="true" Width="98%" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging"  >
       <%--     <Columns>
                <asp:TemplateField HeaderText="System Number">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("ci_ProductName") %>'></asp:Label>
                       
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Company">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("c_company") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Issue Type">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("iss_type") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Priority">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("pr_priority") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Issue Status">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("cs_status") %>'></asp:Label>
                        <asp:HiddenField ID="hfstatus" runat="server" Value='<%#Eval("cs_status") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="A Engineer">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("e_Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Created Time">
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("ci_CreatedTime") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>--%>
            <AlternatingRowStyle BackColor="White" CssClass="borderleft" />
            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" BackColor="#006699"
                Font-Bold="True" ForeColor="White" />
            <RowStyle CssClass="borderleft" VerticalAlign="Middle" HorizontalAlign="Center" BackColor="#EFF3FB" />
            <EmptyDataTemplate>
                <asp:Label ID="lblNoRecsearch" runat="server" CssClass="no_rec_style" Text="No Records found" Width="98%" />
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
     

    <script type="text/javascript">
        $(document).ready(function() {
            $("#<%=txt_from.ClientID%>").dynDateTime({
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
            $("#<%=txt_to.ClientID%>").dynDateTime({
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
