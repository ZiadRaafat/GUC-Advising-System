<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="install.aspx.cs" Inherits="Advising_System.install" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Installment</title>
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

        .result-label {
            margin-top: 10px;
            font-weight: bold;
        }
    </style>
</head>
<body class="body2">
    <form id="form1" runat="server">
        <div class="form-container">
            <h1>View Installments</h1>
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Please enter your Student ID:" CssClass="White"></asp:Label>
            </div>
            <div class="form-group">
                <asp:TextBox ID="std" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="move" runat="server" Text="Enter" OnClick="move_Click" CssClass="button" />
                <asp:Button runat="server" OnClick="RETURN" Text="Previous Page" CssClass="button" />
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="Result: " CssClass="White result-label"></asp:Label>
                <asp:Label ID="results" runat="server" Text="" CssClass="White"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
