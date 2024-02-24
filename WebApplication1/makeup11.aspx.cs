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
    public partial class makeup11 : System.Web.UI.Page
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



                    int StID = Int16.Parse(std.Text);
                    int courseID = Int16.Parse(cid.Text);
                    string studentCurrentSemester = semc.Text;


                    if (semc == null)
                    {
                        result.Text = "Please enter a proper Semester Code";
                    }
                    else
                    {



                        SqlCommand loginproc = new SqlCommand("Procedures_StudentRegisterFirstMakeup", conn);
                        loginproc.CommandType = CommandType.StoredProcedure;
                        loginproc.Parameters.Add(new SqlParameter("@StudentID", StID));
                        loginproc.Parameters.Add(new SqlParameter("@courseID", courseID));
                        loginproc.Parameters.Add(new SqlParameter("@studentCurr_sem", studentCurrentSemester));

                        conn.Open();
                        var result1 = loginproc.ExecuteScalar();
                        result.Text = "Procedure executed successfully!";
                        conn.Close();


                    }
                }
            }
            catch (Exception ex)
            {
                result.Text = "Error: " + ex.Message;
            }


        }

        protected void RETURN(object sender, EventArgs e)
        {
            Response.Redirect("General2.aspx");
        }
    }
}



