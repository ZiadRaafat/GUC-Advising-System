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

                SqlCommand loginproc = new SqlCommand("Procedures_ChooseInstructor", conn);
                loginproc.CommandType = CommandType.StoredProcedure;
                loginproc.Parameters.Add(new SqlParameter("@studentID", StID));
                loginproc.Parameters.Add(new SqlParameter("@instructorID", Instruc));
                loginproc.Parameters.Add(new SqlParameter("@courseID", CourseID));
                loginproc.Parameters.Add(new SqlParameter("@current_semester_code", SemesterCode));

                conn.Open();
                loginproc.ExecuteNonQuery();
                conn.Close();


                result.Text = "Procedure executed successfully!";

            }
            catch (Exception ex)
            {
                Response.Write("error" + ex.Message);
            }
        }

        protected void RETURN(object sender, EventArgs e)
        {
            Response.Redirect("General2.aspx");
        }
    }
}