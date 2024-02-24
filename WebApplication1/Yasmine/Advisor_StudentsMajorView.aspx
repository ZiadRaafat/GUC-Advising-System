<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Advisor_StudentsMajorView.aspx.cs" Inherits="WebApplication1.Advisor_StduentsMajorView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="styles.css" />
    <title>View Students In Major</title>
</head>
<body class="body-with-gradient">
    <form id="form1" runat="server">
          <div>
            <center><h2>View Students In A Certain Major </h2>
          <asp:Button ID="home" runat="server" OnClick="ReturnToHome" Text="Back to Home" CssClass="button1" style="position: fixed; top: 15px;  right: 50px; " />
          </div>
          <div>
          <br />
          <div style="margin-left: 10px">Major:<br />
          <asp:TextBox ID="major" runat="server"></asp:TextBox>
          </div>
          <asp:Button ID="view" runat="server" OnClick="viewPressed" Text="View"  CssClass="button1"/>
        </div>
    </form>
</body>
</html>
