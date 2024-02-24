<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OptionalCourses.aspx.cs" Inherits="Advising_System.Studentoptionalcourses" %>

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
            Semester code:<br />
            <asp:TextBox ID="semcode" runat="server"></asp:TextBox>
            <br />
            <br /><asp:Button ID="code" runat="server" OnClick="avaic" Text="View" />
            <br />
            <asp:GridView ID="G1" runat="server" AutoGenerateColumns="False"><Columns>
            <asp:BoundField DataField="name" HeaderText="Course Name" />
            <asp:BoundField DataField="course_id" HeaderText="Course ID" />
            </Columns> </asp:GridView >
            <br />
            (If there's no table displayed, then you don't have any optional courses.)
        </div>
    </form>
</body>
</html>
