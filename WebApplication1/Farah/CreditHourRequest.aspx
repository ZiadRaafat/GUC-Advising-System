<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreditHourRequest.aspx.cs" Inherits="Advising_System.Studentcredithoursrequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Erga3" Text="Back" /><br />
            <br />
            <br />
            Please fill in the details.<br />
            Credit Hours:<br />
            <asp:TextBox ID="ch" runat="server"></asp:TextBox>
            <br />
            Request type:<br />
            <asp:TextBox ID="type" runat="server"></asp:TextBox>
            <br />
            Comments:<br />
            <asp:TextBox ID="comment" runat="server"></asp:TextBox>
            <br />
            <br /><asp:Button ID="Button1" runat="server" OnClick="chreqfe3lan" Text="Send request" />
            <br />
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br />
        </div>
        <div>&nbsp;</div>
        <div>&nbsp;</div>
    </form>
</body>
</html>
