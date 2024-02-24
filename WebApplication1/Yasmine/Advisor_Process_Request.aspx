<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Advisor_Process_Request.aspx.cs" Inherits="WebApplication1.Advisor_Process_Request" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Process Requests</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body class="body-with-gradient">
    <form id="form1" runat="server">
    <asp:Button ID="home" runat="server" OnClick="ReturnHome" Text="Back to Home" CssClass="button1" style="position: fixed; top: 15px;  right: 50px; " />
      <div><center>
        <h2>Process Requests</h2>
      </center> </div>
    <div>
                <h4>Credit Hours Request:</h4>
            <p>
                Request ID:
                <asp:TextBox ID="request1" runat="server"></asp:TextBox>
            </p>
            <p>
                Semester Code:
                  <asp:TextBox ID="semesterCode1" runat="server"></asp:TextBox>
            </p>  
            <p>
                <asp:Button ID="creditHours" runat="server" Text="Submit" OnClick="submitCreditHours" CssClass="button1" />
            </p>
    </div>
    <div>
            <h4>Course Request:</h4>
        <p>
            Request ID:
            <asp:TextBox ID="request2" runat="server"></asp:TextBox>
        </p>
        <p>
            Semester Code:
              <asp:TextBox ID="semesterCode2" runat="server"></asp:TextBox>
        </p>  
        <p>
            <asp:Button ID="course" runat="server" Text="Submit" OnClick="submitCourse" CssClass="button1"/>
        </p>
</div>
    </form>
</body>
</html>
