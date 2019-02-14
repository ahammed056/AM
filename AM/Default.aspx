﻿<%@ Page Title="KPCL " Language="C#" MasterPageFile="~/AssetManage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AM.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script type="text/javascript">
          function AssetRecinserted() {
              x0p('<h3>Scucess........!</h3><br>Assert Details are Uploaded<br><br>');
          }
          function AssetCodeUsed() {
              x0p('&nbsp;&nbsp;&nbsp;  <u>Used Asset Code</u>...........  &nbsp;&nbsp;&nbsp;', 'Try a New One');
          }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
      <h1>
      Assets
        <small>Working Status</small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
        <li class="active">Dashboard</li>
      </ol>
    </section>

     <section class="content">
      <div class="row">
        
        <div class="col-md-3 col-sm-6 col-xs-12">
           
          <div class="info-box">
              <span class="info-box-icon bg-aqua">
            <asp:LinkButton ID="LinkButton1" runat="server" Text="<i class='fa fa-television'></i>" OnClick="Button1_Click"  />            
             </span>
            <div class="info-box-content">
              <span class="info-box-text">Desktop</span>
              <span class="info-box-number">700</span>                
                <asp:HiddenField ID="desktop_hidden_value" runat="server" />
            </div>
                    
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        <!-- /.col -->
          <div class="clearfix visible-sm-block"></div>
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-red">
           <asp:LinkButton ID="LinkButton3" runat="server" Text="<i class='fa fa-laptop'></i>" OnClick="Button1_Click"  />            
             </span>
            <div class="info-box-content">
              <span class="info-box-text">Laptops</span>
              <span class="info-box-number">410</span>
                 <asp:HiddenField ID="Laptop_hidden_value" runat="server" />
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        <!-- /.col -->

        <!-- fix for small devices only -->
        <div class="clearfix visible-sm-block"></div>

        <div class="col-md-3 col-sm-6 col-xs-12">
        <div class="info-box">
        <span class="info-box-icon bg-green">
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click"><i class='fa fa-print'></i></asp:LinkButton>
           <%--   <asp:LinkButton ID="LinkButton2" runat="server" Text="<i class='fa fa-print'></i>" OnClick="LinkButton2_Click"/> --%>
              </span>       
            <div class="info-box-content">
              <span class="info-box-text">Printers</span>
              <span class="info-box-number">160</span>
                 <asp:HiddenField ID="Printers_hidden_value" runat="server" />
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        <!-- /.col -->
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-yellow">
           
           <asp:LinkButton ID="lbtn_scanner" runat="server" Text="<i class='fa fa-print'></i>" OnClick="lbtn_scanner_Click"  />            
             </span>
            <div class="info-box-content">
              <span class="info-box-text">Scanners</span>
              <span class="info-box-number">5</span>
               <asp:HiddenField ID="Scanner_hidden_value" runat="server" />
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        <!-- /.col -->
      </div>

   <div class="box">
        <div class="box-header with-border">
          <h3 class="box-title">Add New Asset Code</h3>

          <div class="box-tools pull-right">
            <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
              <i class="fa fa-minus"></i></button>
            <%--<button type="button" class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove">
              <i class="fa fa-times"></i></button>--%>
          </div>
        </div>
        <div class="box-body">
            <div class="container-fluid">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">

                            <div class="row">

                                <div class="col-md-12">

                                    <div class="box box-primary">
                                        <div class="box-body">

                                            <div class="row" style="padding: 4em 3em 2em 0em;">



                                                <div class="col-md-2">
                                                    <div class="form-group">
                                                        <h3 style="margin-top: 4px;">Asset Code:</h3>

                                                    </div>
                                                </div>
                                                <div class="col-md-8">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <div class="col-md-4">

                                                                    <asp:DropDownList ID="ddl_Asset_product_ad" runat="server" class="form-control select2" ValidationGroup="assno" OnSelectedIndexChanged="ddl_Asset_product_ad_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                                                                </div>

                                                                <div class="col-md-4">
                                                                    <asp:DropDownList ID="ddl_Asset_product_type_ad" runat="server" class="form-control select2" ValidationGroup="assno" AutoPostBack="true" OnSelectedIndexChanged="ddl_Asset_product_type_ad_SelectedIndexChanged"></asp:DropDownList>

                                                                </div>
                                                                <div class="col-md-4">
                                                                    <asp:TextBox ID="txt_assetNew_Number" runat="server" class="form-control select2" ValidationGroup="assno"></asp:TextBox>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="col-md-2">
                                                    <div class="form-group">

                                                        <asp:Button ID="btn_assetNew_Num_Save" runat="server" Text="Save" class="btn btn-block btn-info btn-sm" ValidationGroup="assno" OnClick="btn_assetNew_Num_Save_Click" />

                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>

                        <div class="row">
                            <div class="col-md-12">
                                <asp:Panel ID="panel_cpu_grid" runat="server" Visible="true">
                                    <div class="col-md-6">
                                        <div class="box box-primary">
                                            <asp:GridView ID="gv_Asset_df" GridLines="None" runat="server" AutoGenerateColumns="false" Width="100%" Style="margin-left: 10px;">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Asset Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_em_requested_by" runat="server" Text='<%#Eval("as_assetcode") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Asset Type">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_ad_Product_Number" runat="server" Text='<%#Eval("pr_name") %>'></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%-- <asp:TemplateField HeaderText="Created On">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_ad_PR_Number" runat="server" Text='<%#Eval("As_CreatedTime") %>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ibtn_Asset_view_aa" runat="server" ImageUrl="../dist/img/view5.png" Height="20px" Width="25px" ToolTip="View Asset" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="dataTables_info" />
                                                <PagerStyle Wrap="False" CssClass="GridPager" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <FooterStyle Wrap="False" CssClass="GridPager" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <EmptyDataTemplate>
                                                    <img src="../dist/img/view.png" />
                                                    <asp:Label ID="lblNoRecsearch" runat="server" CssClass="no_rec_style" Text="No Records found" Width="100%" />
                                                </EmptyDataTemplate>

                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="box box-primary">
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>

                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
        </div>
        <!-- /.box-body -->
      
        <!-- /.box-footer-->
      </div>
       </section>
    
   
      
    
</asp:Content>
