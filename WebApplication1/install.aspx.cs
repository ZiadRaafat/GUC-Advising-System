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
    public partial class install : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void move_Click(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            if (std.Text == "")
            {
                Response.Write("Please fill all the boxes");
            }
            else
            {
                int studentID = Int16.Parse(std.Text);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT  dbo.FN_StudentUpcoming_installment(@student_ID)", connection))
                    {
                        cmd.Parameters.Add(new SqlParameter("@student_ID", studentID));

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            DateTime upcomingInstallmentDeadline = (DateTime)result;

                            results.Text = $"Upcoming Installment Deadline: {upcomingInstallmentDeadline.ToString()}";
                        }
                        else
                        {
                            results.Text = "No result returned.";
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
