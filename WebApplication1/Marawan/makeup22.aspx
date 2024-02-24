<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="makeup22.aspx.cs" Inherits="Advising_System.makeup22" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="StudentID:"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="std" runat="server"></asp:TextBox>
            &nbsp;
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="CourseID:"></asp:Label>
            &nbsp;
        </div>
        <div>
            <asp:TextBox ID="cid" runat="server"></asp:TextBox>
            &nbsp;
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="Semester Code:"></asp:Label>
            &nbsp;
        </div>
        <div>
            <asp:TextBox ID="semc" runat="server"></asp:TextBox>
            &nbsp;
        </div>
        <div>
            <asp:Button ID="temp" runat="server" OnClick="proceed" Text="Enter"></asp:Button>
            &nbsp;
        </div>
        <div>
            <asp:Button runat="server" Onclick ="RETURN" Text="Previous Page"></asp:Button>&nbsp;</div>
        <asp:Label ID="result" runat="server" Text=" "></asp:Label> 
    </form>
</body>
</html>