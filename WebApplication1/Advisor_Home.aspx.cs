using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication1
{
    public partial class Advisor_Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void ViewStudents(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand students = new SqlCommand("View_Advisor_Students", conn);
            students.Parameters.AddWithValue("@advisorID", Session["user"]);
            students.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader rdr = students.ExecuteReader(CommandBehavior.CloseConnection);

            // Create a table to display the advisor data
            Table studentTable = new Table();
            studentTable.CssClass = "tableStyle"; // Apply a CSS class for styling

            // Create a header row
            TableRow headerRow = new TableRow();

            //1
            TableCell idHeaderCell = new TableCell();
            idHeaderCell.Text = "ID";
            headerRow.Cells.Add(idHeaderCell);

            //2
            TableCell nameHeaderCell = new TableCell();
            nameHeaderCell.Text = "Name";
            headerRow.Cells.Add(nameHeaderCell);

            //3
            TableCell majorHeaderCell = new TableCell();
            majorHeaderCell.Text = "Major";
            headerRow.Cells.Add(majorHeaderCell);

            //4
            TableCell facultyHeaderCell = new TableCell();
            facultyHeaderCell.Text = "Faculty";
            headerRow.Cells.Add(facultyHeaderCell);

            //5
            TableCell semesterHeaderCell = new TableCell();
            semesterHeaderCell.Text = "Semester";
            headerRow.Cells.Add(semesterHeaderCell);

            // 6
            TableCell gpaHeaderCell = new TableCell();
            gpaHeaderCell.Text = "GPA";
            headerRow.Cells.Add(gpaHeaderCell);

            // 7
            TableCell emailHeaderCell = new TableCell();
            emailHeaderCell.Text = "Email";
            headerRow.Cells.Add(emailHeaderCell);

            // 8
            TableCell financialStatusHeaderCell = new TableCell();
            financialStatusHeaderCell.Text = "Financial Status";
            headerRow.Cells.Add(financialStatusHeaderCell);

            // 9
            TableCell acquiredHoursHeaderCell = new TableCell();
            acquiredHoursHeaderCell.Text = "Acquired Hours";
            headerRow.Cells.Add(acquiredHoursHeaderCell);

            // 10
            TableCell assignedHoursHeaderCell = new TableCell();
            assignedHoursHeaderCell.Text = "Assigned Hours";
            headerRow.Cells.Add(assignedHoursHeaderCell);


            // Add the header row to the table
            studentTable.Rows.Add(headerRow);

            while (rdr.Read())
            {
                // Create a new table row
                TableRow row = new TableRow();
                row.CssClass = "tableRowStyle"; // Apply a CSS class for styling

                // Create a new table cell for the student ID
                TableCell idCell = new TableCell();
                idCell.Text = rdr.GetInt32(rdr.GetOrdinal("student_id")).ToString();
                row.Cells.Add(idCell);

                // Create a new table cell for the student name
                TableCell nameCell = new TableCell();
                nameCell.Text = rdr.GetString(rdr.GetOrdinal("name"));
                row.Cells.Add(nameCell);

                // Create a new table cell for the major
                TableCell majorCell = new TableCell();
                majorCell.Text = rdr.GetString(rdr.GetOrdinal("major"));
                row.Cells.Add(majorCell);

                // Create a new table cell for the faculty
                TableCell facultyCell = new TableCell();
                facultyCell.Text = rdr.GetString(rdr.GetOrdinal("faculty"));
                row.Cells.Add(facultyCell);

                // Create a new table cell for the semester
                TableCell semesterCell = new TableCell();
                semesterCell.Text = rdr.GetInt32(rdr.GetOrdinal("semester")).ToString();
                row.Cells.Add(semesterCell);

                // Create a new table cell for the GPA
                TableCell gpaCell = new TableCell();
                gpaCell.Text = rdr.GetDecimal(rdr.GetOrdinal("gpa")).ToString();
                row.Cells.Add(gpaCell);

                // Create a new table cell for the email
                TableCell emailCell = new TableCell();
                emailCell.Text = rdr.GetString(rdr.GetOrdinal("email"));
                row.Cells.Add(emailCell);

                // Create a new table cell for the financial status
                TableCell financialStatusCell = new TableCell();
                financialStatusCell.Text = rdr.GetBoolean(rdr.GetOrdinal("financial_status")).ToString();
                row.Cells.Add(financialStatusCell);

                // Create a new table cell for the acquired hours
                TableCell acquiredHoursCell = new TableCell();
                acquiredHoursCell.Text = rdr.GetInt32(rdr.GetOrdinal("acquired_hours")).ToString();
                row.Cells.Add(acquiredHoursCell);

                // Create a new table cell for the assigned hours
                TableCell assignedHoursCell = new TableCell();
                assignedHoursCell.Text = rdr.GetInt32(rdr.GetOrdinal("assigned_hours")).ToString();
                row.Cells.Add(assignedHoursCell);

                // Add the row to the table
                studentTable.Rows.Add(row);
            }

            // Add the table to the form
            form1.Controls.Add(studentTable);

        }
        protected void ViewAllRequests(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand requests = new SqlCommand("SELECT * FROM FN_Advisors_Requests(@advisor_id)", conn);
            requests.Parameters.AddWithValue("@advisor_id", Session["user"]);

            conn.Open();
            SqlDataReader rdr = requests.ExecuteReader(CommandBehavior.CloseConnection);

            Table requestTable = new Table();
            requestTable.CssClass = "tableStyle"; // Apply a CSS class for styling

            // Create a header row
            TableRow headerRow = new TableRow();
            // Create a new table cell for request_id
            TableCell requestIdHeaderCell = new TableCell();
            requestIdHeaderCell.Text = "Request ID";
            headerRow.Cells.Add(requestIdHeaderCell);

            // Create a new table cell for type
            TableCell typeHeaderCell = new TableCell();
            typeHeaderCell.Text = "Type";
            headerRow.Cells.Add(typeHeaderCell);

            // Create a new table cell for comment
            TableCell commentHeaderCell = new TableCell();
            commentHeaderCell.Text = "Comment";
            headerRow.Cells.Add(commentHeaderCell);

            // Create a new table cell for status
            TableCell statusHeaderCell = new TableCell();
            statusHeaderCell.Text = "Status";
            headerRow.Cells.Add(statusHeaderCell);

            // Create a new table cell for credit_hours
            TableCell creditHoursHeaderCell = new TableCell();
            creditHoursHeaderCell.Text = "Credit Hours";
            headerRow.Cells.Add(creditHoursHeaderCell);

            // Create a new table cell for course_id
            TableCell courseIdHeaderCell = new TableCell();
            courseIdHeaderCell.Text = "Course ID";
            headerRow.Cells.Add(courseIdHeaderCell);

            // Create a new table cell for student_id
            TableCell studentIdHeaderCell = new TableCell();
            studentIdHeaderCell.Text = "Student ID";
            headerRow.Cells.Add(studentIdHeaderCell);

            requestTable.Rows.Add(headerRow);

            while (rdr.Read())
            {
                // Create a new table row
                TableRow row = new TableRow();
                row.CssClass = "tableRowStyle";
                // Create a new table cell for request_id
                TableCell requestIdCell = new TableCell();
                requestIdCell.Text = rdr.GetInt32(rdr.GetOrdinal("request_id")).ToString();
                row.Cells.Add(requestIdCell);

                // Create a new table cell for type
                TableCell typeCell = new TableCell();
                typeCell.Text = rdr.GetString(rdr.GetOrdinal("type"));
                row.Cells.Add(typeCell);

                // Create a new table cell for comment
                TableCell commentCell = new TableCell();
                commentCell.Text = rdr.GetString(rdr.GetOrdinal("comment"));
                row.Cells.Add(commentCell);

                // Create a new table cell for status
                TableCell statusCell = new TableCell();
                statusCell.Text = rdr.GetString(rdr.GetOrdinal("status"));
                row.Cells.Add(statusCell);

                // Create a new table cell for credit_hours
                TableCell creditHoursCell = new TableCell();
                creditHoursCell.Text = rdr.IsDBNull(rdr.GetOrdinal("credit_hours"))? "null" : rdr.GetInt32(rdr.GetOrdinal("credit_hours")).ToString() ;
                row.Cells.Add(creditHoursCell);

                // Create a new table cell for course_id
                TableCell courseIdCell = new TableCell();
                courseIdCell.Text = rdr.IsDBNull(rdr.GetOrdinal("course_id"))? "null" : rdr.GetInt32(rdr.GetOrdinal("course_id")).ToString();
                row.Cells.Add(courseIdCell);

                // Create a new table cell for student_id
                TableCell studentIdCell = new TableCell();
                studentIdCell.Text = rdr.GetInt32(rdr.GetOrdinal("student_id")).ToString();
                row.Cells.Add(studentIdCell);

                requestTable.Rows.Add(row);
            }
            form1.Controls.Add(requestTable);
        }
        protected void ViewPendingRequests(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand requests = new SqlCommand("Procedures_AdvisorViewPendingRequests", conn);
            requests.Parameters.AddWithValue("@Advisor_ID", Session["user"]);
            requests.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader rdr = requests.ExecuteReader(CommandBehavior.CloseConnection);

            Table requestTable = new Table();
            requestTable.CssClass = "tableStyle"; // Apply a CSS class for styling

            // Create a header row
            TableRow headerRow = new TableRow();
            // Create a new table cell for request_id
            TableCell requestIdHeaderCell = new TableCell();
            requestIdHeaderCell.Text = "Request ID";
            headerRow.Cells.Add(requestIdHeaderCell);

            // Create a new table cell for type
            TableCell typeHeaderCell = new TableCell();
            typeHeaderCell.Text = "Type";
            headerRow.Cells.Add(typeHeaderCell);

            // Create a new table cell for comment
            TableCell commentHeaderCell = new TableCell();
            commentHeaderCell.Text = "Comment";
            headerRow.Cells.Add(commentHeaderCell);

            // Create a new table cell for credit_hours
            TableCell creditHoursHeaderCell = new TableCell();
            creditHoursHeaderCell.Text = "Credit Hours";
            headerRow.Cells.Add(creditHoursHeaderCell);

            // Create a new table cell for course_id
            TableCell courseIdHeaderCell = new TableCell();
            courseIdHeaderCell.Text = "Course ID";
            headerRow.Cells.Add(courseIdHeaderCell);

            // Create a new table cell for student_id
            TableCell studentIdHeaderCell = new TableCell();
            studentIdHeaderCell.Text = "Student ID";
            headerRow.Cells.Add(studentIdHeaderCell);

            requestTable.Rows.Add(headerRow);

            while (rdr.Read())
            {
                // Create a new table row
                TableRow row = new TableRow();
                row.CssClass = "tableRowStyle";
                // Create a new table cell for request_id
                TableCell requestIdCell = new TableCell();
                requestIdCell.Text = rdr.GetInt32(rdr.GetOrdinal("request_id")).ToString();
                row.Cells.Add(requestIdCell);

                // Create a new table cell for type
                TableCell typeCell = new TableCell();
                typeCell.Text = rdr.GetString(rdr.GetOrdinal("type"));
                row.Cells.Add(typeCell);

                // Create a new table cell for comment
                TableCell commentCell = new TableCell();
                commentCell.Text = rdr.GetString(rdr.GetOrdinal("comment"));
                row.Cells.Add(commentCell);

                // Create a new table cell for credit_hours
                TableCell creditHoursCell = new TableCell();
                creditHoursCell.Text = rdr.IsDBNull(rdr.GetOrdinal("credit_hours")) ? "null" : rdr.GetInt32(rdr.GetOrdinal("credit_hours")).ToString();
                row.Cells.Add(creditHoursCell);

                // Create a new table cell for course_id
                TableCell courseIdCell = new TableCell();
                courseIdCell.Text = rdr.IsDBNull(rdr.GetOrdinal("course_id")) ? "null" : rdr.GetInt32(rdr.GetOrdinal("course_id")).ToString();
                row.Cells.Add(courseIdCell);

                // Create a new table cell for student_id
                TableCell studentIdCell = new TableCell();
                studentIdCell.Text = rdr.GetInt32(rdr.GetOrdinal("student_id")).ToString();
                row.Cells.Add(studentIdCell);

                requestTable.Rows.Add(row);
            }
            form1.Controls.Add(requestTable);

        }
        protected void ViewStudentsInMajor(object sender, EventArgs e)
        {
            Response.Redirect("Advisor_StudentsMajorView.aspx");
        }
        protected void ProcessRequests(object sender, EventArgs e)
        {
            Response.Redirect("Advisor_Process_Request.aspx");
        }
        protected void LogOut(object sender, EventArgs e)
        {
            Response.Redirect("Advisor_Login.aspx");
        }
        protected void ViewInsertOptions(object sender, EventArgs e)
        {
            Response.Redirect("Advisor_InsertPage.aspx");
        }
        protected void ViewUpdateOptions(object sender, EventArgs e)
        {
            Response.Redirect("Advisor_UpdatePage.aspx");
        }
        protected void ViewDeleteOptions(object sender, EventArgs e)
        {
            Response.Redirect("Advisor_DeletePage.aspx");
        }

    }
}