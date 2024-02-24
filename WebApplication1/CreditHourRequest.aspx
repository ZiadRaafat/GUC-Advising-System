<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreditHourRequest.aspx.cs" Inherits="Advising_System.Studentcredithoursrequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Credit Hour Request</title>
     <link rel="stylesheet" type="text/css" href="Styles.css" />
    <style>
         .border {
     width: 300px;
     margin: 0 auto;
     border: 1px solid #ccc; 
     padding: 15px;
     background-color: orange;

 }
    </style>
</head>
<body class="body2">
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="goBack" Text="Back" CssClass="button" style="position: fixed; top: 30px;  right: 50px;"/><br />
            <br />
            <center>
            <h1>Credit Hour Request</h1>
            <br />
            <div class="border">
                <center>
            Please fill in the details: <br /><br />
            Credit Hours:<br />
            <asp:TextBox ID="ch" runat="server"></asp:TextBox>
            <br />
            Request type:<br />
            <asp:TextBox ID="type" runat="server"></asp:TextBox>
            <br />
            Comments:<br />
            <asp:TextBox ID="comment" runat="server"></asp:TextBox>
                    </center>
            </div>
            <br />
            <br /><asp:Button ID="Button1" runat="server" OnClick="chReq" Text="Send request" CssClass="button"/>
            <br />
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                </center>
            <br />
        </div>
        <div>&nbsp;</div>
        <div>&nbsp;</div>
    </form>
</body>
</html>
