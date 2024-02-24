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

namespace Advising_System
{
    public partial class General : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void change(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand viewCourse = new SqlCommand("SELECT * FROM  Courses_MakeupExams", conn))
                {
                    viewCourse.CommandType = System.Data.CommandType.Text;

                    conn.Open();

                    using (SqlDataReader rdr = viewCourse.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        Label lblHeader = new Label();
                        lblHeader.Text = "Showing Courses along with their exam details";
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
                        close.CssClass = "closeButton";
                        divButtons.Controls.Add(close);
                    }
                }
            }

        }

        protected void change1(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand viewpreCourse = new SqlCommand("SELECT * FROM view_Course_prerequisites", conn))
                {
                    viewpreCourse.CommandType = System.Data.CommandType.Text;

                    conn.Open();

                    using (SqlDataReader rdr = viewpreCourse.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        Label lblHeader = new Label();
                        lblHeader.Text = "Showing courses along with their prerequisites";
                        lblHeader.CssClass = "headerLabel";
                        lblHeader.Style.Add("font-weight", "bold");
                        form1.Controls.Add(lblHeader);

                        Table preqTable = new Table();
                        preqTable.CssClass = "tableStyle";

                        TableRow headerRow = new TableRow();

                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            TableCell headerCell = new TableCell();
                            headerCell.Text = rdr.GetName(i);
                            headerRow.Cells.Add(headerCell);
                        }

                        preqTable.Rows.Add(headerRow);

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

                            preqTable.Rows.Add(row);
                        }

                        form1.Controls.Add(preqTable);

                        HtmlGenericControl divButtons = new HtmlGenericControl("div");
                        divButtons.Style.Add("text-align", "center");

                        
                        form1.Controls.Add(divButtons);

                        Button close = new Button();
                        close.Text = "Close Table";
                        close.CssClass = "closeButton";
                        divButtons.Controls.Add(close);
                    }
                }
            }

        }

        protected void change2(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand viewINSTSLOT = new SqlCommand("SELECT * FROM Courses_Slots_Instructor", conn))
                {
                    viewINSTSLOT.CommandType = System.Data.CommandType.Text;

                    conn.Open();

                    using (SqlDataReader rdr = viewINSTSLOT.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        Label lblHeader = new Label();
                        lblHeader.Text = "Showing available slots with their instructors";
                        lblHeader.CssClass = "headerLabel";
                        lblHeader.Style.Add("font-weight", "bold");
                        form1.Controls.Add(lblHeader);

                        Table slotTable = new Table();
                        slotTable.CssClass = "tableStyle";

                        TableRow headerRow = new TableRow();

                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            TableCell headerCell = new TableCell();
                            headerCell.Text = rdr.GetName(i);
                            headerRow.Cells.Add(headerCell);
                        }

                        slotTable.Rows.Add(headerRow);

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

                            slotTable.Rows.Add(row);
                        }

                        form1.Controls.Add(slotTable);

                        HtmlGenericControl divButtons = new HtmlGenericControl("div");
                        divButtons.Style.Add("text-align", "center");

                        
                        form1.Controls.Add(divButtons);

                        Button close = new Button();
                        close.Text = "Close Table";
                        close.CssClass = "closeButton";
                        divButtons.Controls.Add(close);
                    }
                }
            }

        }

      

      

        protected void makeup11(object sender, EventArgs e)
        {

        }

      

        protected void Unnamed2_Click(object sender, EventArgs e)
        {

        }

       

       

        protected void modifyrecords(object sender, EventArgs e)
        {
            Response.Redirect("General2.aspx");
        }
    }
    }
