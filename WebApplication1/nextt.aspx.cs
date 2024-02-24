using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace Advising_System
{
    public partial class nextt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void nexting(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            if (std2.Text == "" || std.Text == "")
            {
                result0.Text = "Please fill all the boxes";
            }
            else
            {
                int courseID = Int16.Parse(std2.Text);
                int instructorID = Int16.Parse(std.Text);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.FN_StudentViewSlot(@courseID, @instructorID)", connection))
                    {
                        cmd.Parameters.Add(new SqlParameter("@courseID", courseID));
                        cmd.Parameters.Add(new SqlParameter("@instructorID", instructorID));

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable results = new DataTable();
                            adapter.Fill(results);

                            if (results.Rows.Count > 0)
                            {
                                foreach (DataRow row in results.Rows)
                                {
                                    int slotID = (int)row["slot_id"];
                                    string location = (string)row["location"];
                                    string time = (string)row["time"];
                                    string day = (string)row["day"];
                                    string courseName = (string)row["Course"];
                                    string instructorName = (string)row["instructor"];

                                    result0.Text += $"Slot ID: {slotID}, Location: {location}, Time: {time}, Day: {day}, Course Name: {courseName}, Instructor Name: {instructorName}<br />";
                                }
                            }
                            else
                            {
                                result0.Text = "No result returned.";
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
