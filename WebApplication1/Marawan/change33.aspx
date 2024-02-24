<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="change33.aspx.cs" Inherits="Advising_System.change33" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Information</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="Label1" runat="server" Text="Student ID: "></asp:Label>


               <asp:TextBox ID="std" runat="server"></asp:TextBox>
            <asp:Button ID="info" runat="server" Text="Enter" OnClick="move" />
            <br />
            <asp:Label ID="stds" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button runat="server" OnClick ="RETURN" Text="Previous Page"></asp:Button>&nbsp;</div>
    </form>
</body>
</html>
