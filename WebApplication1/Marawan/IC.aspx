<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IC.aspx.cs" Inherits="Advising_System.IC" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="StudentID:"></asp:Label>
            &nbsp;
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
            <asp:Label ID="Label4" runat="server" Text="Instructor ID:"></asp:Label>
            &nbsp;
        </div>
        <div>
            <asp:TextBox ID="instid" runat="server"></asp:TextBox>
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
            <asp:Button runat="server" OnClick="pro" Text="Enter"></asp:Button>
            &nbsp;
        </div>
        <div>
            
            &nbsp;</div>
        <div>&nbsp;<asp:Button ID ="return" runat="server" Onclick ="RETURN" Text="Previous Page"></asp:Button></div>
        <asp:Label ID="result" runat="server" Text=""></asp:Label> 
    </form>
</body>
</html>
