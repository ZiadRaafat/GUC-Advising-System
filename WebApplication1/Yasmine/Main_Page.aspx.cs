using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WelcomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AdminPage(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Login.aspx");
        }
        protected void AdvisorPage(object sender, EventArgs e)
        {
            Response.Redirect("Advisor_Login.aspx");
        }
        protected void StudentPage(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Login.aspx");
        }
    }
}