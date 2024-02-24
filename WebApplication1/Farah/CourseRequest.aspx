<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseRequest.aspx.cs" Inherits="Advising_System.Studentcourserequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Erga3" Text="Back" /><br />
            <br />
            <br />
            Please fill in the details.<br />
            Course ID:<br />
            <asp:TextBox ID="cid" runat="server"></asp:TextBox>
            <br />
            Request type:<br />
            <asp:TextBox ID="ctype" runat="server"></asp:TextBox>
            <br />
            Comment:<br />
            <asp:TextBox ID="comment" runat="server"></asp:TextBox>
            <br />
            <br /><asp:Button ID="courserequest" runat="server" OnClick="coursereqfe3lan" Text="Send Request" />
            <br />
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br />
    
            
        </div>
        <div>&nbsp;</div>
        <div>&nbsp;</div>
    </form>
</body>
</html>
