<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPhoneNumber.aspx.cs" Inherits="Advising_System.Studentphonenumber" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Phone Number</title>
     <link rel="stylesheet" type="text/css" href="Styles.css" />
<style>
        .border {
    width: 300px;
    margin: 0 auto;
    border: 1px solid #ccc; 
    padding: 15px;
    background-color: orange;
    text-align:center;

}
</style>
</head>
<body class="body2">
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="goBack" Text="Back" CssClass="button" style="position: fixed; top: 30px;  right: 50px;"/><br />
            <center><h1>Add Phone Number</h1></center>
            <br />
            <div class="border">
            Phone number:<br />
            <asp:TextBox ID="mobile" runat="server"></asp:TextBox>
            <br />
            <br /><asp:Button ID="addp" runat="server" OnClick="addPhone" Text="Add" CssClass="button"/>
                </div>
        </div>
    </form>
</body>
</html>
