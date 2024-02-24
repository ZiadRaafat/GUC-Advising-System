<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="nextt.aspx.cs" Inherits="Advising_System.nextt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <div>

     <asp:Label ID="Label1" runat="server" Text="Instructor ID: "></asp:Label>


        <asp:TextBox ID="std" runat="server"></asp:TextBox>
     <br />
 </div>
     <asp:Label ID="Label2" runat="server" Text="Course ID: "></asp:Label> 
        <asp:TextBox ID="std2" runat="server"></asp:TextBox>

            <div> 
     <asp:Button ID="move" runat="server" Text="Enter" OnClick="nexting" />
                 
                &nbsp;</div>
    
            <div>  <asp:Label ID="result0" runat="server" Text=" "></asp:Label><asp:Button runat="server" OnClick ="RETURN" Text="Previous Page"></asp:Button></div>
            
        </div>
    </form>
</body>
</html>
