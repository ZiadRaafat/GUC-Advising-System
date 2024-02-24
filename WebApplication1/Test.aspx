<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="WebApplication1.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="stds" runat="server" AssociatedControlID="std">ID:</asp:Label>
            <asp:TextBox ID="std" runat="server"></asp:TextBox>
            <asp:Button ID="sub" runat="server" OnClick="Submit" Text="Submit" />
        </div>
    </form>
</body>
</html>
