<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="General.aspx.cs" Inherits="Advising_System.General" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        
        #form1 {
            display: flex;
            flex-wrap: wrap;
            justify-content: flex-start;
        }

        #form1 div {
            margin-right: 10px;
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="change" Text="Exams / Courses" />
        </div>
        <div>
            <asp:Button ID="Button3" runat="server" OnClick="change2" Text="Slots / Instructors" />
        </div>
        <div>
            <asp:Button ID="Button4" runat="server" OnClick="change1" Text="Course Prereq" /> 
        </div>



        <div>
            <asp:Button ID="Button2" runat="server" OnClick="modifyrecords" Text="Modify Records"></asp:Button>
        </div>
    </form>
</body>
</html>
