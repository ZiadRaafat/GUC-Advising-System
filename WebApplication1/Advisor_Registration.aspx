<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Advisor_Registration.aspx.cs" Inherits="WebApplication1.Advisor_Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Advisor Registration</title>
     <link rel="stylesheet" type="text/css" href="Styles2.css" />
    <style>
            <style>
               body {
            display: flex;
            align-items: center;
            justify-content: center;
            margin: 0;
        }
        .wrapper{
            animation:none;
        }

        .DivCenter {
            text-align: center;
            padding: 20px;
            border: 1px solid #ccc;
             background-color: rgba(255, 165, 0, 0.5);
            border-radius:8px;
        }
        .header{
        background-color: orange;
        height: 10%;
        width:100%;
        position: absolute;
        top: 0;
            left: 0;
            display: flex;
            align-items: center;
            justify-content: center;


        }
        h1{
            opacity:100;
            animation:none;
        }
        .logo {
      opacity:100;
  animation:none;
    max-height: 100%;
    max-width: 100%;
    height: auto;
    width: auto;
    animation:none;
}
    </style>
    </style>
</head>
<body class="wrapper">
     <div class="header"> <img class="logo" src="https://i.ibb.co/gt2SX1p/guclogo.png" alt="GUC Logo"></div>
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
            <asp:Button ID="signup" runat="server" OnClick="signupPressed" Text="Sign Up" CssClass="button" />
        </div>
        <p>
        <center class="bottomText">Already have an account?</center></p>
        <p> 
       <center><asp:Button ID="login" runat="server" OnClick="loginPressed" Text="Login" CssClass="button" /></center>
       </>
        <center></center>
       
    </form>
        
</body>
</html>
