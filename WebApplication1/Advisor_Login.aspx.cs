using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Advisor_Login : System.Web.UI.Page
    {
        protected void exitPressed(object sender, EventArgs e)
        {
            Response.Redirect("WelcomePage.aspx");
        }
        protected void loginPressed(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string pass = password.Text;
            if (string.IsNullOrEmpty(userID.Text) || string.IsNullOrEmpty(pass))
            {
                Response.Write("<div class='errorText'>Please enter all required information.</div>");
            }
            else if (!int.TryParse(userID.Text, out _))
            {
                Response.Write("<div class='errorText'>Please enter a number for the ID field.</div>");
            }
            else
            {
                int id = Int16.Parse(userID.Text);
                // Create a SqlCommand for the function
                SqlCommand loginfunc = new SqlCommand("SELECT dbo.FN_AdvisorLogin(@Advisor_ID, @password)", conn);

                // Add parameters and set values
                loginfunc.Parameters.Add(new SqlParameter("@Advisor_ID", id));
                loginfunc.Parameters.Add(new SqlParameter("@password", pass));

                conn.Open();
                // Execute the function and capture the return value
                bool success = (bool)loginfunc.ExecuteScalar();
                conn.Close();

                if (success)
                {
                    Session["user"] = id;
                    Response.Redirect("Advisor_Home.aspx");
                }
                else
                    Response.Write("<div class='errorText'>Invalid Credentials</div>");
            }
        }

        protected void registerPressed(object sender, EventArgs e)
        {
            Response.Redirect("Advisor_Registration.aspx");
        }
    }
}