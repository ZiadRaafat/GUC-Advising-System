<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Advisor_Login.aspx.cs" Inherits="WebApplication1.Advisor_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Advisor Login</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
    <style>
        body {
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100%;
            margin: 0;
        }
    </style>
</head>
<body class="body-with-image">
    <form id="form1" runat="server">
        <asp:Button ID="exit" runat="server" OnClick="exitPressed" Text="Exit" CssClass="button" style="position: fixed; top: 30px;  right: 50px; " />
        <center><h1>Advisor Login</h1></center>
        <div class="DivCenter">
            Please enter your credentials<br />
            <br />
            ID:<br />
            <asp:TextBox ID="userID" runat="server"></asp:TextBox>
            <br />
            Password:<br />
            <asp:TextBox ID="password" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="login" runat="server" OnClick="loginPressed" Text="Login" CssClass="button1" />
        </div>
        <p>
            <center class="bottomText">Don't have an account?</center></p>
        <p> 
            <center><asp:Button ID="register" runat="server" OnClick="registerPressed" Text="Register" CssClass="button1"/></center>
        </p>
    </form>
        
</body>
</html>