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
    public partial class Advisor_Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void exitPressed(object sender, EventArgs e)
        {
            Response.Redirect("WelcomePage.aspx");
        }
        protected void loginPressed(object sender, EventArgs e)
        {
            Response.Redirect("Advisor_Login.aspx");
        }
        protected void signupPressed(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string n = name.Text;
            string p = password.Text;
            string em = email.Text;
            string o = office.Text;
            if (string.IsNullOrEmpty(p) || string.IsNullOrEmpty(o) || string.IsNullOrEmpty(em) || string.IsNullOrEmpty(n))
            {
                // At least one of the TextBox values is empty
                Response.Write("<div class='errorText'>Please enter all required information.</div>");
            }
            else
            {
                SqlCommand checkExists = new SqlCommand("Check_Advisor_Exists", conn);
                checkExists.CommandType = CommandType.StoredProcedure;
                checkExists.Parameters.Add(new SqlParameter("@email", em));
                SqlParameter exists = new SqlParameter("@exists", SqlDbType.Bit);
                exists.Direction = ParameterDirection.Output;
                checkExists.Parameters.Add(exists);
                conn.Open();
                checkExists.ExecuteNonQuery();
                conn.Close();
                if ((Convert.ToBoolean(exists.Value)))
                {
                    Response.Write("<div class='errorText'>This user already exists.</div>");
                }
                else
                {
                    SqlCommand registerproc = new SqlCommand("Procedures_AdvisorRegistration", conn);
                    registerproc.CommandType = CommandType.StoredProcedure;
                    registerproc.Parameters.Add(new SqlParameter("@advisor_name", n));
                    registerproc.Parameters.Add(new SqlParameter("@password", p));
                    registerproc.Parameters.Add(new SqlParameter("@email", em));
                    registerproc.Parameters.Add(new SqlParameter("@office", o));
                    SqlParameter returnValue = new SqlParameter("@Advisor_id", SqlDbType.Int);
                    returnValue.Direction = ParameterDirection.Output;
                    registerproc.Parameters.Add(returnValue);
                    conn.Open();
                    registerproc.ExecuteNonQuery();
                    conn.Close();
                    //Session["user"] = (int)(registerproc.Parameters["@Advisor_id"].Value);
                    //Response.Redirect("Advisor_Home.aspx");
                    string s = "Your ID is " + returnValue.Value;
                    Response.Write("<div class='success'>" + s + "</div>");
                }

            }
                

            }
        }
    }