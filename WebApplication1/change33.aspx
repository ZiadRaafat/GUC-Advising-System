<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="change33.aspx.cs" Inherits="Advising_System.change33" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Graduation Plan</title>
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
            <h1>View Graduation Plan</h1>
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Student ID: " CssClass="White"></asp:Label>
                <asp:TextBox ID="std" runat="server"></asp:TextBox>
                <asp:Button ID="info" runat="server" Text="Enter" OnClick="move" CssClass="button"/>
            </div>
            <div class="form-group">
                <asp:Label ID="stds" runat="server" Text=""></asp:Label>
            </div>
            <div class="form-group">
                <asp:Button runat="server" OnClick ="RETURN" Text="Previous Page" CssClass="button"></asp:Button>
            </div>
        </div>
    </form>
</body>
</html>
