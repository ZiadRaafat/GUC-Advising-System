<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="nextt.aspx.cs" Inherits="Advising_System.nextt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Instructor/Course</title>
    <link rel="stylesheet" type="text/css" href="Styles.css" />
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
            padding: 20px;
        }

        .form-container {
            text-align: center;
            max-width: 400px;
            margin: 0 auto;
            padding: 20px;
            border: 1px solid #ccc;
            background-color: orange;
            border-radius: 8px;
        }

        .form-group {
            margin-bottom: 20px;
        }

        .button {
            padding: 10px 20px;
            font-size: 16px;
        }

        .result-label {
            margin-top: 10px;
            font-weight: bold;
        }
    </style>
</head>
<body class="body2">
    <form id="form1" runat="server">
        <div class="form-container">
            <h1>View Instructor and Course</h1>
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Instructor ID: " CssClass="White"></asp:Label>
                <asp:TextBox ID="std" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Course ID: " CssClass="White"></asp:Label>
                <asp:TextBox ID="std2" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="move" runat="server" Text="Enter" OnClick="nexting" CssClass="button" />
            </div>
            <div class="form-group">
                <asp:Label ID="result0" runat="server" Text=" " CssClass="result-label"></asp:Label>
                <asp:Button runat="server" OnClick="RETURN" Text="Previous Page" CssClass="button" />
            </div>
        </div>
    </form>
</body>
</html>
