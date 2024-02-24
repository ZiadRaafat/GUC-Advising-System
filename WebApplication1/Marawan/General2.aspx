<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="General2.aspx.cs" Inherits="Advising_System.General2" %>

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
              <asp:Button ID="makeup" runat="server" OnClick="makeup1" Text="First Makeup"></asp:Button>
        </div>
           <div>
       <asp:Button runat="server" OnClick="makeup2" Text="Second Makeup"></asp:Button>
   </div>
   <div>
       <asp:Button runat="server" OnClick="IC" Text="Choose Instructor/Course"></asp:Button>
   </div>
   <div>
      <asp:Button runat="server" OnClick="change3" Text="GradPlan / Course"></asp:Button>
   </div>
   <div>
       <asp:Button runat="server" OnClick="instal" Text="Upcoming Installment"></asp:Button>
   </div>
   <div>
       <asp:Button runat="server" OnClick="next" Text=" View Instructor / Course"></asp:Button>
   </div>
        <div>&nbsp;</div>
        <div>
            <asp:Button ID ="RETURN" OnClick ="return1" runat="server" Text="Previous Page"></asp:Button>&nbsp;</div>
    </form>
</body>
</html>
