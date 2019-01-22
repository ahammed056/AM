<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AM.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function GetClientDetails() {
            var net = new ActiveXObject("wscript.network");

            document.write('Computer Name : ' + net.ComputerName + '\n User Name : ' + net.UserName + '\n Domain Name : ' + net.UserDomain);

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
         <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
         <input id="Button1" onclick="GetClientDetails();" type="button" value="button" />

        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
    </div>
    </form>
</body>
</html>
