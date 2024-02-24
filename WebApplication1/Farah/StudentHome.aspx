<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentHome.aspx.cs" Inherits="Advising_System.Studenthome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        header{
            position: center;
            top: 40px;

        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Welcome Student
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="ReqCou" Text="View Required Courses" />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="OptCou" Text="View Optional Courses" />
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="AvaiCou" Text="View Available Courses" />
            <br />
            <asp:Button ID="Button4" runat="server" OnClick="MissCou" Text="View Missing Courses" />
            <br />
            <asp:Button ID="Button5" runat="server" OnClick="CredHrReq" Text="Add Credit Hours Request" />
            <br />
            <asp:Button ID="Button6" runat="server" OnClick="CouReq" Text="Add Course Request" />
            <br />
            <asp:Button ID="Button7" runat="server" OnClick="Mahmool" Text="Add Phone Number" />
            <br /><br />
            <asp:Button ID="Button8" runat="server" OnClick="Bye" Text="Log Out" />
            <br />
        
        </div>
    </form>
</body>
</html>
