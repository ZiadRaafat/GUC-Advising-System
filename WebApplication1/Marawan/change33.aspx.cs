using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class change33 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void move(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            if (std.Text == "")
            {
                Response.Write("Please fill all the boxes");
            }
            else
            {
                int studentID = Int32.Parse(std.Text);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.FN_StudentViewGP(@student_ID)", connection))
                    {
                        cmd.Parameters.Add(new SqlParameter("@student_ID", SqlDbType.Int) { Value = studentID });

                        // fill the temp DataTable with the results from the function
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable results = new DataTable();
                            adapter.Fill(results);

                            //mandatory check (?)
                            if (results.Rows.Count > 0)
                            {
                                foreach (DataRow row in results.Rows)
                                {
                                    
                                    int studentId = (int)row["student_id"];
                                    string studentName = (string)row["student_name"];
                                    int planId = (int)row["plan_id"];
                                    int courseId = (int)row["course_id"];
                                    string courseName = (string)row["course_name"];
                                    string semesterCode = (string)row["semester_code"];
                                    DateTime expectedGradDate = (DateTime)row["expected_grad_date"];
                                    int semesterCreditHours = (int)row["semester_credit_hours"];
                                    int advisorId = (int)row["advisor_id"];

                                   
                                    stds.Text += $"Student ID: {studentId}, Student Name: {studentName}, Course ID: {courseId}, Course Name: {courseName}, etc.\n";
                                }
                            }
                            else
                            {
                                stds.Text = "No result returned.";
                            }
                        }
                    }
                }
            }
        }

        protected void RETURN(object sender, EventArgs e)
        {
            Response.Redirect("General2.aspx");
        }
    }
}