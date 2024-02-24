using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Advisor_InsertPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ReturnToHome(object sender, EventArgs e)
        {
            Response.Redirect("Advisor_Home.aspx");
        }
        protected void insertGradPlan(object sender, EventArgs e)
        {
            string code = sem_code.Text;
            string expec_date = gradDate.Text;
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(expec_date) || string.IsNullOrEmpty(semester_hours.Text) || string.IsNullOrEmpty(studID.Text))
            {
                Response.Write("<div class='error'>Please enter all required information.</div>");
            }
            else if (!int.TryParse(studID.Text, out _) || !int.TryParse(semester_hours.Text, out _))
            {
                Response.Write("<div class='error'>Please enter only numbers for the ID and Hours fields.</div>");
            }
            else if (DateTime.Parse(expec_date) <= DateTime.Now)
            {
                Response.Write("<div class='error'>Please choose a valid date.</div>");
            }
            else
            {
                int id = Int16.Parse(studID.Text);
                int hours = Int16.Parse(semester_hours.Text);
                if (hours <= 0)
                {
                    Response.Write("<div class='error'>Please enter a positive number for the hours field.</div>");
                }
                else
                {
                    string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                    SqlConnection conn = new SqlConnection(connStr);
                    SqlCommand check = new SqlCommand("Check_Plan", conn);
                    check.CommandType = CommandType.StoredProcedure;
                    check.Parameters.Add(new SqlParameter("@Semester_code", code));
                    check.Parameters.Add(new SqlParameter("@student_id", id));
                    check.Parameters.Add(new SqlParameter("@advisorID", Session["user"]));
                    SqlParameter exists = new SqlParameter("@exists", SqlDbType.Bit);
                    exists.Direction = ParameterDirection.Output;
                    check.Parameters.Add(exists);
                    SqlParameter valid = new SqlParameter("@valid", SqlDbType.Bit);
                    valid.Direction = ParameterDirection.Output;
                    check.Parameters.Add(valid);
                    conn.Open();
                    check.ExecuteNonQuery();
                    conn.Close();
                    if (Convert.ToBoolean(exists.Value))
                    {
                        Response.Write("<div class='error'>The plan already exists.</div>");
                    }
                    else if (!(Convert.ToBoolean(valid.Value)))
                    {
                        Response.Write("<div class='error'>The semester code and/or student id don't exist.</div>");
                    }
                    else
                    {
                        SqlCommand insertproc = new SqlCommand("Procedures_AdvisorCreateGP", conn);
                        insertproc.CommandType = CommandType.StoredProcedure;
                        insertproc.Parameters.Add(new SqlParameter("@Semester_code", code));
                        insertproc.Parameters.Add(new SqlParameter("@expected_graduation_date", DateTime.Parse(expec_date)));
                        insertproc.Parameters.Add(new SqlParameter("@sem_credit_hours", hours));
                        insertproc.Parameters.Add(new SqlParameter("@advisor_id", Session["user"]));
                        insertproc.Parameters.Add(new SqlParameter("@student_id", id));
                        SqlParameter sucess = new SqlParameter("@sucess", SqlDbType.Bit);
                        sucess.Direction = ParameterDirection.Output;
                        insertproc.Parameters.Add(sucess);
                        conn.Open();
                        insertproc.ExecuteNonQuery();
                        conn.Close();
                        if(Convert.ToBoolean(sucess.Value))
                        Response.Write("<div class='success'>Successful Insert.</div>");
                        else
                        Response.Write("<div class='error'>Failed Insert due to Credit Hours constraint of minimum value 157.</div>");
                    }
                }
            }
        }
        protected void insertGradPlanCourse(object sender, EventArgs e)
        {
            string c = code.Text;
            string n = name.Text;
            if (string.IsNullOrEmpty(c) || string.IsNullOrEmpty(n) || string.IsNullOrEmpty(ID.Text))
            {
                Response.Write("<div class='error'>Please enter all required information.</div>");
            }
            else if (!int.TryParse(ID.Text, out _))
            {
                Response.Write("<div class='error'>Please enter a number for the ID field.</div>");
            }
            else
            {
                int id = Int16.Parse(ID.Text);
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand check = new SqlCommand("Check_Insert_GPCourse", conn);
                check.CommandType = CommandType.StoredProcedure;
                check.Parameters.Add(new SqlParameter("@Semester_code", c));
                check.Parameters.Add(new SqlParameter("@student_id", id));
                check.Parameters.Add(new SqlParameter("@course_name", n));
                check.Parameters.Add(new SqlParameter("@advisorID", Session["user"]));
                SqlParameter exists = new SqlParameter("@exists", SqlDbType.Bit);
                exists.Direction = ParameterDirection.Output;
                check.Parameters.Add(exists);
                SqlParameter courseFound = new SqlParameter("@courseFound", SqlDbType.Bit);
                courseFound.Direction = ParameterDirection.Output;
                check.Parameters.Add(courseFound);
                SqlParameter courseInPlan = new SqlParameter("@courseInPlan", SqlDbType.Bit);
                courseInPlan.Direction = ParameterDirection.Output;
                check.Parameters.Add(courseInPlan);
                conn.Open();
                check.ExecuteNonQuery();
                conn.Close();
                if (!(Convert.ToBoolean(exists.Value)))
                {
                    Response.Write("<div class='error'>The plan doesn't exist.</div>");
                }
                else if (Convert.ToBoolean(courseInPlan.Value))
                {
                    Response.Write("<div class='error'>The course is already in the plan.</div>");
                }
                else if (!(Convert.ToBoolean(courseFound.Value)))
                {
                    Response.Write("<div class='error'>The course is not found or doesn't match the student's major.</div>");
                }
                else
                {
                    SqlCommand insertproc = new SqlCommand("Procedures_AdvisorAddCourseGP", conn);
                    insertproc.CommandType = CommandType.StoredProcedure;
                    insertproc.Parameters.Add(new SqlParameter("@Semester_code", c));
                    insertproc.Parameters.Add(new SqlParameter("@course_name", n));
                    insertproc.Parameters.Add(new SqlParameter("@student_id", id));
                    conn.Open();
                    insertproc.ExecuteNonQuery();
                    conn.Close();
                    Response.Write("<div class='success'>Successful Insert.</div>");
                }
            }

        }
        protected void gradDate_TextChanged(object sender, EventArgs e)
        {

        }
    }
}   