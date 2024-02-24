using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AdminPart2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void PreviousPage(object sender, EventArgs e)
        {
            Response.Redirect("AdminPage.aspx");

        }

        protected void GradPlan(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand viewSemOff = new SqlCommand("SELECT * FROM Advisors_Graduation_Plan", conn))
                {
                    viewSemOff.CommandType = System.Data.CommandType.Text;

                    conn.Open();

                    using (SqlDataReader rdr = viewSemOff.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        // Create a label to display the text
                        Label lblHeader = new Label();
                        lblHeader.Text = "Showing All Graduation Plans Along with their Advisors";
                        lblHeader.CssClass = "headerLabel";
                        lblHeader.Style.Add("font-weight", "bold");
                        form1.Controls.Add(lblHeader);

                        // Create a table to display the request data
                        Table requestTable = new Table();
                        requestTable.CssClass = "tableStyle"; // Apply a CSS class for styling

                        // Create a header row
                        TableRow headerRow = new TableRow();

                        // Create header cells dynamically
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
                            row.CssClass = "tableRowStyle"; // Apply a CSS class for styling

                            // Create cells for each column dynamically using ordinal indexing
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

                        // Add the container to the form
                        form1.Controls.Add(divButtons);

                        Button close = new Button();
                        close.Text = "Close Table";
                        close.CssClass = "closeButton";
                        divButtons.Controls.Add(close);
                    }
                }
            }
        }

        protected void TranscriptDetail(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand viewSemOff = new SqlCommand("SELECT * FROM Students_Courses_transcript", conn))
                {
                    viewSemOff.CommandType = System.Data.CommandType.Text;

                    conn.Open();

                    using (SqlDataReader rdr = viewSemOff.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        // Create a label to display the text
                        Label lblHeader = new Label();
                        lblHeader.Text = "Showing the Details of the Students' Transcripts";
                        lblHeader.CssClass = "headerLabel";
                        lblHeader.Style.Add("font-weight", "bold");
                        form1.Controls.Add(lblHeader);

                        // Create a table to display the request data
                        Table requestTable = new Table();
                        requestTable.CssClass = "tableStyle"; // Apply a CSS class for styling

                        // Create a header row
                        TableRow headerRow = new TableRow();

                        // Create header cells dynamically
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
                            row.CssClass = "tableRowStyle"; // Apply a CSS class for styling

                            // Create cells for each column dynamically using ordinal indexing
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

                        // Add the container to the form
                        form1.Controls.Add(divButtons);

                        Button close = new Button();
                        close.Text = "Close Table";
                        close.CssClass = "closeButton";
                        divButtons.Controls.Add(close);
                    }
                }
            }
        }

        protected void SemCourse(object sender, EventArgs e)
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
                        lblHeader.Text = "Showing Semesters Along with their Offered Courses";
                        lblHeader.CssClass = "headerLabel";
                        lblHeader.Style.Add("font-weight", "bold");
                        form1.Controls.Add(lblHeader);

                        // Create a table to display the request data
                        Table requestTable = new Table();
                        requestTable.CssClass = "tableStyle"; // Apply a CSS class for styling

                        // Create a header row
                        TableRow headerRow = new TableRow();

                        // Create header cells dynamically
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
                            row.CssClass = "tableRowStyle"; // Apply a CSS class for styling

                            // Create cells for each column dynamically using ordinal indexing
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

                        // Add the container to the form
                        form1.Controls.Add(divButtons);

                        Button close = new Button();
                        close.Text = "Close Table";
                        close.CssClass = "closeButton";
                        divButtons.Controls.Add(close);
                    }
                }
            }
        }
        protected void ActiveD(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand viewSemOff = new SqlCommand("SELECT * FROM view_Students", conn))
                {
                    viewSemOff.CommandType = System.Data.CommandType.Text;

                    conn.Open();

                    using (SqlDataReader rdr = viewSemOff.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        // Create a label to display the text
                        Label lblHeader = new Label();
                        lblHeader.Text = "Showing Details of All Active Students";
                        lblHeader.CssClass = "headerLabel";
                        lblHeader.Style.Add("font-weight", "bold");
                        form1.Controls.Add(lblHeader);

                        // Create a table to display the request data
                        Table requestTable = new Table();
                        requestTable.CssClass = "tableStyle"; // Apply a CSS class for styling

                        // Create a header row
                        TableRow headerRow = new TableRow();

                        // Create header cells dynamically
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
                            row.CssClass = "tableRowStyle"; // Apply a CSS class for styling

                            // Create cells for each column dynamically using ordinal indexing
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

                        // Add the container to the form
                        form1.Controls.Add(divButtons);

                        Button close = new Button();
                        close.Text = "Close Table";
                        close.CssClass = "closeButton";
                        divButtons.Controls.Add(close);
                    }
                }
            }
        }

        protected void PayD(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand viewSemOff = new SqlCommand("SELECT * FROM Student_Payment", conn))
                {
                    viewSemOff.CommandType = System.Data.CommandType.Text;

                    conn.Open();

                    using (SqlDataReader rdr = viewSemOff.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        // Create a label to display the text
                        Label lblHeader = new Label();
                        lblHeader.Text = "Showing Details of all Payments Along with their Corresponding Student";
                        lblHeader.CssClass = "headerLabel";
                        lblHeader.Style.Add("font-weight", "bold");
                        form1.Controls.Add(lblHeader);

                        // Create a table to display the request data
                        Table requestTable = new Table();
                        requestTable.CssClass = "tableStyle"; // Apply a CSS class for styling

                        // Create a header row
                        TableRow headerRow = new TableRow();

                        // Create header cells dynamically
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
                            row.CssClass = "tableRowStyle"; // Apply a CSS class for styling

                            // Create cells for each column dynamically using ordinal indexing
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

                        // Add the container to the form
                        form1.Controls.Add(divButtons);

                        Button close = new Button();
                        close.Text = "Close Table";
                        close.CssClass = "closeButton";
                        divButtons.Controls.Add(close);
                    }
                }
            }
        }

        protected void Modify2(object sender, EventArgs e)
        {
            Response.Redirect("AdminModify2.aspx");

        }
    }
}




































































//7978