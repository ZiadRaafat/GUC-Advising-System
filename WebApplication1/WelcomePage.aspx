<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WelcomePage.aspx.cs" Inherits="WebApplication1.WelcomePage" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Advising System</title>
    <link rel="stylesheet" type="text/css" href="styles2.css" />
</head>
<body class="wrapper">

    <form id="form1" runat="server">
        <div>
            <img class="logo" src="https://i.ibb.co/gt2SX1p/guclogo.png" alt="GUC Logo">
            <center><h1>Welcome to the GUC Advising System</h1></center>
            <p>&nbsp;</p>
            <p>&nbsp;</p>
            <p>&nbsp;</p>
            <div class="container">
                <center><h2 class="typed-out">Login as...</h2></center>
            </div>

            <span>
         <center>   <span>
             <div class="button-container">
                <asp:Button ID="login" runat="server" OnClick="test" Text="Admin" CssClass="button"/>
                <span style="margin: 0 20px;"></span>
            
                <asp:Button ID="advisorz" runat="server" OnClick="AdvisorPage" Text="Advisor" CssClass="button"/>
                <span style="margin: 0 20px;"></span>
            
                <asp:Button ID="studentz" runat="server" OnClick="StudentPage" Text="Student" CssClass="button"/>
             </span>
              </center>
                </span>
            </div>

        
       
    </form>
</body>
</html>