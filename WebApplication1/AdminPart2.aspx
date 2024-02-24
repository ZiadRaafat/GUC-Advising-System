<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPart2.aspx.cs" Inherits="WebApplication1.AdminPart2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Page 2</title>
    <link rel="stylesheet" type="text/css" href="Styles.css" />

       <style>
    .headerCell {
        border-bottom: 1px solid black;
    }

    .tableStyle {
        opacity: 0;
        transform: translateY(20px);
        animation: fadeIn 0.5s ease forwards;
        border-collapse: collapse;
        width: 100%;
        background-color: rgba(169, 169, 169, 0.4);

    }

    .tableRowStyle {
        border: 1px solid #dddddd;
    }

    .tableStyle th,
    .tableStyle td {
        border: 1px solid #dddddd;
        padding: 8px;
        text-align: left;
    }

    .tableStyle th {
        background-color: #f2f2f2;
    }

    .closeButton {
        margin-bottom: 10px; 
    }

    .button-container {
        text-align: center;
        margin-top: -2.5%; 
    }

    .button-container .button {
        margin: 0 5px;
         font-size: 9px;
       
    }

    .table-container {
        margin-top: 20px; 
    }
    .small-buttons .button {
        padding: 6px 10px; 
        font-size: 12px;  
    }
    
</style>
</head>
<body class="body2">
    <form id="form1" runat="server">
        <div>
        
            <div class="header">
            <center><h1>Welcome, Admin</h1></center>
            
            <p>&nbsp;</p>
            <div class="button-container">
                <asp:Button ID="GP" runat="server" OnClick="GradPlan" Text="Show All Graduation Plans and their Advisors" CssClass="button" />

                <asp:Button ID="Transcript" runat="server" OnClick="TranscriptDetail" Text="Show Student Transcript Details" CssClass="button" />

                <asp:Button ID="semco" runat="server" OnClick="SemCourse" Text="Show Semesters and their Courses" CssClass="button" />

                <asp:Button ID="active" runat="server" OnClick="ActiveD" Text="Show Details of Active Students" CssClass="button" />

                <asp:Button ID="pay" runat="server" OnClick="PayD" Text="Show Payment Details" CssClass="button" />

                <asp:Button ID="mod2" runat="server" OnClick="Modify2" Text="Modify Records" CssClass="button" />


                <asp:Button ID="prevP" runat="server" OnClick="PreviousPage" Text="Previous Page" CssClass="button" />

            </div>
        </div>
        </div>
    </form>
</body>
</html>




