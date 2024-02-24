using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Admin_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginpressed(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String id =username.Text;
            String pass = password.Text;

            if (id.Equals("1") && pass.Equals("admin123"))
            {
                Response.Redirect("AdminPage.aspx");
            }
            else
            {
                string errorLabel = "<div class='errorText'>Invalid Credentials</div>";
                Response.Write(errorLabel);            
            }
        }

        protected void ReturnMP(object sender, EventArgs e)
        {
            Response.Redirect("WelcomePage.aspx");
        }
    }
}




























//7978