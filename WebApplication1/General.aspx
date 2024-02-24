<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="General.aspx.cs" Inherits="Advising_System.General" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page 2</title>
    <link rel="stylesheet" type="text/css" href="Styles.css" />
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
            padding: 20px;
        }

        .button-container {
            display: flex;
            justify-content: space-between;
            flex-wrap: wrap;
        }

        .button-container div {
            margin-top: -5%;
        }

        .button {
            padding: 10px 20px;
            font-size: 16px;
        }
        .header{
            width:100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <div class="header">
            <center><h1>Welcome Student</h1></center>
        <span class="button-container">
            <div>
                <asp:Button ID="Button1" runat="server" OnClick="change" Text="Exams / Courses" CssClass="button" />
            </div>
            <div>
                <asp:Button ID="Button3" runat="server" OnClick="change2" Text="Slots / Instructors" CssClass="button" />
            </div>
            <div>
                <asp:Button ID="Button4" runat="server" OnClick="change1" Text="Course Prereq" CssClass="button" />
            </div>
            <div>
                <asp:Button ID="Button2" runat="server" OnClick="modifyrecords" Text="Modify Records" CssClass="button" />
            </div>
            <div>
                <asp:Button ID="Button5" runat="server" OnClick="StudentOne" Text="Return" CssClass="button" />
            </div>
        </span>
            </div>
    </form>
</body>
</html>
