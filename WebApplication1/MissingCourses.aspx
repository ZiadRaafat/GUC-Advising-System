<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MissingCourses.aspx.cs" Inherits="Advising_System.MissingCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Missing Courses</title>
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
            <asp:Button ID="Button1" runat="server" OnClick="goBack" Text="Back" CssClass="button" style="position: fixed; top: 30px;  right: 50px;"/><br />
            <br />
            <center><h1>Viewing Missing Courses</h1></center>
            <br />
            <div class="DivCenter">
            <center><asp:Button ID="B" runat="server" OnClick="avaic" Text="Click to view" CssClass="button"/>
            <br />
            <asp:GridView ID="G1" runat="server" AutoGenerateColumns="False"><Columns>
            <asp:BoundField DataField="name" HeaderText="Course Name" />
            <asp:BoundField DataField="course_id" HeaderText="Course ID" />
            </Columns> </asp:GridView >
            <br />
            <p style="color:white">(If there's no table displayed, then you don't have any missing courses.)</p>
               
                </center>
                </div>
        </div>
    </form>
</body>
</html>
