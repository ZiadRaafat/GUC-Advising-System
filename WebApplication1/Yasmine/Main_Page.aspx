<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main_Page.aspx.cs" Inherits="WebApplication1.WelcomePage" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Advising System</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body class="body-with-image">
    <form id="form1" runat="server">
        <div>
            <center><h1 class="PopAnim">Advising System</h1></center>
            <p>&nbsp;</p>
            <p>&nbsp;</p>
            <p>&nbsp;</p>
            <div class="container">
                <center><h2 class="typed-out">Login as...</h2></center>
            </div>

            <span>
         <center>   <span>
                <asp:Button ID="admin" runat="server" OnClick="AdminPage" Text="Admin" CssClass="button"/>
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