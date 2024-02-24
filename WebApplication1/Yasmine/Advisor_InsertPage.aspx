<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Advisor_InsertPage.aspx.cs" Inherits="WebApplication1.Advisor_InsertPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Insert Page</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body class="body-with-gradient">
    <form id="form1" runat="server">
        <div>
        <asp:Button ID="home" runat="server" OnClick="ReturnToHome" Text="Back to Home" CssClass="button1" style="position: fixed; top: 15px;  right: 50px; " />
        <center><h2>Insertion Options</h2>
        </div>
        <div>
        <h4>Graduation Plan:</h4>
        <p>
            Semester Code :
            <asp:TextBox ID="sem_code" runat="server"></asp:TextBox>
        </p>
        <p>
            Expected Graduation Date: 
            <asp:TextBox ID="gradDate" runat="server" type="date" OnTextChanged="gradDate_TextChanged"></asp:TextBox>
        </p>
        <p>
            Semester Credit Hours :
            <asp:TextBox ID="semester_hours" runat="server"></asp:TextBox>
        </p>  
        <p>
           Student ID :
           <asp:TextBox ID="studID" runat="server"></asp:TextBox>
        </p>    
        <p> 
            <asp:Button ID="gradPlan" runat="server" Text="Submit" OnClick="insertGradPlan" CssClass="button1" />
        </p>
        <h4>Graduation Plan Course:</h4>
        <p>
            Student ID :
           <asp:TextBox ID="ID" runat="server"></asp:TextBox>
       </p>
       <p>
           Semester Code:
           <asp:TextBox ID="code" runat="server"></asp:TextBox>
       </p>  
       <p>
           Course Name :
           <asp:TextBox ID="name" runat="server"></asp:TextBox>
</p>    
<p> 
           <asp:Button ID="gradCourse" runat="server" Text="Submit" OnClick="insertGradPlanCourse" CssClass="button1" />
</p>
     </div>
    </form>
</body>
</html>
