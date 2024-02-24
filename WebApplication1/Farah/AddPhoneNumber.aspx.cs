using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class Studentphonenumber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void addphonefe3lan(object sender, EventArgs e)
        {
            try
            {
                string r = WebConfigurationManager.ConnectionStrings["Advising_System1"].ToString();
                SqlConnection c = new SqlConnection(r);
                c.Open();
                String phonenumber = mobile.Text;
                HttpCookie userIdCookie = Request.Cookies["userID"];
                int studid = Convert.ToInt32(userIdCookie.Value);
                if (string.IsNullOrWhiteSpace(phonenumber))
                {
                    Response.Write("Please fill in all the required fields.");
                    return; // Exit the method if any input is empty
                }


                SqlCommand AP = new SqlCommand("Procedures_StudentaddMobile", c);
                AP.Parameters.Add(new SqlParameter("@StudentID", studid));
                AP.Parameters.Add(new SqlParameter("@mobile_number", phonenumber));
                AP.CommandType = System.Data.CommandType.StoredProcedure;


                AP.ExecuteNonQuery();
                c.Close();

                String t = mobile.Text;
                Boolean flag = true;
                for (int i = 0; i < (mobile.Text).Length; i++)
                {

                    if (Int16.Parse("" + t[i]) == 0 || Int16.Parse("" + t[i]) == 1 || Int16.Parse("" + t[i]) == 2 || Int16.Parse("" + t[i]) == 3 ||
                        Int16.Parse("" + t[i]) == 4 || Int16.Parse("" + t[i]) == 5 || Int16.Parse("" + t[i]) == 6 || Int16.Parse("" + t[i]) == 7 ||
                        Int16.Parse("" + t[i]) == 8 || Int16.Parse("" + t[i]) == 9 || t[i] == '-')
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                        break;
                    }

                }

                if (flag == false)
                {
                    Response.Write("Please enter a valid phone number.");
                }
                else
                {
                    Response.Write("The phone number was added successfully.");
                }
            }
            catch(Exception ex)
            {
                Response.Write("Phone number is already saved.");
            }
        }

        protected void Erga3(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}