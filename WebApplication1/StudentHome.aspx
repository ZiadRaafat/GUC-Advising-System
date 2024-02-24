<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentHome.aspx.cs" Inherits="Advising_System.Studenthome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
     <link rel="stylesheet" type="text/css" href="Styles.css" />
    <style>

.Texts{
    color:white
}
.headerCell {
    border-bottom: 1px solid black;
}

.tableStyle {
    opacity: 0;
    transform: translateY(20px);
    animation: fadeIn 0.5s ease forwards;
    border-collapse: collapse;
    width: 100%;
    background-color: rgba(169, 169, 169, 0.4);

}

.tableRowStyle {
    border: 1px solid #dddddd;
}

.tableStyle th,
.tableStyle td {
    border: 1px solid #dddddd;
    padding: 8px;
    text-align: left;
}

.tableStyle th {
    background-color: #f2f2f2;
}

.closeButton {
    margin-bottom: 10px; 
}

.button-container {
    text-align: center;
    margin-top: -2.5%; 
}

.button-container .button {
    margin: 0 10px;
}

.table-container {
    margin-top: 20px;
}
.small-buttons .button {
    padding: 8px 12px; 
    font-size: 12px;  
}
.headerLabel{
    background-color:white;
}
    </style>
</head>
<body class="body2">
    <form id="form1" runat="server">
        <div class="header">
           <center><h1>Welcome Student</h1></center>
            <br />
             <div class="button-container small-buttons">
            <asp:Button ID="Button1" runat="server" OnClick="ReqCou" Text="View Required Courses" CssClass="button" />
           
            <asp:Button ID="Button2" runat="server" OnClick="OptCou" Text="View Optional Courses" CssClass="button"/>
           
            <asp:Button ID="Button3" runat="server" OnClick="AvaiCou" Text="View Available Courses" CssClass="button"/>
           
            <asp:Button ID="Button4" runat="server" OnClick="MissCou" Text="View Missing Courses" CssClass="button"/>
           
            <asp:Button ID="Button5" runat="server" OnClick="CredHrReq" Text="Add Credit Hours Request" CssClass="button"/>
           
            <asp:Button ID="Button6" runat="server" OnClick="CouReq" Text="Add Course Request" CssClass="button"/>
          
            <asp:Button ID="Button7" runat="server" OnClick="Mahmool" Text="Add Phone Number" CssClass="button"/>
           
            <asp:Button ID="Button9" runat="server" OnClick="StudentTwo" Text="Next Page" CssClass="button"/>
            
            <asp:Button ID="Button8" runat="server" OnClick="Bye" Text="Log Out" CssClass="button"/>
                 </div>
        
           
           
        
        </div>
    </form>
</body>
</html>
