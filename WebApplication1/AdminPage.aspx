<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="WebApplication1.AdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Page</title>
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
            margin-top: 20px; 
        }

        .button-container .button {
            margin: 0 10px;
        }

        .table-container {
            margin-top: 20px;
        }
        .small-buttons .button {
            padding: 8px 12px; 
            font-size: 12px;  
        }
        .headerLabel{
            margin-top:15%;
            background-color:orange;
            color:white;
             text-shadow: -1px -1px 0 black, 1px -1px 0 black, -1px 1px 0 black, 1px 1px 0 black;
        }
       
    </style>
</head>
<body class="body2">
    <form id="form1" runat="server">
        <div>
            <center>
               
                <p>&nbsp;</p>
            </center>
            <div class="header">
              <center><h1>Welcome, Admin</h1></center>
            <!-- Button Container -->
            <div class="button-container small-buttons">
                <asp:Button ID="listAllAdvisors" runat="server" OnClick="showalladvisors" Text="Show Advisors" CssClass="button" />

                <!-- Add some spacing between buttons -->
                <asp:Button ID="StdA" runat="server" OnClick="StudentAdvisor" Text="Show Students with their Advisors" CssClass="button" />

                <!-- Add some spacing between buttons -->
                <asp:Button ID="LPR" runat="server" OnClick="ListPendingRequest" Text="Show Pending Requests" CssClass="button" />

                <!-- Add some spacing between buttons -->
                <asp:Button ID="IAC" runat="server" OnClick="InstructorsAssignedCourses" Text="Show Instructor Details" CssClass="button" />

                <!-- Add some spacing between buttons -->
                <asp:Button ID="SOC" runat="server" OnClick="SemesterOfferedCourses" Text="Show Semester Details" CssClass="button" />

                <!-- Add some spacing between buttons -->
                <asp:Button ID="MR" runat="server" OnClick="Modify_Records" Text="Modify Records" CssClass="button" />

                <!-- Add some spacing between buttons -->
                <asp:Button ID="NextPage" runat="server" OnClick="AdminPart2" Text="Next Page" CssClass="button" />

                <!-- Add some spacing between buttons -->
                <asp:Button ID="logout" runat="server" OnClick="Logout" Text="Logout" CssClass="button" />
            </div>

        </div>
            </div>
    </form>
</body>
</html>