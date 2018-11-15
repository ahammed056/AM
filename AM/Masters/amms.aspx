<%@ Page Title="" Language="C#" MasterPageFile="~/AssetManage.Master" AutoEventWireup="true" CodeBehind="amms.aspx.cs" Inherits="AM.Masters.amms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:Panel ID="Panel1" runat="server">

          <section class="content">
              <div class="box">
                  <div class="box-header with-border">
                      <h3 class="box-title">Asset Types</h3>

                      <div class="box-tools pull-right">
                          <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                              <i class="fa fa-plus"></i>
                          </button>
                          <%--<button type="button" class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove">
              <i class="fa fa-times"></i></button>--%>
                      </div>
                  </div>
                  <div class="box-body">
                      <div class="row">

                          <div class="col-md-12">
                              <div class="col-md-6">
                                  <div class="col-md-12">
                                      <div class="box box-primary">
                                          <div class="box-body">
                                              <h3 class="box-title">Add Asset Types</h3>
                                              <div class="row" style="padding: 0em 3em 2em 0em;">

                                                  <div class="col-md-5">
                                                      <div class="form-group">
                                                          <h5 style="margin-top: 4px; margin-left: 10px;">Enter Type of Asset :</h5>

                                                      </div>
                                                  </div>
                                                  <div class="col-md-5">
                                                      <div class="form-group">
                                                          <asp:TextBox ID="txt_Asset_type_amms" runat="server" class="form-control select2"></asp:TextBox>
                                                      </div>
                                                  </div>
                                                  <div class="col-md-2">
                                                      <div class="form-group">
                                                          <asp:Button ID="btn_Asset_type_save_amms" runat="server" Text="Save" class="btn btn-block btn-info btn-sm" OnClick="btn_Asset_type_save_amms_Click" />
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
                                  <asp:GridView ID="gv_view_Assettype_grid" GridLines="None" runat="server" AutoGenerateColumns="false" Width="100%">
                                      <Columns>
                                          <asp:TemplateField HeaderText="S.No">
                                              <ItemTemplate>
                                                  <%# Container.DataItemIndex + 1 %>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Asset Type">
                                              <ItemTemplate>
                                                  <asp:Label ID="lbl_asttype_asm" runat="server" Text='<%#Eval("type_name") %>'></asp:Label>
                                                  <asp:HiddenField ID="hf_type_name" runat="server" Value='<%#Eval("type_name") %>' />
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                           <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibtn_asttype_asm" runat="server" ImageUrl="../dist/img/edit.png" Height="20px" width="20px" OnClick="ibtn_asttype_asm_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    
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

                      </div>
                  </div>

              </div>
              <div class="box">
                  <div class="box-header with-border">
                      <h3 class="box-title">Desktop Brands and Models</h3>

                      <div class="box-tools pull-right">
                          <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                              <i class="fa fa-minus"></i>
                          </button>
                          <%--<button type="button" class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove">
              <i class="fa fa-times"></i></button>--%>
                      </div>
                  </div>
                  <div class="box-body">
                      <div class="row">

                          <div class="col-md-12">
                              <div class="col-md-6">
                                  <div class="col-md-12">
                                      <div class="box box-primary">
                                          <div class="box-body">
                                              <h3 class="box-title">Add Brands</h3>
                                              <div class="row" style="padding: 0em 3em 2em 0em;">

                                                  <div class="col-md-5">
                                                      <div class="form-group">
                                                          <h5 style="margin-top: 4px; margin-left: 10px;">Enter New Brand Name :</h5>

                                                      </div>
                                                  </div>
                                                  <div class="col-md-5">
                                                      <div class="form-group">
                                                          <asp:TextBox ID="txt_Brand_Name" runat="server" class="form-control select2" ValidationGroup="barnd"></asp:TextBox>
                                                      </div>
                                                  </div>
                                                  <div class="col-md-2">
                                                      <div class="form-group">

                                                          <asp:Button ID="btn_Brand_Save" runat="server" Text="Save" class="btn btn-block btn-info btn-sm" ValidationGroup="barnd" OnClick="btn_Brand_Save_Click" />


                                                      </div>
                                                  </div>

                                              </div>

                                          </div>
                                      </div>
                                  </div>
                              </div>

                              <div class="col-md-6">
                                  <div class="col-md-12">
                                      <div class="box box-primary">
                                          <div class="box-body">
                                              <h3 class="box-title">Add Models</h3>
                                              <div class="row" style="padding: 0em 3em 2em 0em;">
                                                  <div class="col-md-5">
                                                      <div class="form-group">
                                                          <h5 style="margin-top: 14px; margin-left: 10px;">Choose Brand :</h5>
                                                      </div>
                                                      <div class="form-group">

                                                          <h5 style="margin-top: 28px; margin-left: 10px;">Enter New Model Name :</h5>

                                                      </div>
                                                  </div>
                                                  <div class="col-md-5">
                                                      <div class="form-group">
                                                          <asp:DropDownList ID="ddl_amms_brand" runat="server" class="form-control select2" ValidationGroup="model"></asp:DropDownList>
                                                      </div>
                                                      <div class="form-group">
                                                          <asp:TextBox ID="txt_Brand_Model" runat="server" class="form-control select2" ValidationGroup="model"></asp:TextBox>
                                                      </div>
                                                  </div>


                                                  <div class="col-md-2">
                                                      <div class="form-group" style="margin-top: 50px;">

                                                          <asp:Button ID="btn_Brand_Model_save" runat="server" Text="Save" class="btn btn-block btn-info btn-sm" ValidationGroup="model" OnClick="btn_Brand_Model_save_Click" />


                                                      </div>
                                                  </div>

                                              </div>
                                          </div>
                                      </div>
                                  </div>
                              </div>
                          </div>

                      </div>



                      <div class="box box-primary">



                          <div class="row">
                              <div class="col-sm-12">
                                  <asp:GridView ID="gv_cpu_brand_info" GridLines="None" runat="server" AutoGenerateColumns="false" Width="100%">
                                      <Columns>
                                          <asp:TemplateField HeaderText="S.No">
                                              <ItemTemplate>
                                                  <%# Container.DataItemIndex + 1 %>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Brand">
                                              <ItemTemplate>
                                                  <asp:Label ID="lbl_em_requested_by" runat="server" Text='<%#Eval("bm_brand") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Model Number">
                                              <ItemTemplate>
                                                  <asp:Label ID="lbl_ad_Product_Number" runat="server" Text='<%#Eval("bm_model") %>'></asp:Label>

                                              </ItemTemplate>
                                          </asp:TemplateField>
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
              <div class="box">
                  <div class="box-header with-border">
                      <h3 class="box-title">Processor</h3>

                      <div class="box-tools pull-right">
                          <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                              <i class="fa fa-minus"></i>
                          </button>
                          <%--<button type="button" class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove">
              <i class="fa fa-times"></i></button>--%>
                      </div>
                  </div>
                  <div class="box-body">
                      <div class="row">

                          <div class="col-md-12">
                              <div class="col-md-6">
                                  <div class="col-md-12">
                                      <div class="box box-primary">
                                          <div class="box-body">
                                              <h3 class="box-title">Add Processor</h3>
                                              <div class="row" style="padding: 0em 3em 2em 0em;">

                                                  <div class="col-md-5">
                                                      <div class="form-group">
                                                          <h5 style="margin-top: 4px; margin-left: 10px;">Enter Processor Name :</h5>

                                                      </div>
                                                  </div>
                                                  <div class="col-md-5">
                                                      <div class="form-group">
                                                          <asp:TextBox ID="TextBox1" runat="server" class="form-control select2"></asp:TextBox>
                                                      </div>
                                                  </div>
                                                  <div class="col-md-2">
                                                      <div class="form-group">

                                                          <asp:Button ID="Button2" runat="server" Text="Save" class="btn btn-block btn-info btn-sm" />


                                                      </div>
                                                  </div>

                                              </div>

                                          </div>
                                      </div>
                                  </div>
                              </div>

                              <div class="col-md-6">
                                  <div class="col-md-12">
                                      <div class="box box-primary">
                                          <div class="box-body">
                                              <h3 class="box-title">Add Proscessor Speed</h3>
                                              <div class="row" style="padding: 0em 3em 2em 0em;">
                                                  <div class="col-md-5">
                                                      <div class="form-group">
                                                          <h5 style="margin-top: 14px; margin-left: 10px;">Choose Processor :</h5>
                                                      </div>
                                                      <div class="form-group">

                                                          <h5 style="margin-top: 28px; margin-left: 10px;">Enter Processor Speed :</h5>

                                                      </div>
                                                  </div>
                                                  <div class="col-md-5">
                                                      <div class="form-group">
                                                          <asp:DropDownList ID="DropDownList1" runat="server" class="form-control select2"></asp:DropDownList>
                                                      </div>
                                                      <div class="form-group">
                                                          <asp:TextBox ID="TextBox2" runat="server" class="form-control select2"></asp:TextBox>
                                                      </div>
                                                  </div>


                                                  <div class="col-md-2">
                                                      <div class="form-group" style="margin-top: 50px;">

                                                          <asp:Button ID="Button3" runat="server" Text="Save" class="btn btn-block btn-info btn-sm" />


                                                      </div>
                                                  </div>

                                              </div>
                                          </div>
                                      </div>
                                  </div>
                              </div>
                          </div>

                      </div>
                  </div>

              </div>
          </section>
                </asp:Panel>
</asp:Content>
