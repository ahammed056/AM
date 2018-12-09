<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="TSTracker.Logout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CMDB Traker :: Logout</title>
    <link href="App_Themes/DefaultTheme/StyleSheet.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/DefaultTheme/GridViewStyle.css" rel="Stylesheet" type="text/css" />
    <link href="App_Themes/DefaultTheme/jquery-ui-redmond.css" rel="stylesheet" type="text/css" />
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
                            <li>Logout</li>
                        </ul>
                        <div class="ui-tabs-panel ui-widget-content ui-corner-bottom">
                            <table class="labels" cellpadding="1" cellspacing="2" width="260px;" height="100px;">
                                <tr>
                                    <td align="right" style="line-height: 20px;">
                                        <span class="labels" style="font-size: 12px;">You have been successfully logged out,
                                            Please <a href="Login.aspx"><b>click here</b></a> to Re-login</span>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <div align="center" class="footer">
                Copyright &copy; 2014 Genpact. All Right Reserved
            </div>
        </div>
    </div>
    </form>
</body>
</html>
