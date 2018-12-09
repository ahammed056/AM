<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TSTracker.Login1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>IT Time Sheet :: Login</title>
    <link href="App_Themes/DefaultTheme/StyleSheet.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/DefaultTheme/GridViewStyle.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/DefaultTheme/jquery-ui-redmond.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="Common/Scripts/jquery-min.js"></script>

    <script type="text/javascript" language="javascript" src="Common/Scripts/jquery-ui-min.js"></script>

    <script type="text/javascript" language="javascript" src="Common/Scripts/jquery-validate-min.js"></script>

    <script type="text/javascript" language="javascript">
      
        $(document).ready(function() {
            // ** Add Form Validation ** //
            $("#form1").validate({
                errorPlacement: function(error, element) {
                    element.closest("td").next("td").append(error);
                }
            });
            // ** Add Validation rules for controls of type "Free Text" ** //
            $("*[IsTextType]").each(function() {
                $(this).rules("add", { required: true, messages: { required: "<span  style='color:red'>*</span>"} });
                //$("#field").rules("add",  {"required":true,"range":[5,45],"messages":{"required":"The field can\'t be blank.","range":"The field must have5 to 45 characters."}});
            });
        });
        
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
                    <div class="ui-tabs ui-widget ui-widget-content ui-corner-all" style="width: 300px;
                        margin-top: 140px;">
                        <ul class="ui-tabs-nav ui-helper-reset ui-helper-clearfix ui-widget-header ui-corner-all">
                            <li>Login </li>
                        </ul>
                        <div class="ui-tabs-panel ui-widget-content ui-corner-bottom">
                            <table class="labels" cellpadding="1" cellspacing="2" width="260px;">
                                <tr>
                                    <td colspan="6">
                                        <span style="width: 90%; text-align: center">
                                            <CMDBUC:Feedback ID="Feedback" runat="server"></CMDBUC:Feedback>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 70px;">
                                        Username
                                    </td>
                                    <td align="left" style="width: 150px;">
                                        <asp:TextBox ID="txtUsername" runat="server" CssClass="textbox" IsTextType="True"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 10px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        Password
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="textbox" IsTextType="True"
                                            TextMode="Password"></asp:TextBox>
                                    </td>
                                    <td align="left">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="center">
                                        <asp:Button ID="btnLogin" runat="server" CssClass="buttons" Text="Submit" OnClick="btnLogin_Click" />
                                        &nbsp;&nbsp;
                                        <asp:Button ID="btnReset" runat="server" CssClass="buttons cancel" Text="Reset" OnClick="btnReset_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <div align="center" class="footer">
                Copyright &copy; 2015 KPCL. All Right Reserved
            </div>
        </div>
    </div>
    </form>
</body>
</html>
