<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminModify.aspx.cs" Inherits="WebApplication1.AdminModify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Modifying</title>
        <link rel="stylesheet" type="text/css" href="Styles.css" />
     <style>
        #border {
            width: 300px;
            margin: 0 auto;
            border: 1px solid #ccc; 
            padding: 15px;
            background-color: orange;

        }
        .radioContainer{
        margin-top: 10px;
        border: 1px solid #ccc;
        padding: 10px;
        background-color: rgba(255, 255, 255, 0.5);


        }
    </style>
</head>
<body class="body2">
    <form id="form1" runat="server">
        <div>
            <center>
                <div class="header">
                <h1>Modifying Records</h1>
                <br />
                <asp:Button ID="return" runat="server" OnClick="Return" Text="Return to Main Admin Page" CssClass="button" style="margin-right: 20px" />
            </div>
            </center>
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <div style="display: flex; justify-content: space-between;">
            <div style="width: 45%;">
                <div id="border">
                    <center>
                        <p>
                            <h4>Add a New Semester:</h4>
                        </p>
                        <p>
                            <asp:Label ID="startd" runat="server" AssociatedControlID="startDate">Start Date:</asp:Label>
                            <asp:TextBox ID="startDate" runat="server" type="date"></asp:TextBox>
                        </p>
                        <p>
                            <asp:Label ID="endd" runat="server" AssociatedControlID="endDate">End Date:</asp:Label>
                            <asp:TextBox ID="endDate" runat="server" type="date"></asp:TextBox>
                        </p>
                        <p>
                            Semester Code:
                            <asp:TextBox ID="semc" runat="server" placeholder="Example: 'W23' or 'S24R2'"></asp:TextBox>
                        </p>
                        <p>
                            <asp:Button ID="submit1" runat="server" Text="Submit" OnClick="submit1_Click" CssClass="button" />
                        </p>
                    </center>
                </div>
                <div id="border">
                    <center>
                        <p>
                            <h4>Add a New Course:</h4>
                        </p>
                        <p>
                            Major:
                            <asp:TextBox ID="major" runat="server"></asp:TextBox>
                        </p>
                        <p>
                            Semester:
                            <asp:TextBox ID="courseSemester" runat="server"></asp:TextBox>
                        </p>
                        <p>
                            Credit Hours:
                            <asp:TextBox ID="creditHours" runat="server"></asp:TextBox>
                        </p>
                        <p>
                            Course Name:
                            <asp:TextBox ID="courseName" runat="server"></asp:TextBox>
                        </p>
                        <p>
                            <div class="radioContainer">
                            Offered:
                            <asp:RadioButtonList ID="isOffered" runat="server">
                            <asp:ListItem Text="Yes" Value="1" />
                            <asp:ListItem Text="No" Value="0" />
                            </asp:RadioButtonList>
                            </div>
                        </p>
                        <p>
                            <asp:Button ID="submitCourse" runat="server" Text="Submit" OnClick="submitCourse_Click" CssClass="button" />
                        </p>
                    </center>
                </div>
            </div>
            <div style="width: 45%;">
                <div id="border">
                    <center>
                        <p>
                            <h4>Link Instructor to Course:</h4>
                        </p>
                        <p>
                            Instructor ID:
                            <asp:TextBox ID="instructorID" runat="server"></asp:TextBox>
                        </p>
                        <p>
                            Course ID:
                            <asp:TextBox ID="courseID" runat="server"></asp:TextBox>
                        </p>
                        <p>
                            Slot ID:
                            <asp:TextBox ID="slotID" runat="server"></asp:TextBox>
                        </p>
                        <p>
                            <asp:Button ID="linkInstructorToCourse" runat="server" Text="Submit" OnClick="linkInstructorToCourse_Click" CssClass="button"  />
                        </p>
                    </center>
                </div>
                <div id="border">
                    <center>
                        <p>
                            <h4>Link Student to Advisor:</h4>
                        </p>
                        <p>
                            Student ID:
                            <asp:TextBox ID="studentID" runat="server"></asp:TextBox>
                        </p>
                        <p>
                            Advisor ID:
                            <asp:TextBox ID="advisorID" runat="server"></asp:TextBox>
                        </p>
                        <p>
                            <asp:Button ID="linkStudentToAdvisor" runat="server" Text="Submit" OnClick="linkStudentToAdvisor_Click" CssClass="button" />
                        </p>
                    </center>
                </div>
            </div>
        </div>
        <div style="width: 45%;">
            <div id="border">
                <center>
                    <p>
                        <h4>Link Student to Course With an Instructor:</h4>
                    </p>
                    <p>
                        Instructor ID:
                        <asp:TextBox ID="studentToCourseInstructorID" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        Student ID:
                        <asp:TextBox ID="studentToCourseStudentID" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        Course ID:
                        <asp:TextBox ID="studentToCourseCourseID" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        Semester Code:
                        <asp:TextBox ID="studentToCourseSemesterCode" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Button ID="linkStudentToCourseWithInstructor" runat="server" Text="Submit" OnClick="linkStudentToCourseWithInstructor_Click" CssClass="button" />
                    </p>
                </center>
            </div>
        </div>
    </form>
</body>





</html>
































<%--7978--%>