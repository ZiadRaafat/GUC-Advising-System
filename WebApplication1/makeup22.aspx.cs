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
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                if (std.Text == "" || cid.Text == "" || semc.Text == "")
                {
                    Response.Write("Please fill all the boxes");
                }
                else
                {
                    int Sid = Int16.Parse(std.Text);
                    int CourseID = Int16.Parse(cid.Text);
                    String SemesterCode = semc.Text;

                    SqlCommand checkerproc = new SqlCommand("Procedures_StudentRegisterSecondMakeup", conn);
                    checkerproc.CommandType = CommandType.StoredProcedure;
                    checkerproc.Parameters.Add(new SqlParameter("@StudentID", Sid));
                    checkerproc.Parameters.Add(new SqlParameter("@courseID", CourseID));
                    checkerproc.Parameters.Add(new SqlParameter("@studentCurr_sem", SemesterCode));

                    SqlCommand elgibileproc = new SqlCommand("SELECT dbo.FN_StudentCheckSMEligibility(@StudentID, @courseID)", conn);
                    elgibileproc.Parameters.Add(new SqlParameter("@StudentID", Sid));
                    elgibileproc.Parameters.Add(new SqlParameter("@courseID", CourseID));

                    conn.Open();
                    bool rr = (bool)elgibileproc.ExecuteScalar();

                    if (!rr)
                    {
                        result.Text = "Your are not eligible to take 2nd makeup";
                    }
                    else
                    {
                        checkerproc.ExecuteNonQuery();
                        result.Text = "Procedure executed successfully!";
                    }


                    conn.Close();


                }
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
