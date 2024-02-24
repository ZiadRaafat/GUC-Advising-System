<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="install.aspx.cs" Inherits="Advising_System.install" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Please enter your Student ID:"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID ="std" runat="server"></asp:TextBox>&nbsp;</div>
        <div>
            <asp:Button ID="move" runat="server" Text="Enter" OnClick="move_Click"></asp:Button>&nbsp;<asp:Button runat="server" Onclick ="RETURN" Text="Previous Page"></asp:Button></div>
        <div>
            <asp:Label runat="server" Text="Result : "></asp:Label><asp:Label ID ="results" runat="server" Text=" "></asp:Label>&nbsp;</div>
    </form>
</body>
</html>
