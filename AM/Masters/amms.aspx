<%@ Page Title="Asset Master" Language="C#" MasterPageFile="~/AssetManage.Master" AutoEventWireup="true" CodeBehind="amms.aspx.cs" Inherits="AM.Masters.amms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <section class="content">
            <div class="box">
                <div class="box-header with-border">                    
                    <h3 class="box-title"><img src="../../dist/ahaimages/9.png" alt="Processor" style="width:29px;height:20px;margin-top:-4px;" />&nbsp;&nbsp;Asset Brands</h3>
                    <div class="box-tools pull-right">
                        <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                            <i class="fa fa-minus"></i>
                        </button>
                    </div>
                </div>
                <div class="box-body">
                    <div class="row">

                        <div class="col-md-12">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <div class="col-md-6">
                                        <div class="col-md-12">
                                            <div class="box box-primary">
                                                <div class="box-body">
                                                    <h4 class="box-title">Add Asset Types</h4>
                                                    <div class="row" style="padding: 0em 3em 2em 0em;">
                                                        <div class="col-md-5">
                                                            <div class="form-group">
                                                                <h5 style="margin-top: 4px; margin-left: 10px;">Asset Type:</h5>
                                                                <asp:Label ID="lbl_id" runat="server" Text="" Visible="false"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-5">
                                                            <div class="form-group">
                                                                <asp:TextBox ID="txt_Asset_type_amms" runat="server" class="form-control select2"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <asp:UpdatePanel ID="UpdatePanel6" runat="server"><ContentTemplate>
                                                                <asp:Button ID="btn_Asset_type_save_amms" runat="server" Text="Save" class="btn btn-block btn-info btn-sm" Width="56px" OnClick="btn_Asset_type_save_amms_Click" />
                                                           </ContentTemplate></asp:UpdatePanel>
                                                           </div>
                                                        </div>

                                                    </div>

                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="col-md-6">
                                        <div class="box box-primary">

                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <asp:GridView ID="gv_view_Assettype_grid" GridLines="None" runat="server" AutoGenerateColumns="false" Height="175PX" Width="100%" AllowPaging="true" PageSize="5" OnPageIndexChanging="gv_view_Assettype_grid_PageIndexChanging">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Asset Brand">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_asttype_id" runat="server" Text='<%#Eval("pr_id") %>'></asp:Label>
                                                                    <asp:Label ID="lbl_asttype_asm" runat="server" Text='<%#Eval("pr_Name") %>'></asp:Label>
                                                                    <asp:HiddenField ID="hf_type_name" runat="server" Value='<%#Eval("pr_Name") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ibtn_asttype_asm" runat="server" ImageUrl="../dist/img/edit.png" Height="20px" Width="20px" OnClick="ibtn_asttype_asm_Click" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="dataTables_info" />
                                                        <PagerStyle Wrap="False" CssClass="GridPager" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <PagerStyle Height="8px" HorizontalAlign="Center" />
                                                        <FooterStyle Wrap="False" CssClass="GridPager" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <EmptyDataTemplate>
                                                            <asp:Label ID="lblNoRecsearch" runat="server" CssClass="no_rec_style" Text="No Records found" Width="100%" />
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                    </div>
                </div>

            </div>

            <div class="box">
                <div class="box-header with-border">
                    <h3 class="box-title"><img src="../../dist/ahaimages/9.png" alt="Processor" style="width:29px;height:20px;margin-top:-4px;" />&nbsp;&nbsp;Asset Types and Properties</h3>

                    <div class="box-tools pull-right">
                        <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                            <i class="fa fa-minus"></i>
                        </button>
                    </div>
                </div>
                <div class="box-body">
                    <div class="row">

                        <div class="col-md-12">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <div class="col-md-6">
                                        <div class="col-md-12">
                                            <div class="box box-primary">
                                                <div class="box-body">
                                                    <h4 class="box-title">Add Types</h4>
                                                    <div class="row" style="padding: 0em 3em 2em 0em;">

                                                        <div class="col-md-5">
                                                            <div class="form-group">

                                                                <h5 style="margin-top: 4px; margin-left: 10px;">Choose Asset:</h5>
                                                                <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>

                                                            </div>
                                                        </div>
                                                        <div class="col-md-5">
                                                            <div class="form-group">
                                                                <asp:DropDownList ID="ddl_products_asm" runat="server" class="form-control select2" AutoPostBack="true" OnSelectedIndexChanged="ddl_brands_asm_SelectedIndexChanged">
                                                                   
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-5">
                                                            <div class="form-group">
                                                                <h5 style="margin-top: 4px; margin-left: 10px;"><label runat="server" id="lbl_brand_Name" title="Name"></label> Name :</h5>
                                                                <asp:Label ID="lbl_brand_id" runat="server" Text="" Visible="false"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-5">
                                                            <div class="form-group">
                                                                <asp:TextBox ID="txt_Brand_Name_amms" runat="server" class="form-control select2" ValidationGroup="barnd"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <asp:Button ID="btn_Brand_Save" runat="server" Text="Save" class="btn btn-block btn-info btn-sm" ValidationGroup="barnd" Width="56px" OnClick="btn_Brand_Save_Click" />
                                                            </div>
                                                        </div>

                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-sm-6">
                                        <div class="box box-primary">
                                            <asp:GridView ID="gv_cpu_brand_info" GridLines="None" runat="server" AutoGenerateColumns="false" Width="100%" Height="175PX" AllowPaging="true" PageSize="5" OnPageIndexChanging="gv_cpu_brand_info_PageIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Brand">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_brand_asm_id" runat="server" Text='<%#Eval("bm_id") %>'></asp:Label>
                                                            <asp:Label ID="lbl_brand_asm" runat="server" Text='<%#Eval("bm_brand") %>'></asp:Label>
                                                            <asp:HiddenField ID="hf_brand_id" runat="server" Value='<%#Eval("bm_id") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ibtn_brand_asm" runat="server" ImageUrl="../dist/img/edit.png" Height="20px" Width="20px" OnClick="ibtn_brand_asm_Click" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="dataTables_info" />
                                                <PagerStyle Wrap="False" CssClass="GridPager" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <PagerStyle Height="8px" HorizontalAlign="Center" />

                                                <FooterStyle Wrap="False" CssClass="GridPager" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <EmptyDataTemplate>
                                                    <asp:Label ID="lblNoRecsearch" runat="server" CssClass="no_rec_style" Text="No Records found" Width="100%" />
                                                </EmptyDataTemplate>

                                            </asp:GridView>


                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                    </div>
                    <div class="row">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="col-md-6">
                                    <div class="col-md-12">
                                        <div class="box box-primary">
                                            <div class="box-body">
                                                <h3 class="box-title">Add Properties</h3>
                                                <div class="row" style="padding: 0em 3em 2em 0em;">
                                                    <div class="col-md-5">
                                                        <div class="form-group">
                                                            <h5 style="margin-top: 14px; margin-left: 10px;">Choose Brand :</h5>
                                                        </div>
                                                        <div class="form-group">

                                                            <h5 style="margin-top: 28px; margin-left: 10px;">Model Name :</h5>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-5">
                                                        <div class="form-group">
                                                            <asp:DropDownList ID="ddl_brand_model_asm" runat="server" class="form-control select2" ValidationGroup="model" ></asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <asp:TextBox ID="txt_Brand_Model" runat="server" class="form-control select2" ValidationGroup="model"></asp:TextBox>
                                                        </div>
                                                    </div>


                                                    <div class="col-md-2">
                                                        <div class="form-group" style="margin-top: 50px;">
                                                            <asp:Button ID="btn_Brand_Model_save" runat="server" Text="Save" class="btn btn-block btn-info btn-sm" Width="56px" ValidationGroup="model" OnClick="btn_Brand_Model_save_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-6">
                                    <div class="box box-primary">
                                        <asp:GridView ID="gv_cpu_brand_Model_info" GridLines="None" runat="server" AutoGenerateColumns="false" Width="100%" Height="175PX" PageSize="5" OnPageIndexChanging="gv_cpu_brand_Model_info_PageIndexChanging" AllowPaging="true">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Model Number">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_brand_model_asm" runat="server" Text='<%#Eval("bbm_model") %>'></asp:Label>
                                                        <asp:HiddenField ID="hf_brand_model_name" runat="server" Value='<%#Eval("bbm_model") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ibtn_brand_model_asm" runat="server" ImageUrl="../dist/img/edit.png" Height="20px" Width="20px" OnClick="ibtn_brand_model_asm_Click" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="dataTables_info" />
                                            <PagerStyle Wrap="False" CssClass="GridPager" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <PagerStyle Height="8px" HorizontalAlign="Center" />

                                            <FooterStyle Wrap="False" CssClass="GridPager" HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <EmptyDataTemplate>
                                                <asp:Label ID="lblNoRecsearch" runat="server" CssClass="no_rec_style" Text="No Records found" Width="100%" />
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>

                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>

            <div class="box">
                <div class="box-header with-border">                    
                    <h3 class="box-title"><img src="../../dist/img/processor_icon.png" alt="Processor" style="width:20px;height:20px;margin-top:-4px;" />&nbsp;&nbsp;<b>Processor</b></h3>

                    <div class="box-tools pull-right">
                        <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                            <i class="fa fa-minus"></i>
                        </button>

                    </div>
                </div>
                <div class="box-body">
                    <div class="row"><%--style="background-image:url(../dist/img/CPU-Intel-icon.png);background-repeat: no-repeat;    background-size: 412px 259px;"--%>

                        <div class="col-md-12">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <div class="col-md-6">
                                        <div class="col-md-12">
                                            <div class="box box-primary">
                                                <div class="box-body">
                                                    <h3 class="box-title">Add Processor</h3>
                                                    <div class="row" style="padding: 0em 3em 2em 0em;">

                                                        <div class="col-md-4" style="background-image:url(../dist/img/CPU-Intel-icon.png)">
                                                            <div class="form-group" >
                                                                
                                                                <h5 style="margin-top: 4px; margin-left: 10px;">Name :</h5>

                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <asp:TextBox ID="txt_processor_name_asm" runat="server" class="form-control select2"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <asp:Button ID="btn_processor_asm" runat="server" Width="56px" Text="Save" class="btn btn-block btn-info btn-sm" OnClick="btn_processor_asm_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="box box-primary">

                                            <asp:GridView ID="gv_processor_asm" GridLines="None" runat="server" AutoGenerateColumns="false" Width="100%" Height="175px" PageSize="5" OnPageIndexChanging="gv_processor_asm_PageIndexChanging" AllowPaging="true">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Model Number">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_brand_model_asm" runat="server" Text='<%#Eval("processor_Name") %>'></asp:Label>
                                                            <asp:HiddenField ID="hf_brand_model_name" runat="server" Value='<%#Eval("processor_Name") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ibtn_brand_model_asm" runat="server" ImageUrl="../dist/img/edit.png" Height="20px" Width="20px" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="dataTables_info" />
                                                <PagerStyle Wrap="False" CssClass="GridPager" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <PagerStyle Height="8px" HorizontalAlign="Center" />

                                                <FooterStyle Wrap="False" CssClass="GridPager" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <EmptyDataTemplate>
                                                    <asp:Label ID="lblNoRecsearch" runat="server" CssClass="no_rec_style" Text="No Records found" Width="100%" />
                                                </EmptyDataTemplate>

                                            </asp:GridView>

                                        </div>

                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>


                        </div>

                    </div>
                    <div class="row">

                        <div class="col-md-12">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="col-md-6">
                                        <div class="col-md-12">
                                            <div class="box box-primary">
                                                <div class="box-body">
                                                    <h3 class="box-title">Add Proscessor Speed</h3>
                                                    <div class="row" style="padding: 0em 3em 2em 0em;">
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <h5 style="margin-top: 14px; margin-left: 10px;">Processor Name :</h5>
                                                            </div>
                                                            <div class="form-group">

                                                                <h5 style="margin-top: 28px; margin-left: 10px;">Processor Speed :</h5>

                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <asp:DropDownList ID="ddl_processor_Name_asm" runat="server" class="form-control select2"></asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <asp:TextBox ID="txt_processor_speed_asm" runat="server" class="form-control select2"></asp:TextBox>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-2">
                                                            <div class="form-group" style="margin-top: 50px;">
                                                                <asp:Button ID="btn_processor_speed_asm" runat="server"  Width="56px" Text="Save" class="btn btn-block btn-info btn-sm" OnClick="btn_processor_speed_asm_Click" />
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="box box-primary">

                                            <asp:GridView ID="gv_processor_speed_asm" GridLines="None" runat="server" AutoGenerateColumns="false" Width="100%" Height="175PX" PageSize="5" OnPageIndexChanging="gv_cpu_brand_Model_info_PageIndexChanging" AllowPaging="true">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Model Number">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_brand_model_asm" runat="server" Text='<%#Eval("processor_speed") %>'></asp:Label>
                                                            <asp:HiddenField ID="hf_brand_model_name" runat="server" Value='<%#Eval("processor_speed") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ibtn_brand_model_asm" runat="server" ImageUrl="../dist/img/edit.png" Height="20px" Width="20px" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="dataTables_info" />
                                                <PagerStyle Wrap="False" CssClass="GridPager" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <PagerStyle Height="8px" HorizontalAlign="Center" />

                                                <FooterStyle Wrap="False" CssClass="GridPager" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <EmptyDataTemplate>
                                                    <asp:Label ID="lblNoRecsearch" runat="server" CssClass="no_rec_style" Text="No Records found" Width="100%" />
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
              <div class="box">
                <div class="box-header with-border">
                    <h3 class="box-title">Monitor</h3>

                    <div class="box-tools pull-right">
                        <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                            <i class="fa fa-minus"></i>
                        </button>

                    </div>
                </div>
                <div class="box-body">
                    <div class="row">

                        <div class="col-md-12">
                            <asp:UpdatePanel ID="UpdatePanelm3" runat="server">
                                <ContentTemplate>
                                    <div class="col-md-6">
                                        <div class="col-md-12">
                                            <div class="box box-primary">
                                                <div class="box-body">
                                                    <h3 class="box-title">Add Monitor brand</h3>
                                                    <div class="row" style="padding: 0em 3em 2em 0em;">

                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <h5 style="margin-top: 4px; margin-left: 10px;">Brand Name :</h5>

                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <asp:TextBox ID="txt_Monitor_name_asm" runat="server" class="form-control select2"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <asp:Button ID="btn_Monitor_asm" runat="server" Text="Save" Width="56px" class="btn btn-block btn-info btn-sm" OnClick="btn_Monitor_asm_Click"   />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="box box-primary">

                                            <asp:GridView ID="gv_Monitor_barnd_asm" GridLines="None" runat="server" AutoGenerateColumns="false" Width="100%" Height="175PX" PageSize="5" OnPageIndexChanging="gv_Monitor_barnd_asm_PageIndexChanging" AllowPaging="true">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Model Number">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_moniter_brand_asm" runat="server" Text='<%#Eval("bm_brand") %>'></asp:Label>
                                                            <asp:HiddenField ID="hf_moniter_brand_asm" runat="server" Value='<%#Eval("bm_brand") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ibtn_moniter_brand_asm" runat="server" ImageUrl="../dist/img/edit.png" Height="20px" Width="20px" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="dataTables_info" />
                                                <PagerStyle Wrap="False" CssClass="GridPager" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <PagerStyle Height="8px" HorizontalAlign="Center" />

                                                <FooterStyle Wrap="False" CssClass="GridPager" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <EmptyDataTemplate>
                                                    <asp:Label ID="lblNoRecsearch" runat="server" CssClass="no_rec_style" Text="No Records found" Width="100%" />
                                                </EmptyDataTemplate>

                                            </asp:GridView>

                                        </div>

                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>


                        </div>

                    </div>
                    <div class="row">

                        <div class="col-md-12">
                            <asp:UpdatePanel ID="UpdatePanelm5" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="col-md-6">
                                        <div class="col-md-12">
                                            <div class="box box-primary">
                                                <div class="box-body">
                                                    <h3 class="box-title">Add Monitor Model</h3>
                                                    <div class="row" style="padding: 0em 3em 2em 0em;">
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <h5 style="margin-top: 14px; margin-left: 10px;">Brand Name :</h5>
                                                            </div>
                                                            <div class="form-group">

                                                                <h5 style="margin-top: 28px; margin-left: 10px;">Model :</h5>

                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <asp:DropDownList ID="ddl_MonitorModel_asm" runat="server" class="form-control select2"></asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                <asp:TextBox ID="txt_Monitor_Model_asm" runat="server" class="form-control select2"></asp:TextBox>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-2">
                                                            <div class="form-group" style="margin-top: 50px;">
                                                                <asp:Button ID="btn_Monitor_Model_asm" runat="server" Width="56px" Text="Save" class="btn btn-block btn-info btn-sm" OnClick="btn_Monitor_Model_asm_Click" />
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="box box-primary">

                                            <asp:GridView ID="gv_Monitor_barnd_model_asm" GridLines="None" runat="server" AutoGenerateColumns="false" Width="100%" Height="175PX" PageSize="5" OnPageIndexChanging="gv_Monitor_barnd_model_asm_PageIndexChanging" AllowPaging="true">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Model Number">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_moniter_brand_model_asm" runat="server" Text='<%#Eval("bbm_model") %>'></asp:Label>
                                                            <asp:HiddenField ID="hf_moniter_brand_model_name" runat="server" Value='<%#Eval("bbm_model") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ibtn_moniter_brand_model_asm" runat="server" ImageUrl="../dist/img/edit.png" Height="20px" Width="20px" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="dataTables_info" />
                                                <PagerStyle Wrap="False" CssClass="GridPager" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <PagerStyle Height="8px" HorizontalAlign="Center" />

                                                <FooterStyle Wrap="False" CssClass="GridPager" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <EmptyDataTemplate>
                                                    <asp:Label ID="lblNoRecsearch" runat="server" CssClass="no_rec_style" Text="No Records found" Width="100%" />
                                                </EmptyDataTemplate>

                                            </asp:GridView>

                                        </div>

                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </asp:Panel>
</asp:Content>


















   <%--<button type="button" class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove">
              <i class="fa fa-times"></i></button>--%>