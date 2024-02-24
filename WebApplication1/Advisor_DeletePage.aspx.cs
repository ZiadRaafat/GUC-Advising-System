using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Advisor_DeletePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ReturnToHome(object sender, EventArgs e)
        {
            Response.Redirect("Advisor_Home.aspx");
        }
        protected void deleteGradCourse(object sender, EventArgs e)
        {
            string code = sem.Text;
            if (string.IsNullOrEmpty(course.Text) || string.IsNullOrEmpty(stud_id.Text) || string.IsNullOrEmpty(code))
            {
                Response.Write("<div class='error'>Please enter all required information.</div>");
            }
            else if (!int.TryParse(stud_id.Text, out _) || !int.TryParse(course.Text, out _))
            {
                Response.Write("<div class='error'>Please enter only numbers for the ID fields.</div>");
            }

            else
            {
                int id = Int16.Parse(stud_id.Text);
                int c = Int16.Parse(course.Text);
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand check = new SqlCommand("Check_GradPlan_Course", conn);
                check.CommandType = CommandType.StoredProcedure;
                check.Parameters.Add(new SqlParameter("@sem_code", code));
                check.Parameters.Add(new SqlParameter("@student_id", id));
                check.Parameters.Add(new SqlParameter("@courseID", c));
                check.Parameters.Add(new SqlParameter("@advisor_id", Session["user"]));
                SqlParameter exists = new SqlParameter("@exists", SqlDbType.Bit);
                exists.Direction = ParameterDirection.Output;
                check.Parameters.Add(exists);
                SqlParameter courseFound = new SqlParameter("@courseFound", SqlDbType.Bit);
                courseFound.Direction = ParameterDirection.Output;
                check.Parameters.Add(courseFound);
                conn.Open();
                check.ExecuteNonQuery();
                conn.Close();
                if (!(Convert.ToBoolean(exists.Value)))
                {
                    Response.Write("<div class='error'>The plan doesn't exist.</div>");
                }
                else if (!(Convert.ToBoolean(courseFound.Value)))
                {
                    Response.Write("<div class='error'>The course doesn't exist.</div>");
                }
                else
                {
                    SqlCommand deleteproc = new SqlCommand("Procedures_AdvisorDeleteFromGP", conn);
                    deleteproc.CommandType = CommandType.StoredProcedure;
                    deleteproc.Parameters.Add(new SqlParameter("@sem_code", code));
                    deleteproc.Parameters.Add(new SqlParameter("@studentID", id));
                    deleteproc.Parameters.Add(new SqlParameter("@courseID", c));
                    conn.Open();
                    deleteproc.ExecuteNonQuery();
                    conn.Close();
                    Response.Write("<div class='success'>Successful Deletion.</div>");
                }
            }
        }
    }
}