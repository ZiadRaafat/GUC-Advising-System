<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="General2.aspx.cs" Inherits="Advising_System.General2" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Modifying Records</title>
    <link rel="stylesheet" type="text/css" href="Styles.css" />
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
            padding: 20px;
        }

        #form1 {
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
        }

        #form1 div {
            margin-right: 10px;
            margin-bottom: 10px;
        }

        .button {
            padding: 10px 20px;
            font-size: 16px;
        }
        .header{
            height:25%;
        }
    </style>
</head>
<body class="body2">
    <form id="form1" runat="server">
        <br />
        <div class="header">
            <center><h1>Modifying Records</h1></center>
        
            <asp:Button ID="makeup" runat="server" OnClick="makeup1" Text="First Makeup" CssClass="button"></asp:Button>
        
            <asp:Button runat="server" OnClick="makeup2" Text="Second Makeup" CssClass="button"></asp:Button>
       
            <asp:Button runat="server" OnClick="IC" Text="Choose Instructor/Course" CssClass="button"></asp:Button>
        
            <asp:Button runat="server" OnClick="change3" Text="GradPlan / Course" CssClass="button"></asp:Button>
      
            <asp:Button runat="server" OnClick="instal" Text="Upcoming Installment" CssClass="button"></asp:Button>
       
            <asp:Button runat="server" OnClick="next" Text=" View Instructor / Course" CssClass="button"></asp:Button>
        
       
        
           <center><asp:Button ID ="RETURN" OnClick ="return1" runat="server" Text="Previous Page" CssClass="button"></asp:Button>&nbsp;</center> 
        </div>
    </form>
</body>
</html>
