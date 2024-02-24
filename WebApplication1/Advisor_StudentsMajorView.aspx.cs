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
    public partial class Advisor_StduentsMajorView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ReturnToHome(object sender, EventArgs e)
        {
            Response.Redirect("Advisor_Home.aspx");
        }
        protected void viewPressed(object sender, EventArgs e)
        {
            String m = major.Text;
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            if (m == string.Empty)
            {
                Response.Write("<div class='error'>Please provide a major</div>");
            }
            else
            {
                SqlCommand checkmajor = new SqlCommand("Check_Major", conn);
                checkmajor.CommandType = CommandType.StoredProcedure;
                checkmajor.Parameters.Add(new SqlParameter("@major", m));
                SqlParameter exists = new SqlParameter("@exists", SqlDbType.Bit);
                exists.Direction = ParameterDirection.Output;
                checkmajor.Parameters.Add(exists);
                conn.Open();
                checkmajor.ExecuteNonQuery();
                conn.Close();
                if (!(Convert.ToBoolean(exists.Value)))
                {
                    Response.Write("<div class='error'>This major doesn't exist.</div>");
                }
                else
                {
                    SqlCommand viewproc = new SqlCommand("Procedures_AdvisorViewAssignedStudents", conn);
                    viewproc.CommandType = CommandType.StoredProcedure;
                    viewproc.Parameters.Add(new SqlParameter("@AdvisorID", Session["user"]));
                    viewproc.Parameters.Add(new SqlParameter("@major", m));
                    conn.Open();
                    SqlDataReader rdr = viewproc.ExecuteReader(CommandBehavior.CloseConnection);
                    Table studentTable = new Table();
                    studentTable.CssClass = "tableStyle"; // Apply a CSS class for styling

                    // Create a header row
                    TableRow headerRow = new TableRow();

                    // Create a new table cell for Student.student_id
                    TableCell studentIdHeaderCell = new TableCell();
                    studentIdHeaderCell.Text = "Student ID";
                    headerRow.Cells.Add(studentIdHeaderCell);

                    // Create a new table cell for Student.name
                    TableCell studentNameHeaderCell = new TableCell();
                    studentNameHeaderCell.Text = "Student Name";
                    headerRow.Cells.Add(studentNameHeaderCell);

                    // Create a new table cell for Course.name
                    TableCell courseNameHeaderCell = new TableCell();
                    courseNameHeaderCell.Text = "Course Name";
                    headerRow.Cells.Add(courseNameHeaderCell);
                    // Add the header row to the table
                    studentTable.Rows.Add(headerRow);

                    while (rdr.Read())
                    {
                        // Create a new table row
                        TableRow row = new TableRow();
                        row.CssClass = "tableRowStyle";

                        // Create a new table cell for the student ID
                        TableCell idCell = new TableCell();
                        idCell.Text = rdr.GetInt32(rdr.GetOrdinal("student_id")).ToString();
                        row.Cells.Add(idCell);

                        // Create a new table cell for the student name
                        TableCell nameCell = new TableCell();
                        nameCell.Text = rdr.GetString(rdr.GetOrdinal("Student_name"));
                        row.Cells.Add(nameCell);

                        // Create a new table cell for the course
                        TableCell courseCell = new TableCell();
                        courseCell.Text = rdr.GetString(rdr.GetOrdinal("Course_name"));
                        row.Cells.Add(courseCell);

                        // Add the row to the table
                        studentTable.Rows.Add(row);
                    }
                    // Add the table to the form
                    form1.Controls.Add(studentTable);

                }
            }
        }
    }
}