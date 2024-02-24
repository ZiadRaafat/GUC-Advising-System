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
    public partial class Advisor_UpdatePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ReturnToHome(object sender, EventArgs e)
        {
            Response.Redirect("Advisor_Home.aspx");
        }
        protected void updateGradDate(object sender, EventArgs e)
        {
            string expec_date = gradDate.Text;
            if (string.IsNullOrEmpty(expec_date) || string.IsNullOrEmpty(stud_id.Text))
            {
                Response.Write("Please enter all required information.");
            }
            else if (!int.TryParse(stud_id.Text, out _))
            {
                Response.Write("Please enter a number for the ID field.");
            }
            else if (DateTime.Parse(expec_date) <= DateTime.Now)
            {
                Response.Write("Please choose a valid date.");
            }
            else
            {
                int id = Int16.Parse(stud_id.Text);
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand check = new SqlCommand("Check_Update_Plan", conn);
                check.CommandType = CommandType.StoredProcedure;
                check.Parameters.Add(new SqlParameter("@student_id", id));
                check.Parameters.Add(new SqlParameter("@advisor_id", Session["user"]));
                SqlParameter valid = new SqlParameter("@valid", SqlDbType.Bit);
                valid.Direction = ParameterDirection.Output;
                check.Parameters.Add(valid);
                conn.Open();
                check.ExecuteNonQuery();
                conn.Close();
                if (!(Convert.ToBoolean(valid.Value)))
                {
                    Response.Write("<div class='error'>The graduation plan and/or student don't exist.</div>");
                }
                else
                {
                    SqlCommand updateproc = new SqlCommand("Procedures_AdvisorUpdateGP", conn);
                    updateproc.CommandType = CommandType.StoredProcedure;
                    updateproc.Parameters.Add(new SqlParameter("@expected_grad_date", DateTime.Parse(expec_date)));
                    updateproc.Parameters.Add(new SqlParameter("@studentID", id));
                    conn.Open();
                    updateproc.ExecuteNonQuery();
                    conn.Close();
                    Response.Write("<div class='success'>Successful Update.</div>");
                }
            }
        }
        protected void gradDate_TextChanged(object sender, EventArgs e)
        {

        }
    }
}