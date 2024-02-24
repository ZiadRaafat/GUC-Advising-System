using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace WebApplication1
{
    public partial class student_red : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_Team_47"].ToString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    String First_Name = first_name.Text;
                    String Last_Name = last_name.Text;
                    String Password = pass.Text; // Password should be hashed before storing
                    String Faculty = fac.Text;
                    String Email = email.Text;
                    String Major = major.Text;
                    int Semester = Int16.Parse(Sem.Text);

                    SqlCommand registrationProc = new SqlCommand("Procedures_StudentRegistration", conn);
                    registrationProc.CommandType = CommandType.StoredProcedure;
                    registrationProc.Parameters.Add(new SqlParameter("@first_name", First_Name));
                    registrationProc.Parameters.Add(new SqlParameter("@last_name", Last_Name));
                    registrationProc.Parameters.Add(new SqlParameter("@password", Password));
                    registrationProc.Parameters.Add(new SqlParameter("@faculty", Faculty));
                    registrationProc.Parameters.Add(new SqlParameter("@email", Email));
                    registrationProc.Parameters.Add(new SqlParameter("@major", Major));
                    registrationProc.Parameters.Add(new SqlParameter("@semester", Semester));

                    SqlParameter registrationResult = registrationProc.Parameters.Add("@studentID", SqlDbType.Int);
                    registrationResult.Direction = ParameterDirection.Output;

                    registrationProc.ExecuteNonQuery();

                    if (registrationResult.Value.ToString() == "1")
                    {
                        Response.Write("Registration successful! Welcome!");
                    }
                    else
                    {
                        Response.Write("Failed to register.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle and log the exception
                Response.Write("An error occurred: " + ex.Message);
            }
        }
    }
}
