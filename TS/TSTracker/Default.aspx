<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TSTracker._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <!-- Using multiple values within a single tag -->
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7, IE=EmulateIE8, IE=EmulateIE9" />
    <title>IT Compliance Metrics Platform :: Login</title>
    <link href="App_Themes/DefaultTheme/StyleSheet.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/DefaultTheme/GridViewStyle.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/DefaultTheme/jquery-ui-redmond.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="Common/Scripts/jquery-min.js"></script>

    <script type="text/javascript" language="javascript" src="Common/Scripts/jquery-ui-min.js"></script>

    <script type="text/javascript" language="javascript" src="Common/Scripts/jquery-validate-min.js"></script>

    <script type="text/javascript" language="javascript">

        //' <summary>
        //'  Author      : <Bhanuprakash>
        //'  Create date : <27-Aug-2012> 
        //'  Description : <Client-side operations>
        //'  Input       : <->
        //' </summary>
//////        $(document).ready(function() {

//////            // ** Add Form Validation ** //
//////            $("#form1").validate({
//////                errorPlacement: function(error, element) {
//////                    element.closest("td").next("td").append(error);
//////                }
//////            });
//////            // ** Add Validation rules for controls of type "Free Text" ** //
//////            $("*[IsTextType]").each(function() {
//////                $(this).rules("add", { required: true, messages: { required: "<span  style='color:red'>*</span>"} });
//////                //$("#field").rules("add",  {"required":true,"range":[5,45],"messages":{"required":"The field can\'t be blank.","range":"The field must have5 to 45 characters."}}); 
//////            });
//////        });
        
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <div align="center" class="pagewidth">
            <div class="banner">
            </div>
            <div style="border-bottom: solid 2px #2873a6; border-top: solid 1px Silver;">
                <div align="center" class="menu">
                </div>
            </div>
            <div align="center">
                <div class="contentdiv">
                    <div class="ui-tabs ui-widget ui-widget-content ui-corner-all" style="width: 710px;
                        margin-top: 140px;">
                        <ul class="ui-tabs-nav ui-helper-reset ui-helper-clearfix ui-widget-header ui-corner-all">
                            <li style="font-size: larger;">Permission Denied</li>
                        </ul>
                        <div class="ui-tabs-panel ui-widget-content ui-corner-bottom">
                            <table class="labels" cellpadding="1" cellspacing="2" width="710px;" height="140px;">
                                <tr>
                                    <td align="right" style="line-height: 20px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <CMDBUC:Feedback ID="Feedback" runat="server"></CMDBUC:Feedback>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <span style="font-size: larger;">Invalid User!, You do not have permission to retrieve
                                            the URL or link you requested</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <span style="font-size: larger;">To obtain access to this, contact your local administrator</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <br />
                                        <span style="font-size: larger;">Please write an email to <a href="mailto:epms_support@krishnapatnamport.com"
                                            style="outline: none;"><span style="color: Blue;">EPMS</span>
                                        </a>for any application issues or support</span>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <div align="center" class="footer">
                Copyright &copy; 2014 . All Right Reserved
            </div>
        </div>
    </div>
    </form>
</body>
</html>

