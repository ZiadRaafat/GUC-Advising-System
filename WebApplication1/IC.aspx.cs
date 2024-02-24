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
    public partial class IC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void pro(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            try
            {
                int StID = Int16.Parse(std.Text);
                int Instruc = Int16.Parse(instid.Text);
                int CourseID = Int16.Parse(cid.Text);
                String SemesterCode = semc.Text;
                if (std.Text == "" || instid.Text == "" || cid.Text == "" || semc.Text == "")
                {
                    Response.Write("Please fill all the boxes");
                }
                else
                {

                    SqlCommand chooseInstructorProc = new SqlCommand("Procedures_Chooseinstructor", conn);
                    chooseInstructorProc.CommandType = CommandType.StoredProcedure;
                    chooseInstructorProc.Parameters.Add(new SqlParameter("@StudentID", StID));
                    chooseInstructorProc.Parameters.Add(new SqlParameter("@instrucorID", Instruc));
                    chooseInstructorProc.Parameters.Add(new SqlParameter("@CourseID", CourseID));
                    chooseInstructorProc.Parameters.Add(new SqlParameter("@current_semester_code", SemesterCode));

                    conn.Open();
                    chooseInstructorProc.ExecuteNonQuery();
                    conn.Close();

                    result.Text = "Procedure executed successfully!";
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void RETURN(object sender, EventArgs e)
        {
            Response.Redirect("General2.aspx");
        }
    }
}