using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AdminModify2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Return2(object sender, EventArgs e)
        {
            Response.Redirect("AdminPart2.aspx");

        }


        protected void deleteslotfe3lan(object sender, EventArgs e)
        {
            try
            {
                string r = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection c = new SqlConnection(r);
                c.Open();
                String csem = cs.Text;

                if (string.IsNullOrWhiteSpace(csem))
                {
                    Response.Write("Please fill in all the required fields.");
                    return;
                }


                SqlCommand dlt = new SqlCommand("Procedures_AdminDeleteSlots", c);
                dlt.Parameters.Add(new SqlParameter("@current_semester", csem));
                dlt.CommandType = System.Data.CommandType.StoredProcedure;


                dlt.ExecuteNonQuery();
                c.Close();
            }

            catch (Exception ex)
            {
                Label2.Text = ("Enter a valid semester code");

            }

            Response.Write("You have sent a request successfully.");


        }


        protected void issueinsfe3lan(object sender, EventArgs e)
        {
            try
            {
                string r = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection c = new SqlConnection(r);
                c.Open();
                int payID;

                if (string.IsNullOrWhiteSpace(pid.Text))
                {
                    Label2.Text = "Please fill in all the required fields.";
                    return;
                }


                if (int.TryParse(pid.Text, out payID) == false)
                {
                    Label2.Text = ("Please enter a valid payment ID.");
                    return;

                }

                payID = Int16.Parse(pid.Text);


                SqlCommand issue = new SqlCommand("Procedures_AdminIssueInstallment", c);
                issue.Parameters.Add(new SqlParameter("@payment_id", payID));
                issue.CommandType = System.Data.CommandType.StoredProcedure;


                issue.ExecuteNonQuery();
                c.Close();
            }

            catch (Exception ex)
            {
                Label2.Text = ("Enter a valid payment ID.");

            }

            Response.Write("You have issued an installment successfully.");


        }

        ///////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////
        protected void examDate(object sender, EventArgs e)
        {


        }
        protected void AddExam(object sender, EventArgs e)
        {
            string course = courseID.Text;
            string t = type.Text;
            string d = date.Text;
            if (string.IsNullOrEmpty(d) || string.IsNullOrEmpty(d) || string.IsNullOrEmpty(d))
            {
                Response.Write("<div class='error'>Please enter all required information.</div>");
            }
            else if (DateTime.Parse(d) <= DateTime.Now)
            {
                Response.Write("<div class='error'>Please choose a valid date.</div>");
            }
            else
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand check = new SqlCommand("Check_Admin_Add_Exam", conn);
                check.CommandType = CommandType.StoredProcedure;
                check.Parameters.Add(new SqlParameter("@courseID", course));
                check.Parameters.Add(new SqlParameter("@date", d));
                check.Parameters.Add(new SqlParameter("@type", t));
                SqlParameter exists = new SqlParameter("@exists", SqlDbType.Bit);
                exists.Direction = ParameterDirection.Output;
                check.Parameters.Add(exists);
                SqlParameter recordExists = new SqlParameter("@recordExists", SqlDbType.Bit);
                recordExists.Direction = ParameterDirection.Output;
                check.Parameters.Add(recordExists);
                SqlParameter valid = new SqlParameter("@validType", SqlDbType.Bit);
                valid.Direction = ParameterDirection.Output;
                check.Parameters.Add(valid);
                conn.Open();
                check.ExecuteNonQuery();
                conn.Close();
                if (Convert.ToBoolean(recordExists.Value))
                {
                    Response.Write("<div class='error'>Exam already exists.</div>");
                }
                else if (!(Convert.ToBoolean(exists.Value)))
                {
                    Response.Write("<div class='error'>Course doesn't exist.</div>");
                }
                else if (!(Convert.ToBoolean(valid.Value)))
                {
                    Response.Write("<div class='error'>Type is invalid.</div>");
                }
                else
                {
                    SqlCommand addexam = new SqlCommand("Procedures_AdminAddExam", conn);
                    addexam.CommandType = CommandType.StoredProcedure;
                    addexam.Parameters.Add(new SqlParameter("@courseID", course));
                    addexam.Parameters.Add(new SqlParameter("@type", t));
                    addexam.Parameters.Add(new SqlParameter("@date", d));
                    conn.Open();
                    addexam.ExecuteNonQuery();
                    conn.Close();
                    Response.Write("<div class='success'>Successful Insert.</div>");
                }

            }

        }
        protected void UpdateStudent(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(studentID.Text))
            {
                Response.Write("<div class='error'>Please enter all required information.</div>");
            }
            else if (!int.TryParse(studentID.Text, out _))
            {
                Response.Write("<div class='error'>Please enter a number for the ID field.</div>");
            }
            else
            {
                int id = Int16.Parse(studentID.Text);
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand check = new SqlCommand("Check_Student", conn);
                check.CommandType = CommandType.StoredProcedure;
                check.Parameters.Add(new SqlParameter("@student_id", id));
                SqlParameter exists = new SqlParameter("@exists", SqlDbType.Bit);
                exists.Direction = ParameterDirection.Output;
                check.Parameters.Add(exists);
                conn.Open();
                check.ExecuteNonQuery();
                conn.Close();
                if (!(Convert.ToBoolean(exists.Value)))
                {
                    Response.Write("<div class='error'>Student doesn't exist.</div>");
                }
                else
                {
                    SqlCommand update = new SqlCommand("Procedure_AdminUpdateStudentStatus", conn);
                    update.CommandType = CommandType.StoredProcedure;
                    update.Parameters.Add(new SqlParameter("@student_id", id));
                    SqlParameter status = new SqlParameter("@status", SqlDbType.Bit);
                    status.Direction = ParameterDirection.Output;
                    update.Parameters.Add(status);
                    conn.Open();
                    update.ExecuteNonQuery();
                    conn.Close();
                    String res = Convert.ToString(status.Value);
                    if (res == "False")
                        Response.Write("<div class='error'>Student is Blocked</div>");
                    else
                        Response.Write("<div class='success'> Student is not Blocked </div>");
                }
            }

        }

        protected void move_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                string currentSemester = cid.Text;

                SqlCommand deleteCourses = new SqlCommand("Procedures_AdminDeleteCourse", conn);
                deleteCourses.CommandType = CommandType.StoredProcedure;
                deleteCourses.Parameters.Add(new SqlParameter("@courseID", currentSemester));

                conn.Open();
                var result = deleteCourses.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                {
                    results.Text = "The course ID you have inserted does not have a corresponding slot.";
                }
                else
                {
                    results.Text = "Procedure executed successfully!";
                }
                conn.Close();


            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }
        }
    }
