<%@ Page Title="" Language="C#" MasterPageFile="~/AssetManage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AM.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
               <a href="Desktop/AddDesktop.aspx"
            <span class="info-box-icon bg-aqua"><i class="fa fa-television"></i></span></a>

            <div class="info-box-content">
              <span class="info-box-text">Desktop</span>
              <span class="info-box-number">700</span>
            </div>
                    
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        <!-- /.col -->
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-red"><i class="fa fa-laptop"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Laptops</span>
              <span class="info-box-number">410</span>
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
            <span class="info-box-icon bg-green"><i class="fa fa-print"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Printers</span>
              <span class="info-box-number">160</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        <!-- /.col -->
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-yellow"><i class="fa fa-camera"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Scanners</span>
              <span class="info-box-number">5</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        <!-- /.col -->
      </div>

      <%-- <div class="callout callout-info">
        <h4>Tip!</h4>

        <p>Add the sidebar-collapse class to the body tag to get this layout. You should combine this option with a
          fixed layout if you have a long sidebar. Doing that will prevent your page content from getting stretched
          vertically.</p>
      </div>--%>

         <!-- Default box -->
     
      <!-- /.box -->
   <div class="box">
        <div class="box-header with-border">
          <h3 class="box-title">Add New Monitor Details</h3>

          <div class="box-tools pull-right">
            <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
              <i class="fa fa-minus"></i></button>
            <%--<button type="button" class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove">
              <i class="fa fa-times"></i></button>--%>
          </div>
        </div>
        <div class="box-body">
          Start creating your amazing application!

            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!<br />
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!<br />
            
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!
            Start creating your amazing application!<br />
        </div>
        <!-- /.box-body -->
      
        <!-- /.box-footer-->
      </div>
       </section>
    
   
      
    
</asp:Content>
