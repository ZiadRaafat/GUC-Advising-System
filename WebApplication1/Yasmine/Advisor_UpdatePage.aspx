<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Advisor_UpdatePage.aspx.cs" Inherits="WebApplication1.Advisor_UpdatePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Page</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body class="body-with-gradient">
    <form id="form1" runat="server">
        <div>
        <asp:Button ID="home" runat="server" OnClick="ReturnToHome" Text="Back to Home" CssClass="button1" style="position: fixed; top: 15px;  right: 50px; " />
         <center><h2>Update Options</h2>
        </div>
        <div>
        <h4>Graduation Plan:</h4>
        <p>
         Student ID :
        <asp:TextBox ID="stud_id" runat="server"></asp:TextBox>
        </p>
        <p>
        Expected Graduation Date: 
        <asp:TextBox ID="gradDate" runat="server" type="date" OnTextChanged="gradDate_TextChanged"></asp:TextBox>
        </p>
        <p> 
           <asp:Button ID="updateDate" runat="server" Text="Submit" OnClick="updateGradDate" CssClass="button1"/>
        </p>
        </div>
    </form>
</body>
</html>
