<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MissingCourses.aspx.cs" Inherits="Advising_System.MissingCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Erga3" Text="Back" /><br />
            <br />
            <br />
            <asp:Button ID="B" runat="server" OnClick="avaic" Text="Click to view" />
            <br />
            <asp:GridView ID="G1" runat="server" AutoGenerateColumns="False"><Columns>
            <asp:BoundField DataField="name" HeaderText="Course Name" />
            <asp:BoundField DataField="course_id" HeaderText="Course ID" />
            </Columns> </asp:GridView >
            <br />
            (If there's no table displayed, then you don't have any missing courses.)
        </div>
    </form>
</body>
</html>
