<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Advising_System.studentregister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Button ID="B1" runat="server"  OnClick="erga3" Text="Back" /><br />
            <br />
            <br />
            Welcome dear student, please register!<br />
            First name:<br />
            <asp:TextBox ID="fname" runat="server"></asp:TextBox>
            <br />
            Last name:<br />
            <asp:TextBox ID="lname" runat="server"></asp:TextBox>
            <br />
            Password:<br />
            <asp:TextBox ID="password" runat="server" OnTextChanged="password_TextChanged"></asp:TextBox>
            <br />
            Faculty:<br />
            <asp:TextBox ID="faculty" runat="server"></asp:TextBox>
            <br />
            Email:<br />
            <asp:TextBox ID="email" runat="server"></asp:TextBox>
            <br />
            Major:<br />
            <asp:TextBox ID="major" runat="server"></asp:TextBox>
            <br />
            Semester:<br />
            <asp:TextBox ID="semester" runat="server"></asp:TextBox>
            <br />
            <br /><asp:Button ID="register" runat="server" OnClick="registerfe3lan" Text="Register" />
            <br /> 
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br />
    
        </div>
       
    </form>
</body>
</html>
