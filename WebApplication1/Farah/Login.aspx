<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Advising_System.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             Please LogIn<br />
             Student ID:<br />
             <asp:TextBox ID="studid" runat="server"></asp:TextBox>
             <br />
             Password:<br />
             <asp:TextBox ID="password" runat="server"></asp:TextBox>
             <br />
            <br /><asp:Button ID="loginf" runat="server" OnClick="loginfe3lan" Text="Log In" />
            <br />
            <br />Don't have an account?<br />
            <br /><asp:Button ID="Button1" runat="server" OnClick="reg" Text="Register" />
            <br />
            <br /><asp:Label ID="Label2" runat="server" Text=""></asp:Label>

        </div>
    </form>
</body>
</html>
