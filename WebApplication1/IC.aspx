<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IC.aspx.cs" Inherits="Advising_System.IC" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Choose Instructor/Course</title>
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
            margin-bottom: 10px;
        }

        .button {
            padding: 10px 20px;
            font-size: 16px;
        }
    </style>
</head>
<body class="body2">
    <form id="form1" runat="server">
        <div class="form-container">
            <h1>Choose Instructor and Course</h1>
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Student ID:" CssClass="White"></asp:Label>
                <asp:TextBox ID="std" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Course ID:" CssClass="White"></asp:Label>
                <asp:TextBox ID="cid" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="Instructor ID:" CssClass="White"></asp:Label>
                <asp:TextBox ID="instid" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="Semester Code:" CssClass="White"></asp:Label>
                <asp:TextBox ID="semc" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button runat="server" OnClick="pro" Text="Enter" CssClass="button"></asp:Button>
            </div>
            <div class="form-group">
                <asp:Button ID="return" runat="server" OnClick="RETURN" Text="Previous Page" CssClass="button"></asp:Button>
            </div>
            <asp:Label ID="result" runat="server" Text=""></asp:Label> 
        </div>
    </form>
</body>
</html>
