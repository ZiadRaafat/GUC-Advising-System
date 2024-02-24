using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
   
public partial class Test : System.Web.UI.Page
    {
        protected void Submit(object sender, EventArgs e)
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

                    using (SqlCommand cmd = new SqlCommand("SELECT dbo.FN_StudentUpcoming_installment(@student_ID)", connection))
                    {
                        cmd.Parameters.Add(new SqlParameter("@student_ID", SqlDbType.Int) { Value = studentID });

                        // Execute the SELECT statement
                        object result = cmd.ExecuteScalar();

                        // Check the result
                        if (result != null && result != DBNull.Value)
                        {
                            DateTime upcomingInstallmentDeadline = (DateTime)result;

                            // Now, you can use the upcomingInstallmentDeadline as needed.
                            // For example, display it in a label.
                            stds.Text = $"Upcoming Installment Deadline: {upcomingInstallmentDeadline.ToString()}";
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



}