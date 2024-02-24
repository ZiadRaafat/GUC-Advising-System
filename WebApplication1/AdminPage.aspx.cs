using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void showalladvisors(object sender, EventArgs e)
        {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand listAdvisors = new SqlCommand("Procedures_AdminListAdvisors", conn))
                    {
                        listAdvisors.CommandType = System.Data.CommandType.StoredProcedure;

                        conn.Open();

                        using (SqlDataReader rdr = listAdvisors.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                        // Create a label to display the text
                        Label lblHeader = new Label();
                        lblHeader.Text = "Showing All Advisors";
                        lblHeader.CssClass = "headerLabel";
                        lblHeader.Style.Add("font-weight", "bold");
                        form1.Controls.Add(lblHeader);

                        // Create a table to display the advisor data
                        Table advisorTable = new Table();
                            advisorTable.CssClass = "tableStyle"; 

                            // Create a header row
                            TableRow headerRow = new TableRow();

                            // Create a header cell for the "ID" column
                            TableCell idHeaderCell = new TableCell();
                            idHeaderCell.Text = "ID";
                            headerRow.Cells.Add(idHeaderCell);

                            // Create a header cell for the "Name" column
                            TableCell nameHeaderCell = new TableCell();
                            nameHeaderCell.Text = "Name";
                            headerRow.Cells.Add(nameHeaderCell);

                            // Add the header row to the table
                            advisorTable.Rows.Add(headerRow);

                            while (rdr.Read())
                            {
                                // Create a new table row
                                TableRow row = new TableRow();
                                row.CssClass = "tableRowStyle"; 

                                // Create a new table cell for the advisor ID
                                TableCell idCell = new TableCell();
                                idCell.Text = rdr.GetInt32(rdr.GetOrdinal("advisor_id")).ToString();
                                row.Cells.Add(idCell);

                                // Create a new table cell for the advisor name
                                TableCell nameCell = new TableCell();
                                nameCell.Text = rdr.GetString(rdr.GetOrdinal("advisor_name"));
                                row.Cells.Add(nameCell);

                                // Add the row to the table
                                advisorTable.Rows.Add(row);
                            }

                            // Add the table to the form
                            form1.Controls.Add(advisorTable);

                        HtmlGenericControl divButtons = new HtmlGenericControl("div");
                        divButtons.Style.Add("text-align", "center");

                        // Add the container to the form
                        form1.Controls.Add(divButtons);

                        Button close = new Button();
                        close.Text = "Close Table";
                        close.CssClass = "button";
                        divButtons.Controls.Add(close);

                    }
                    }
                }
            }
        protected void StudentAdvisor(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand listSA = new SqlCommand("AdminListStudentsWithAdvisors", conn))
                {
                    listSA.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader rdr = listSA.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        // Create a label to display the text
                        Label lblHeader = new Label();
                        lblHeader.Text = "Showing Students with their Advisor";
                        lblHeader.CssClass = "headerLabel";
                        lblHeader.Style.Add("font-weight", "bold");
                        form1.Controls.Add(lblHeader);

                        // Create a table to display the advisor data
                        Table advisorTable = new Table();
                        advisorTable.CssClass = "tableStyle"; 

                        // Create a header row
                        TableRow headerRow = new TableRow();

                        // Create a header cell for the "Student ID" column
                        TableCell idHeaderCell = new TableCell();
                        idHeaderCell.Text = "Student ID";
                        headerRow.Cells.Add(idHeaderCell);

                        // Create a header cell for the "Student First Name" column
                        TableCell nameHeaderCell = new TableCell();
                        nameHeaderCell.Text = "Student First Name";
                        headerRow.Cells.Add(nameHeaderCell);

                        // Create a header cell for the "Student Last Name" column
                        TableCell nameHeaderCell2 = new TableCell();
                        nameHeaderCell2.Text = "Student Last Name";
                        headerRow.Cells.Add(nameHeaderCell2);

                        // Create a header cell for the "Advisor ID" column
                        TableCell idHeaderCell2 = new TableCell();
                        idHeaderCell2.Text = "Advisor ID";
                        headerRow.Cells.Add(idHeaderCell2);

                        // Create a header cell for the "Advisor Name" column
                        TableCell nameHeaderCell3 = new TableCell();
                        nameHeaderCell3.Text = "Advisor Name";
                        headerRow.Cells.Add(nameHeaderCell3);

                        // Add the header row to the table
                        advisorTable.Rows.Add(headerRow);

                        while (rdr.Read())
                        {
                            // Create a new table row
                            TableRow row = new TableRow();
                            row.CssClass = "tableRowStyle"; 

                            // Create a new table cell for the Student ID
                            TableCell idCell = new TableCell();
                            idCell.Text = rdr.GetInt32(rdr.GetOrdinal("student_id")).ToString();
                            row.Cells.Add(idCell);

                            // Create a new table cell for the Student First Name
                            TableCell nameCell = new TableCell();
                            nameCell.Text = rdr.GetString(rdr.GetOrdinal("f_name"));
                            row.Cells.Add(nameCell);

                            // Create a new table cell for the Student Last Name
                            TableCell nameCell2 = new TableCell();
                            nameCell2.Text = rdr.GetString(rdr.GetOrdinal("l_name"));
                            row.Cells.Add(nameCell2);

                            // Create a new table cell for the Advisor ID
                            TableCell idCell2 = new TableCell();
                            idCell2.Text = rdr.GetInt32(rdr.GetOrdinal("advisor_id")).ToString();
                            row.Cells.Add(idCell2);

                            // Create a new table cell for the Advisor Name
                            TableCell nameCell3 = new TableCell();
                            nameCell3.Text = rdr.GetString(rdr.GetOrdinal("advisor_name"));
                            row.Cells.Add(nameCell3);

                            // Add the row to the table
                            advisorTable.Rows.Add(row);
                        }

                        // Add the table to the form
                        form1.Controls.Add(advisorTable);

                        HtmlGenericControl divButtons = new HtmlGenericControl("div");
                        divButtons.Style.Add("text-align", "center");

                       
                        form1.Controls.Add(divButtons);

                        Button close = new Button();
                        close.Text = "Close Table";
                        close.CssClass = "button";
                        divButtons.Controls.Add(close);

                    }
                }
            }
        }
        protected void ListPendingRequest(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand viewRequests = new SqlCommand("SELECT * FROM all_Pending_Requests", conn))
                {
                    viewRequests.CommandType = System.Data.CommandType.Text;

                    conn.Open();

                    using (SqlDataReader rdr = viewRequests.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        Label lblHeader = new Label();
                        lblHeader.Text = "Showing Pending Requests";
                        lblHeader.CssClass = "headerLabel";
                        lblHeader.Style.Add("font-weight", "bold");
                        form1.Controls.Add(lblHeader);

                        Table requestTable = new Table();
                        requestTable.CssClass = "tableStyle"; 

                        TableRow headerRow = new TableRow();

                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            TableCell headerCell = new TableCell();
                            headerCell.Text = rdr.GetName(i);
                            headerRow.Cells.Add(headerCell);
                        }

                        requestTable.Rows.Add(headerRow);

                        while (rdr.Read())
                        {
                            TableRow row = new TableRow();
                            row.CssClass = "tableRowStyle"; 

                            for (int i = 0; i < rdr.FieldCount; i++)
                            {
                                TableCell cell = new TableCell();
                                cell.Text = (rdr.IsDBNull(i) ? "null" : rdr[i].ToString());
                                row.Cells.Add(cell);
                            }

                            requestTable.Rows.Add(row);
                        }

                        form1.Controls.Add(requestTable);

                        HtmlGenericControl divButtons = new HtmlGenericControl("div");
                        divButtons.Style.Add("text-align", "center");

                        
                        form1.Controls.Add(divButtons);

                        Button close = new Button();
                        close.Text = "Close Table";
                        close.CssClass = "button";
                        divButtons.Controls.Add(close);
                    }
                }
            }
        }
        protected void InstructorsAssignedCourses(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand viewInstructorCourse = new SqlCommand("SELECT * FROM Instructors_AssignedCourses", conn))
                {
                    viewInstructorCourse.CommandType = System.Data.CommandType.Text;

                    conn.Open();

                    using (SqlDataReader rdr = viewInstructorCourse.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        // Create a label to display the text
                        Label lblHeader = new Label();
                        lblHeader.Text = "Showing Instructors and their Assigned Courses";
                        lblHeader.CssClass = "headerLabel";
                        lblHeader.Style.Add("font-weight", "bold");
                        form1.Controls.Add(lblHeader);

                      
                        Table requestTable = new Table();
                        requestTable.CssClass = "tableStyle"; 

                        // Create a header row
                        TableRow headerRow = new TableRow();

                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            TableCell headerCell = new TableCell();
                            headerCell.Text = rdr.GetName(i);
                            headerRow.Cells.Add(headerCell);
                        }

                        // Add the header row to the table
                        requestTable.Rows.Add(headerRow);

                        while (rdr.Read())
                        {
                            // Create a new table row
                            TableRow row = new TableRow();
                            row.CssClass = "tableRowStyle"; 

                            for (int i = 0; i < rdr.FieldCount; i++)
                            {
                                TableCell cell = new TableCell();
                                cell.Text = rdr[i].ToString();
                                row.Cells.Add(cell);
                            }

                            // Add the row to the table
                            requestTable.Rows.Add(row);
                        }

                        // Add the table to the form
                        form1.Controls.Add(requestTable);

                        HtmlGenericControl divButtons = new HtmlGenericControl("div");
                        divButtons.Style.Add("text-align", "center");

                       
                        form1.Controls.Add(divButtons);

                        Button close = new Button();
                        close.Text = "Close Table";
                        close.CssClass = "button";
                        divButtons.Controls.Add(close);
                    }
                }
            }
        }
        protected void SemesterOfferedCourses(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand viewSemOff = new SqlCommand("SELECT * FROM Semster_offered_Courses", conn))
                {
                    viewSemOff.CommandType = System.Data.CommandType.Text;

                    conn.Open();

                    using (SqlDataReader rdr = viewSemOff.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        // Create a label to display the text
                        Label lblHeader = new Label();
                        lblHeader.Text = "Showing Semesters and their Offered Courses";
                        lblHeader.CssClass = "headerLabel";
                        lblHeader.Style.Add("font-weight", "bold");
                        form1.Controls.Add(lblHeader);

                       
                        Table requestTable = new Table();
                        requestTable.CssClass = "tableStyle"; 

                        // Create a header row
                        TableRow headerRow = new TableRow();

                      
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            TableCell headerCell = new TableCell();
                            headerCell.Text = rdr.GetName(i);
                            headerRow.Cells.Add(headerCell);
                        }

                        // Add the header row to the table
                        requestTable.Rows.Add(headerRow);

                        while (rdr.Read())
                        {
                            // Create a new table row
                            TableRow row = new TableRow();
                            row.CssClass = "tableRowStyle"; 

                            for (int i = 0; i < rdr.FieldCount; i++)
                            {
                                TableCell cell = new TableCell();
                                cell.Text = (rdr.IsDBNull(i) ? "null" : rdr[i].ToString());
                                row.Cells.Add(cell);
                            }

                            // Add the row to the table
                            requestTable.Rows.Add(row);
                        }

                        // Add the table to the form
                        form1.Controls.Add(requestTable);

                        HtmlGenericControl divButtons = new HtmlGenericControl("div");
                        divButtons.Style.Add("text-align", "center");

                       
                        form1.Controls.Add(divButtons);

                        Button close = new Button();
                        close.Text = "Close Table";
                        close.CssClass = "button";
                        divButtons.Controls.Add(close);
                    }
                }
            }
        }
        protected void Modify_Records(object sender, EventArgs e)
        {
            Response.Redirect("AdminModify.aspx");
        }
        protected void Logout(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Login.aspx");
        }

        protected void AdminPart2(object sender, EventArgs e)
        {
            Response.Redirect("AdminPart2.aspx");
        }

        



    }
}































































//7978