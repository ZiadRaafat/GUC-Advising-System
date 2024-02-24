<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Advisor_Registration.aspx.cs" Inherits="WebApplication1.Advisor_Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Advisor Registration</title>
     <link rel="stylesheet" type="text/css" href="styles.css" />

    <style>
        body {
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100vh;
            margin: 0;
        }
    </style>
</head>
<body class="body-with-image">
    <form id="form1" runat="server">
        <asp:Button ID="Exit" runat="server" OnClick="exitPressed" Text="Exit" CssClass="button" style="position: fixed; top: 30px;  right: 50px; " />
        <center><h1>Advisor Registration</h1></center>
        <div class="DivCenter">
            Please fill in with your information<br />
            <br />
            Name:<br />
            <asp:TextBox ID="name" runat="server"></asp:TextBox>
            <br />
            Office:<br />
            <asp:TextBox ID="office" runat="server"></asp:TextBox>
            <br />
            Email:<br />
            <asp:TextBox ID="email" runat="server"></asp:TextBox>
            <br />
            Password:<br />
            <asp:TextBox ID="password" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="signup" runat="server" OnClick="signupPressed" Text="Sign Up" CssClass="button1" />
        </div>
        <p>
        <center class="bottomText">Already have an account?</center></p>
        <p> 
       <center><asp:Button ID="login" runat="server" OnClick="loginPressed" Text="Login" CssClass="button1" /></center>
       </>
        <center></center>
       
    </form>
        
</body>
</html>
