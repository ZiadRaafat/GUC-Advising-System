<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequiredCourses.aspx.cs" Inherits="Advising_System.Studentrequiredcourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Available Courses</title>
    <link rel="stylesheet" type="text/css" href="Styles.css" />
    <style>
                .DivCenter {
    text-align: center;
    padding: 20px;
    border: 1px solid #ccc;
    background-color: orange;
    border-radius: 8px;
}
    </style>
</head>
<body class="body2">
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Erga3" Text="Back" CssClass="button" style="position: fixed; top: 30px;  right: 50px;"/><br />
            <center>
            <h1>Viewing Available Courses</h1>
            <br />
            <br />
                <div class="DivCenter">
            <p style="color:white">Semester code: </p><br />
            <asp:TextBox ID="semcode" runat="server"></asp:TextBox>
            <br />
            <br /><asp:Button ID="code" runat="server" OnClick="avaic" Text="View" CssClass="button"/>
            <br />
            <asp:GridView ID="G1" runat="server" AutoGenerateColumns="False"><Columns>
            <asp:BoundField DataField="name" HeaderText="Course Name" />
            <asp:BoundField DataField="course_id" HeaderText="Course ID" />
            </Columns> </asp:GridView >
            <br />
            <p style="color:white">(If there's no table displayed, then you don't have any required courses.) </p>
               </div>
                    </center>
        </div>
    </form>
</body>
</html>
