<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Advisor_Home.aspx.cs" Inherits="WebApplication1.Advisor_Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Advisor HomePage</title>
    <link rel="stylesheet" type="text/css" href="style.css" />

</head>

<body class="body-with-gradient">
    <form id="form1" runat="server">
     <asp:Button ID="logout" runat="server" OnClick="LogOut" Text="Logout" CssClass="button" style="position: fixed; top: 15px;  right: 50px; " />
     <center><h1>Welcome</h1> 
    <h2 class="dashboard-title">Dashboard</h2> </center>
     <center>
     <asp:Button ID="viewStudents" runat="server" OnClick="ViewStudents" Text="View Students" CssClass="button1" />
     
     <asp:Button ID="viewAllRequests" runat="server" OnClick="ViewAllRequests" Text="View All Requests" CssClass="button1" />

     <asp:Button ID="viewPendingRequests" runat="server" OnClick="ViewPendingRequests" Text="View Pending Requests" CssClass="button1" />
     
     <asp:Button ID="studentsMajor" runat="server" OnClick="ViewStudentsInMajor" Text="View Students per Major" CssClass="button1"/>

     <asp:Button ID="processRequests" runat="server" OnClick="ProcessRequests" Text="Process Requests" CssClass="button1" />

     <asp:Button ID="insert" runat="server" OnClick="ViewInsertOptions" Text="Insert" CssClass="button1" />

     <asp:Button ID="update" runat="server" OnClick="ViewUpdateOptions" Text="Update" CssClass="button1" />

     <asp:Button ID="delete" runat="server" OnClick="ViewDeleteOptions" Text="Delete" CssClass="button1" />


     </center>
    </form>
</body>
</html>
