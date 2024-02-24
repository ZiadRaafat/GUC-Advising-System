using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class makeup22 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void proceed(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            
            SqlConnection conn = new SqlConnection(connStr);


            try
            {
                int Sid = Int16.Parse(std.Text);
                int CourseID = Int16.Parse(cid.Text);
                String SemesterCode = semc.Text;

                SqlCommand loginproc = new SqlCommand("Procedures_StudentRegisterSecondMakeup", conn);
                loginproc.CommandType = CommandType.StoredProcedure;
                loginproc.Parameters.Add(new SqlParameter("@StudentID", Sid));
                loginproc.Parameters.Add(new SqlParameter("@courseID", CourseID));
                loginproc.Parameters.Add(new SqlParameter("@student_current_semester", SemesterCode));

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
