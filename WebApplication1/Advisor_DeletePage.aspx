<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Advisor_DeletePage.aspx.cs" Inherits="WebApplication1.Advisor_DeletePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Delete Page</title>
       <link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body class="body-with-gradient">
    <form id="form1" runat="server">
        <div>
        <asp:Button ID="home" runat="server" OnClick="ReturnToHome" Text="Back to Home" CssClass="button1" style="position: fixed; top: 15px;  right: 50px; " />
        <center><h2 style="background-color: orange">Delete Options</h2>
        </div>
        <div>
            <div class="DivCenter">
        <h4>Graduation Plan Course:</h4>
        <p>
         Student ID :
        <asp:TextBox ID="stud_id" runat="server"></asp:TextBox>
        </p>
        <p>
         Semester Code :
        <asp:TextBox ID="sem" runat="server"></asp:TextBox>
        </p>
        <p>
         Course ID :
       <asp:TextBox ID="course" runat="server"></asp:TextBox>
       <p> 
       <asp:Button ID="deleteCourse" runat="server" Text="Submit" OnClick="deleteGradCourse" CssClass="button1"/>
       </p>
       </div>
            </div>
    </form>
</body>
</html>
