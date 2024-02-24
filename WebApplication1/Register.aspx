<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Advising_System.studentregister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Registration</title>
     <link rel="stylesheet" type="text/css" href="styles2.css" />
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
   
    
}
    </style>
</head>
<body class="wrapper">
     <div class="header"> <img class="logo" src="https://i.ibb.co/gt2SX1p/guclogo.png" alt="GUC Logo"></div>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Button ID="B1" runat="server"  OnClick="goBack" Text="Back" CssClass="button" style="position: fixed; top: 30px;  right: 50px;"/><br />
            <br />
            <br />
            <center><h1>Student Registration</h1></center><br />
            <div class="DivCenter">
            Please enter your credentials<br /><br />
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
            </div>
            <center><br /><asp:Button ID="register" runat="server" OnClick="registerStud" Text="Register" CssClass="button" />
            </center>
            <br /> 
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br />
    
        </div>
       
    </form>
</body>
</html>
