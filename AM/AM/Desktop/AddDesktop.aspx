﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AssetManage.Master" AutoEventWireup="true" CodeBehind="AddDesktop.aspx.cs" Inherits="AM.Desktop.AddCPU" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
      <!--  https://www.cssscript.com/pretty-animated-popup-javascript-library-x0popup/ -->
    function Cpuview() {
        x0p('You have Selected CPU', ' ');
    }
    function Moniview() {
        x0p('You have Selected MONITOR', ' ');
    }
    function aha1() {
        x0p('Confirmation', 'Are you sure?', 'warning');
    }

    function Messagefor() {
        x0p('&nbsp;&nbsp;&nbsp;  <u>Used Asset Code</u>...........  &nbsp;&nbsp;&nbsp;', 'Try a New One');
    }
    function Sucessfor() {
        x0p('<h1>Great........!</h1><br><br>Asset Code Inserted<br><br>');
    }
    function typething() {
        x0p('<h3>Hey........!</h3><br>Choose Asset Code<br><br>');
    }

    function cpuRecinserted() {
        x0p('<h3>Scucess........!</h3><br>Cpu Details has Uploaded<br><br>');
    }
    function cpuRecninserted() {
        x0p('<h3>Hey........!</h3><br>Check the Details <br><br>');
    }



    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="Updat1e" runat="server">
        <ContentTemplate>
            <section class="content-header">
                <h1 style="font-size: 20px;">Entry For(<asp:Label ID="Label1" runat="server" Text="Choose from Dropdown"></asp:Label>)
                </h1>
                <p style="float: right; font-size: 12px; margin-top: -20px;">
                   Asset Type&nbsp;&nbsp;
           
            <asp:DropDownList ID="ddl_desktop" runat="server" OnSelectedIndexChanged="ddl_desktop_SelectedIndexChanged" AutoPostBack="true" Width="200px">
            </asp:DropDownList>
                </p>
                <%--  <asp:LinkButton ID="lbtn_Add_viewPanel" runat="server" CssClass="fa fa-plus-circle" aria-hidden="true" OnClick="lbtn_Add_viewPanel_OnClick" style="float:right;height:20px;width:20px;margin-top:-1em;font-size: 20px;"  />--%>
            </section>

            <section class="content">



                <asp:Panel ID="PanelOs" runat="server" Visible="false">
                    <div class="row" style="margin-top: -25px">

                        <div class="col-md-12">

                            <div class="box box-primary">
                                <div class="box-body">
                                    <div class="row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">
                                                    Asset Number</label>
                                                <asp:DropDownList ID="ddl_new_Asset_id_os" class="form-control select2" runat="server" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-2">


                                            <div class="form-group">


                                                <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">System OS</label>
                                                <asp:TextBox ID="TextBox27" runat="server" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">


                                                <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">System OS Key</label>
                                                <asp:TextBox ID="TextBox14" runat="server" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:TextBox>

                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-group">


                                                <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">Service Pack</label>
                                                <asp:TextBox ID="TextBox21" runat="server" class="form-control select2" Style="height: 23px; font-size: 12px; margin-top: -10px;"></asp:TextBox>


                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <p>
                                                    <label>Is New OS</label>
                                                    <input id="Checkbox1" type="checkbox" title="Is Os New" style="height: 24px; width: 24px; margin-top: 20px; padding: 0PX 0PX 0PX 10PX;" />
                                                </p>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:Button ID="Button3" runat="server" Text="Save" class="btn btn-block btn-info btn-sm" Style="height: 23px; font-size: 12px; padding: 1PX 0PX 0px 0px; margin-top: 20PX;" />
                                        </div>

                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </asp:Panel>


                <asp:Panel ID="PanMain" runat="server" Visible="false">
                    <div class="row">

                        <div class="col-md-12">
                            <div class="box box-primary">
                                <div class="box-body">

                                    <div class="row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">
                                                    Asset Number</label>

                                                <asp:DropDownList ID="ddl_new_Asset_id" class="form-control select2" runat="server" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:DropDownList>

                                            </div>
                                            <div class="form-group">
                                                <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">Purchase Number</label>
                                                <asp:TextBox ID="txt_ad_PR_Number" runat="server" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:TextBox>
                                            </div>

                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">Brand Make</label>
                                                <asp:DropDownList ID="ddl_ad_brand" runat="server" class="form-control" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;" AutoPostBack="true" OnSelectedIndexChanged="ddl_ad_brand_SelectedIndexChanged"></asp:DropDownList>
                                            </div>



                                            <div class="form-group">
                                                <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">Voucher Number</label>
                                                <asp:TextBox ID="txt_ad_Voucher_Number" runat="server" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:TextBox>
                                            </div>


                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">Model</label>
                                                <asp:DropDownList ID="ddl_ad_brand_model" runat="server" class="form-control" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;" AutoPostBack="true"></asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">Receive Date</label>
                                                <asp:TextBox ID="txt_ad_Receive_Date" runat="server" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;" TextMode="DateTimeLocal" value="2018-06-12T19:30" min="2018-06-07T00:00" max="2020-06-14T00:00"></asp:TextBox>
                                            </div>

                                        </div>

                                        <div class="col-md-2">

                                            <div class="form-group">

                                                <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">
                                                    Product Number</label>

                                                <asp:TextBox ID="txt_ad_Product_Number" runat="server" class="form-control" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:TextBox>

                                            </div>


                                            <div class="form-group">
                                                <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">Warranty Start Date</label>
                                                <asp:TextBox ID="txt_ad_Warranty_Start_Date" runat="server" TextMode="DateTimeLocal" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:TextBox>

                                            </div>

                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">Serial Number</label>
                                                <asp:TextBox ID="txt_ad_Serial_Number" runat="server" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:TextBox>

                                            </div>
                                            <div class="form-group">
                                                <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">Warranty End Date</label>
                                                <asp:TextBox ID="txt_ad_Warranty_End_Date" runat="server" TextMode="DateTimeLocal" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:TextBox>

                                            </div>


                                        </div>

                                        <div class="col-md-2">

                                            <div class="form-group">
                                                <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">&nbsp;</label>
                                                <asp:Button ID="btn_ad1_save" runat="server" Text="Save" class="btn btn-block btn-info btn-sm" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;" OnClick="btn_ad1_save_Click" />

                                            </div>

                                            <div class="form-group">
                                                <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">&nbsp;</label>
                                                <asp:Button ID="btn_ad_Cancel" runat="server" Text="Cancel" class="btn btn-block btn-warning btn-sm" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;" />

                                            </div>


                                        </div>



                                    </div>

                                    <asp:Panel ID="p123" runat="server" Visible="false">
                                        <div class="row" style="margin-top: -25px;">
                                            <section class="content-header">
                                                <h4>Cpu History</h4>
                                            </section>
                                            <div class="col-md-12">

                                                <div class="box box-primary">
                                                    <div class="box-body">

                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <div class="col-md-4">
                                                                    <div class="form-group">
                                                                        <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">
                                                                            Processor</label>

                                                                        <asp:TextBox ID="txt_ad_processor" runat="server" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <div class="form-group">
                                                                        <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">
                                                                            IP Address</label>

                                                                        <asp:TextBox ID="txt_ad_ip_address" runat="server" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <div class="form-group">
                                                                        <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">MAC ID</label>
                                                                        <asp:TextBox ID="txt_ad_mac_address" runat="server" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:TextBox>
                                                                    </div>

                                                                </div>
                                                                <div class="col-md-2">
                                                                    <div class="form-group">
                                                                        <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">Host Name</label>
                                                                        <asp:TextBox ID="txt_ad_HostName" runat="server" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                        </div>

                                                        <div class="row">
                                                            <div class="col-md-12">

                                                                <div class="col-md-4">
                                                                    <div class="form-group">
                                                                        <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">
                                                                            Hard Disk Model</label>

                                                                        <asp:TextBox ID="txt_ad_hdd_model" runat="server" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:TextBox>
                                                                    </div>



                                                                </div>
                                                                <div class="col-md-2">
                                                                    <div class="form-group">
                                                                        <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">
                                                                            HardDisk serial No.</label>
                                                                        <asp:TextBox ID="txt_ad_hdd_serial" runat="server" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                                <div class="col-md-2">
                                                                    <div class="form-group">
                                                                        <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">
                                                                            HardDisk size.</label>
                                                                        <asp:TextBox ID="txt_ad_hdd_size" runat="server" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:TextBox>
                                                                    </div>

                                                                </div>

                                                            </div>
                                                        </div>


                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="P124" runat="server" Visible="false">
                                        <div class="row" style="margin-top: -25px;">
                                            <section class="content-header">
                                                <h4>printer History</h4>
                                            </section>
                                            <div class="col-md-12">

                                                <div class="box box-primary">
                                                    <div class="box-body">

                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <div class="col-md-4">
                                                                    <div class="form-group">
                                                                        <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">
                                                                            Cartridge Model</label>

                                                                        <asp:TextBox ID="TextBox1" runat="server" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <div class="form-group">
                                                                        <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">
                                                                            IP Address</label>

                                                                        <asp:TextBox ID="TextBox2" runat="server" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                             <%--  <div class="row" style="margin-top: -25px;">
                                            <section class="content-header">
                                                <h4>Processor Entry</h4>
                                            </section>
                                            <div class="col-md-12">

                                                <div class="box box-primary">
                                                    <div class="box-body">
                                                        <div class="row">
                                                            <div class="col-md-2">
                                                                <div class="form-group">
                                                                    <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">S.No</label>
                                                                    <asp:TextBox ID="TextBox6" runat="server" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:TextBox>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <div class="form-group">
                                                                    <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">Processor Model</label>
                                                                    <asp:DropDownList ID="ddl_processorModel" class="form-control select2" runat="server" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:DropDownList>
                                                                   
                                                                </div>
                                                            </div>                                                           
                                                            <div class="col-md-2">
                                                                <div class="form-group">
                                                                    <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">Speed</label>
                                                                    <asp:DropDownList ID="ddl_processor_speed" runat="server" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:DropDownList>
                                                                  
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>

                                            </div>
                                        </div>--%>

                                    </asp:Panel>
                                  
                                        <asp:Panel ID="pnlgrid" runat="server">


                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="2px"   
                    CellPadding="5">
                    <Columns>
                   <asp:BoundField HeaderText="Asset Number" DataField= "at_Assetcode" />
                   <asp:BoundField HeaderText="Brand Make" DataField="at_brandMake" />
                   <asp:BoundField HeaderText="Model" DataField="at_model" />
                   <asp:BoundField HeaderText="Product Number" DataField="at_productNumber" />
                   <asp:BoundField HeaderText="Serial Number" DataField="at_SerialNumber" />
                   <asp:BoundField HeaderText="Purchase Number" DataField="at_purchaseNumber" />
                   <asp:BoundField HeaderText="Voucher Number" DataField="at_voucherNumber" />
                   <asp:BoundField HeaderText="Receive Date" DataField="at_receivedDate" />
                   <asp:BoundField HeaderText="Warranty Start Date" DataField="at_wsd" />
                   <asp:BoundField HeaderText="Warranty End Date" DataField="at_wed" />

                    </Columns>

                    </asp:GridView>
                    </asp:Panel>  
                                                   
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                
                                              



            </section>

        </ContentTemplate>

    </asp:UpdatePanel>


</asp:Content>

<%--<complete cpu grid to do--%>

<%--    //public void _load_cpu_griddata()
        //{
        //    DataTable dt = adt.view_Cpu_details();
        //    cpuinfo.DataSource = dt;
        //    cpuinfo.DataBind();
        //}--%>


<%--   <div class="row">

                        <div class="col-md-12">
                            <div class="box box-primary">



                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:GridView ID="cpuinfo" GridLines="None" runat="server" AutoGenerateColumns="false" Width="100%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Asset Code">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_em_requested_by" runat="server" Text='<%#Eval("cpu_AssetCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Pdt Number">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_ad_Product_Number" runat="server" Text='<%#Eval("Cpu_Product_Number") %>'></asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Product No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_ad_PR_Number" runat="server" Text='<%#Eval("Cpu_PR_Number") %>'></asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Voucher No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_ad_Voucher_Number" runat="server" Text='<%#Eval("Cpu_Voucher_Number") %>'></asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Brand">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_ad_Brand_Make" runat="server" Text='<%#Eval("Cpu_Brand_Make") %>'></asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Model">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_ad_Model" runat="server" Text='<%#Eval("Cpu_Model") %>'></asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Processor & speed">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_ad_Processorspd" runat="server" Text='<%#Eval("Cpu_processor_Type") +" & "+ Eval("Cpu_processor_Speed").ToString() %>'></asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Receive Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_ad_Cpu_Receive_Date" runat="server" Text='<%#Eval("Cpu_Receive_Date") %>'></asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="War Start Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_ad_Cpu_Warranty_Start_Date" runat="server" Text='<%#Eval("Cpu_Warranty_Start_Date") %>'></asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Warranty End Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_ad_Cpu_Warranty_Start_Date" runat="server" Text='<%#Eval("Cpu_Warranty_End_Date") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                           
                                            </Columns>
                                            <HeaderStyle CssClass="dataTables_info" />
                                            <%-- <PagerStyle Wrap="False" CssClass="GridPager" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <FooterStyle Wrap="False" CssClass="GridPager" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <EmptyDataTemplate>
                                                <asp:Label ID="lblNoRecsearch" runat="server" CssClass="no_rec_style" Text="No Records found" Width="100%" />
                                            </EmptyDataTemplate>

                                        </asp:GridView>

                                    </div>
                                </div>
                                <div class="row">
                                </div>


                            </div>
                        </div>
                    </div>--%>