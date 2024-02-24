using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

      

        protected void loginfe3lan(object sender, EventArgs e)
        {


            string c = WebConfigurationManager.ConnectionStrings["Advising_System1"].ToString();

            using (SqlConnection connect = new SqlConnection(c))
            {
                int sIDfe3lan;
                string ID = studid.Text;
                string pass = password.Text;
                if (string.IsNullOrWhiteSpace(ID) || string.IsNullOrWhiteSpace(pass) )
                {
                    Label2.Text = "Please fill in all the required fields.";
                    return;

                }
                   
                
                
                if (int.TryParse(studid.Text, out sIDfe3lan) == false)
                {
                    Label2.Text = ("Please enter a valid ID number. ");
                    return;

                }

                sIDfe3lan = Int16.Parse(studid.Text);
                


                connect.Open();

                using (var command = connect.CreateCommand())
                {
                    command.CommandText = "SELECT dbo.FN_StudentLogin(@Student_id, @password) AS flag";

                    command.Parameters.AddWithValue("@Student_id", ID);
                    command.Parameters.AddWithValue("@password", pass);

                    int success = 0;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            success = Convert.ToInt16(reader["flag"]);
                        }
                    }

                    if (success == 1)
                    {
                        HttpCookie ContID = new HttpCookie("userID", ID);
                        Response.Cookies.Add(ContID);
                        Response.Redirect("StudentHome.aspx");
                    }
                    if (success == 0)
                    {

                        Label2.Text = ("Please enter a valid username and password. ");
                    }


                }
            }
        }

        protected void reg(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}