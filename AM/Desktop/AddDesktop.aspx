<%@ Page Title="" Language="C#" MasterPageFile="~/AssetManage.Master" AutoEventWireup="true" CodeBehind="AddDesktop.aspx.cs" Inherits="AM.Desktop.AddCPU" EnableEventValidation="false" %>

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
        x0p('<h3>Hey........!</h3><br>Enter Asset Code<br><br>');
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
                    Add &nbsp;&nbsp;
           
            <asp:DropDownList ID="ddl_desktop" runat="server" OnSelectedIndexChanged="ddl_desktop_SelectedIndexChanged" AutoPostBack="true" Width="200px">
                <asp:ListItem Value="0">New Asset</asp:ListItem>
                <asp:ListItem Value="1">C P U</asp:ListItem>
                <asp:ListItem Value="2">Monitor</asp:ListItem>
                <asp:ListItem Value="3">Mouse</asp:ListItem>
                <asp:ListItem Value="4">Key Board</asp:ListItem>
                <asp:ListItem Value="5">R A M</asp:ListItem>
                <asp:ListItem Value="6">H D D</asp:ListItem>
                <asp:ListItem Value="7">O S</asp:ListItem>
            </asp:DropDownList>
                </p>
                <%--  <asp:LinkButton ID="lbtn_Add_viewPanel" runat="server" CssClass="fa fa-plus-circle" aria-hidden="true" OnClick="lbtn_Add_viewPanel_OnClick" style="float:right;height:20px;width:20px;margin-top:-1em;font-size: 20px;"  />--%>
            </section>

            <section class="content">

                <asp:Panel ID="Panel1" runat="server">

                    <div class="row">

                        <div class="col-md-12">

                            <div class="box box-primary">
                                <div class="box-body">
                                    <div class="row" style="padding: 4em 3em 2em 0em;">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <h3 style="margin-top: 4px; margin-left: 60px;">Enter New Asset Number:</h3>

                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <asp:TextBox ID="txt_assetNew_Number" runat="server" class="form-control select2"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">

                                                <asp:Button ID="btn_assetNew_Num_Save" runat="server" Text="Save" class="btn btn-block btn-info btn-sm" OnClick="btn_assetNew_Num_Save_Click" />

                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>

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
                                                    <input id="Checkbox1" type="checkbox" title="Is Os New" text="haell" style="height: 24px; width: 24px; margin-top: 20px; padding: 0PX 0PX 0PX 10PX;" />
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
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddl_new_Asset_id" class="form-control select2" runat="server" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>


                                            <%---------------------------------------------------------------------------------------------------------181--%>
                                            <div class="form-group">
                                                <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">Brand Make</label>
                                                <asp:UpdatePanel ID="raj_brand" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddl_ad_barnd" runat="server" class="form-control select2" AutoPostBack="true" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; width: 100%;" OnSelectedIndexChanged="ddl_ad_barnd_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>

                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">Product Number</label>
                                                <asp:TextBox ID="txt_ad_Product_Number" runat="server" class="form-control" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:TextBox>
                                            </div>



                                            <div class="form-group">
                                                <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">Model</label>
                                                <asp:UpdatePanel ID="raj_model" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddl_ad_brandmodel" runat="server" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; width: 100%;">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>


                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">Serial Number</label>
                                                <asp:TextBox ID="txt_ad_Serial_Number" runat="server" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">Receive Date</label>
                                                <asp:TextBox ID="txt_ad_Receive_Date" runat="server" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;" TextMode="DateTimeLocal"></asp:TextBox>
                                            </div>

                                        </div>

                                        <div class="col-md-2">

                                            <div class="form-group">
                                                <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">PR Number</label>
                                                <asp:TextBox ID="txt_ad_PR_Number" runat="server" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:TextBox>
                                            </div>


                                            <div class="form-group">
                                                <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">Warranty Start Date</label>
                                                <asp:TextBox ID="txt_ad_Warranty_Start_Date" runat="server" TextMode="DateTimeLocal" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:TextBox>

                                            </div>

                                        </div>

                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">Voucher Number</label>
                                                <asp:TextBox ID="txt_ad_Voucher_Number" runat="server" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">Warranty End Date</label>
                                                <asp:TextBox ID="txt_ad_Warranty_End_Date" runat="server" TextMode="DateTimeLocal" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:TextBox>

                                            </div>


                                        </div>

                                        <div class="col-md-2">

                                            <div class="form-group">
                                                <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">&nbsp;</label>
                                                <asp:Button ID="btn_ad_save" runat="server" Text="Save" class="btn btn-block btn-info btn-sm" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;" OnClick="btn_ad_save_Click" />

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
                                                <h4>Domain Entry</h4>
                                            </section>
                                            <div class="col-md-12">

                                                <div class="box box-primary">
                                                    <div class="box-body">
                                                        <div class="row">
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
                                                            <div class="col-md-2">
                                                                <div class="form-group">
                                                                    <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">&nbsp;Domain Name group</label>
                                                                    <%-- <asp:TextBox ID="txt_ad_Dng" runat="server" class="form-control select2" style="height: 23px;font-size: 12px;padding: 0 0 0 0; MARGIN-TOP: -10px;" ></asp:TextBox>--%>
                                                                    <asp:DropDownList ID="ddl_ad_DNG" runat="server" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:DropDownList>
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>
                                                    <%--  --%>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row" style="margin-top: -25px;">
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
                                                                    <%--   <asp:TextBox ID="TextBox22" runat="server" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:TextBox>--%>
                                                                </div>
                                                            </div>


                                                            <%--<div class="col-md-2">
                                                <div class="form-group">
                                                    <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">Type</label>
                                                    <asp:TextBox ID="TextBox26" runat="server" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:TextBox>
                                                </div>
                                            </div>--%>

                                                            <div class="col-md-2">
                                                                <div class="form-group">
                                                                    <label style="height: 25px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px; margin-top: -10px;">Speed</label>
                                                                    <asp:DropDownList ID="ddl_processor_speed" runat="server" class="form-control select2" Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:DropDownList>
                                                                    <%-- <asp:TextBox ID="TextBox25" runat="server"  Style="height: 23px; font-size: 12px; padding: 0 0 0 0; margin-top: -10px;"></asp:TextBox>--%>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>

                                            </div>
                                        </div>
                                    </asp:Panel>


                                </div>
                            </div>

                        </div>
                    </div>

                </asp:Panel>

                <asp:Panel ID="panel_cpu_grid" runat="server" Visible="true">
                    <%--   <div class="row">

                <div class="col-md-12">
                    <div class="box box-primary">

                        <!-- /.box-header -->
                        <div class="box-body">
                            <div id="example1_wrapper" class="dataTables_wrapper form-inline dt-bootstrap">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="dataTables_length" id="example1_length">
                                            <label style="height: 25px;font-size: 12px;padding: 0 0 0 0; MARGIN-TOP: -10px;margin-top: -10px;">
                                                Show
                                    <select name="example1_length" aria-controls="example1" class="form-control input-sm">
                                        <option value="10">10</option>
                                        <option value="25">25</option>
                                        <option value="50">50</option>
                                        <option value="100">100</option>
                                    </select>
                                                entries</label>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div id="example1_filter" class="dataTables_filter">
                                            <label style="height: 25px;font-size: 12px;padding: 0 0 0 0; MARGIN-TOP: -10px;margin-top: -10px;">Search:<input type="search" class="form-control input-sm" placeholder="" aria-controls="example1"></label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <table id="example1" class="table table-bordered table-striped dataTable" role="grid" aria-describedby="example1_info">
                                            <thead>
                                                <tr role="row">
                                                    <th class="sorting_asc" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Rendering engine: activate to sort column descending" style="width: 181px;">Rendering engine</th>
                                                    <th class="sorting" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-label="Browser: activate to sort column ascending" style="width: 222px;">Browser</th>
                                                    <th class="sorting" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 198px;">Platform(s)</th>
                                                    <th class="sorting" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-label="Engine version: activate to sort column ascending" style="width: 154px;">Engine version</th>
                                                    <th class="sorting" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-label="CSS grade: activate to sort column ascending" style="width: 112px;">CSS grade</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr role="row" class="odd">
                                                    <td class="sorting_1">Gecko</td>
                                                    <td>Firefox 1.0</td>
                                                    <td>Win 98+ / OSX.2+</td>
                                                    <td>1.7</td>
                                                    <td>A</td>
                                                </tr>
                                                <tr role="row" class="even">
                                                    <td class="sorting_1">Gecko</td>
                                                    <td>Firefox 1.5</td>
                                                    <td>Win 98+ / OSX.2+</td>
                                                    <td>1.8</td>
                                                    <td>A</td>
                                                </tr>
                                                <tr role="row" class="odd">
                                                    <td class="sorting_1">Gecko</td>
                                                    <td>Firefox 2.0</td>
                                                    <td>Win 98+ / OSX.2+</td>
                                                    <td>1.8</td>
                                                    <td>A</td>
                                                </tr>
                                                <tr role="row" class="even">
                                                    <td class="sorting_1">Gecko</td>
                                                    <td>Firefox 3.0</td>
                                                    <td>Win 2k+ / OSX.3+</td>
                                                    <td>1.9</td>
                                                    <td>A</td>
                                                </tr>
                                                <tr role="row" class="odd">
                                                    <td class="sorting_1">Gecko</td>
                                                    <td>Camino 1.0</td>
                                                    <td>OSX.2+</td>
                                                    <td>1.8</td>
                                                    <td>A</td>
                                                </tr>
                                                <tr role="row" class="even">
                                                    <td class="sorting_1">Gecko</td>
                                                    <td>Camino 1.5</td>
                                                    <td>OSX.3+</td>
                                                    <td>1.8</td>
                                                    <td>A</td>
                                                </tr>
                                                <tr role="row" class="odd">
                                                    <td class="sorting_1">Gecko</td>
                                                    <td>Netscape 7.2</td>
                                                    <td>Win 95+ / Mac OS 8.6-9.2</td>
                                                    <td>1.7</td>
                                                    <td>A</td>
                                                </tr>
                                                <tr role="row" class="even">
                                                    <td class="sorting_1">Gecko</td>
                                                    <td>Netscape Browser 8</td>
                                                    <td>Win 98SE+</td>
                                                    <td>1.7</td>
                                                    <td>A</td>
                                                </tr>
                                                <tr role="row" class="odd">
                                                    <td class="sorting_1">Gecko</td>
                                                    <td>Netscape Navigator 9</td>
                                                    <td>Win 98+ / OSX.2+</td>
                                                    <td>1.8</td>
                                                    <td>A</td>
                                                </tr>
                                                <tr role="row" class="even">
                                                    <td class="sorting_1">Gecko</td>
                                                    <td>Mozilla 1.0</td>
                                                    <td>Win 95+ / OSX.1+</td>
                                                    <td>1</td>
                                                    <td>A</td>
                                                </tr>
                                            </tbody>
                                            <tfoot>
                                                <tr>
                                                    <th rowspan="1" colspan="1">Rendering engine</th>
                                                    <th rowspan="1" colspan="1">Browser</th>
                                                    <th rowspan="1" colspan="1">Platform(s)</th>
                                                    <th rowspan="1" colspan="1">Engine version</th>
                                                    <th rowspan="1" colspan="1">CSS grade</th>
                                                </tr>
                                            </tfoot>
                                        </table>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-5">
                                        <div class="dataTables_info" id="example1_info" role="status" aria-live="polite">Showing 1 to 10 of 57 entries</div>
                                    </div>
                                    <div class="col-sm-7">
                                        <div class="dataTables_paginate paging_simple_numbers" id="example1_paginate">
                                            <ul class="pagination">
                                                <li class="paginate_button previous disabled" id="example1_previous"><a href="#" aria-controls="example1" data-dt-idx="0" tabindex="0">Previous</a></li>
                                                <li class="paginate_button active"><a href="#" aria-controls="example1" data-dt-idx="1" tabindex="0">1</a></li>
                                                <li class="paginate_button "><a href="#" aria-controls="example1" data-dt-idx="2" tabindex="0">2</a></li>
                                                <li class="paginate_button "><a href="#" aria-controls="example1" data-dt-idx="3" tabindex="0">3</a></li>
                                                <li class="paginate_button "><a href="#" aria-controls="example1" data-dt-idx="4" tabindex="0">4</a></li>
                                                <li class="paginate_button "><a href="#" aria-controls="example1" data-dt-idx="5" tabindex="0">5</a></li>
                                                <li class="paginate_button "><a href="#" aria-controls="example1" data-dt-idx="6" tabindex="0">6</a></li>
                                                <li class="paginate_button next" id="example1_next"><a href="#" aria-controls="example1" data-dt-idx="7" tabindex="0">Next</a></li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- /.box-body -->
                    </div>
                </div>
            </div>--%>
                    <div class="row">

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
                                             <%--   <asp:TemplateField HeaderText="Host Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_ad_Host_Name" runat="server" Text='<%#Eval("Cpu_Host_Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                            </Columns>
                                            <HeaderStyle CssClass="dataTables_info" />
                                            <%-- <PagerStyle Wrap="False" CssClass="GridPager" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <FooterStyle Wrap="False" CssClass="GridPager" HorizontalAlign="Center" VerticalAlign="Middle" />--%>
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
                    </div>
                </asp:Panel>

            </section>

        </ContentTemplate>

    </asp:UpdatePanel>


</asp:Content>
