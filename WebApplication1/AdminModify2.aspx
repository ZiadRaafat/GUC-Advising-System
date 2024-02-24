<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminModify2.aspx.cs" Inherits="WebApplication1.AdminModify2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Modifying 2</title>
    <link rel="stylesheet" type="text/css" href="Styles.css" />
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
            padding: 20px;
        }

        .form-container {
            max-width: 800px;
            margin: 0 auto;
        }

        .heading {
            text-align: center;
        }

        .button-container {
            text-align: center;
            margin-top: 20px;
        }

        .row {
            display: flex;
            justify-content: space-between;
            margin-top: 20px;
        }

        .column {
            flex: 1;
            padding: 10px;
            background-color: #ffffff;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .column:nth-child(2) {
            margin: 0 20px;
        }

        .align-center {
            text-align: center;
        }
    </style>
</head>
<body class="body2">
    <form id="form1" runat="server">
        <div class="header">
        <div class="form-container">
            <center><h1 class="heading">Modifying Records</h1></center>
            </div>
            <div class="button-container">
                <asp:Button ID="return2" runat="server" OnClick="Return2" Text="Return to Admin Page 2" CssClass="button" />
            </div>

            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <center>

            <div class="row">
                <div class="column">
                    <div>
                        <strong>Delete Slot from a Semester: </strong>
                    </div>
                    <asp:TextBox ID="cs" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="Button2" runat="server" OnClick="deleteslotfe3lan" Text="Delete slot" CssClass="button" />
                    <br />
                    <br />
                    <br />
                   <center>  <strong>Issue Installment to a Student: </strong></center>
                    <asp:TextBox ID="pid" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="issueins" runat="server" OnClick="issueinsfe3lan" Text="Issue Installment" CssClass="button"/>
                </div>

                <div class="column">
                    <div>
                        <strong>Add Exam for Course:</strong>
                    </div>
                    <div>
                       ID: <asp:TextBox ID="courseID" runat="server"></asp:TextBox>
                    </div>
                    <div>
                       Type: <asp:TextBox ID="type" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        Date: <asp:TextBox ID="date" runat="server" type="date" OnTextChanged="examDate"></asp:TextBox>
                    </div>
                    <asp:Button ID="buttonAddExam" runat="server" OnClick="AddExam" Text="Add" CssClass="button"/>
                    <br />
                    <div>
                        <br />
                        <br />
                        <strong>Update Financial Status:</strong>
                    </div>
                    <asp:TextBox ID="studentID" runat="server"></asp:TextBox>
                    <asp:Button ID="buttonStudent" runat="server" OnClick="UpdateStudent" Text="Submit" CssClass="button"/>
                </div>

                <div class="column align-center">
                    <div>
                        <strong>Delete a Course:</strong>
                    </div>
                    <asp:Label ID="Label1" runat="server" Text="Please enter your Course ID:"></asp:Label>
                    <asp:TextBox ID ="cid" runat="server"></asp:TextBox>
                    <asp:Button ID="move" runat="server" Text="Enter" OnClick="move_Click" CssClass="button"></asp:Button>
                    <br />
                    <asp:Label runat="server" Text="Result : "></asp:Label>
                    <asp:Label ID ="results" runat="server" Text=" "></asp:Label>
                </div>
            </div>
                </center>
        </div>

    </form>
</body>
</html>
