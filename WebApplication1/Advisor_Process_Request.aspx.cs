using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Advisor_Process_Request : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ReturnHome(object sender, EventArgs e)
        {
            Response.Redirect("Advisor_Home.aspx");
        }
        protected void submitCreditHours(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string code = semesterCode1.Text;
            if (string.IsNullOrEmpty(request1.Text) || string.IsNullOrEmpty(code))
            {
                // At least one of the TextBox values is empty
                Response.Write("<div class='error'>Please enter all required information.</div>");
            }
            else if (!int.TryParse(request1.Text, out _))
            {
                Response.Write("<div class='error'>Please enter a number for the ID field.</div>");
            }
            else
            {
                int id = Int16.Parse(request1.Text);
                SqlCommand checkExists = new SqlCommand("Check_Request_Exists", conn);
                checkExists.CommandType = CommandType.StoredProcedure;
                checkExists.Parameters.Add(new SqlParameter("@requestID", id));
                checkExists.Parameters.Add(new SqlParameter("@advisorID", Session["user"]));
                SqlParameter exists = new SqlParameter("@exists", SqlDbType.Bit);
                exists.Direction = ParameterDirection.Output;
                checkExists.Parameters.Add(exists);
                conn.Open();
                checkExists.ExecuteNonQuery();
                conn.Close();
                if (!(Convert.ToBoolean(exists.Value)))
                {
                    Response.Write("<div class='error'>The request provided does not exist.</div>");
                }
                else
                {
                    SqlCommand checkPending = new SqlCommand("Check_Request_Pending", conn);
                    checkPending.CommandType = CommandType.StoredProcedure;
                    checkPending.Parameters.Add(new SqlParameter("@requestID", id));
                    SqlParameter pending = new SqlParameter("@pending", SqlDbType.Bit);
                    pending.Direction = ParameterDirection.Output; 
                    checkPending.Parameters.Add(pending);
                    conn.Open();
                    checkPending.ExecuteNonQuery();
                    conn.Close();
                    if (!(Convert.ToBoolean(pending.Value)))
                    {
                        Response.Write("<div class='error'>The request has already been processed.</div>");
                    }
                    else
                    {
                        SqlCommand requestproc = new SqlCommand("Procedures_AdvisorApproveRejectCHRequest", conn);
                        requestproc.CommandType = CommandType.StoredProcedure;
                        requestproc.Parameters.Add(new SqlParameter("@current_sem_code", code));
                        requestproc.Parameters.Add(new SqlParameter("@requestID", id));
                        SqlParameter status = new SqlParameter("@stat", SqlDbType.VarChar,40);
                        status.Direction = ParameterDirection.Output;
                        requestproc.Parameters.Add(status);
                        conn.Open();
                        requestproc.ExecuteNonQuery();
                        conn.Close();
                        String res = Convert.ToString(status.Value);
                        if(res =="Reject")
                        Response.Write( "<div class='error'>" +res + "</div>");
                        else
                        Response.Write("<div class='success'>" + res + "</div>");

                    }
                }
            }
        }
        protected void submitCourse(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string code = semesterCode2.Text;
            if (string.IsNullOrEmpty(request2.Text) || string.IsNullOrEmpty(code))
            {
                // At least one of the TextBox values is empty
                Response.Write("<div class='error'>Please enter all required information.</div>");
            }
            else if (!int.TryParse(request2.Text, out _))
            {
                Response.Write("<div class='error'>Please enter a number for the ID field.</div>");
            }
            else
            {
                int id = Int16.Parse(request2.Text);
                SqlCommand checkExists = new SqlCommand("Check_Request_Exists", conn);
                checkExists.CommandType = CommandType.StoredProcedure;
                checkExists.Parameters.Add(new SqlParameter("@requestID", id));
                checkExists.Parameters.Add(new SqlParameter("@advisorID", Session["user"]));
                SqlParameter exists = new SqlParameter("@exists", SqlDbType.Bit);
                exists.Direction = ParameterDirection.Output;
                checkExists.Parameters.Add(exists);
                conn.Open();
                checkExists.ExecuteNonQuery();
                conn.Close();
                if (!(Convert.ToBoolean(exists.Value)))
                {
                    Response.Write("<div class='error'>The request provided does not exist.</div>");
                }
                else
                {
                    SqlCommand checkPending = new SqlCommand("Check_Request_Pending", conn);
                    checkPending.CommandType = CommandType.StoredProcedure;
                    checkPending.Parameters.Add(new SqlParameter("@requestID", id));
                    SqlParameter pending = new SqlParameter("@pending", SqlDbType.Bit);
                    pending.Direction = ParameterDirection.Output;
                    checkPending.Parameters.Add(pending);
                    conn.Open();
                    checkPending.ExecuteNonQuery();
                    conn.Close();
                    if (!(Convert.ToBoolean(pending.Value)))
                    {
                        Response.Write("<div class='error'>The request has already been processed.</div>");
                    }
                    else
                    {
                        SqlCommand requestproc = new SqlCommand("Procedures_AdvisorApproveRejectCourseRequest", conn);
                        requestproc.CommandType = CommandType.StoredProcedure;
                        requestproc.Parameters.Add(new SqlParameter("@current_semester_code", code));
                        requestproc.Parameters.Add(new SqlParameter("@requestID", id));
                        SqlParameter status = new SqlParameter("@status", SqlDbType.VarChar, 40);
                        status.Direction = ParameterDirection.Output;
                        requestproc.Parameters.Add(status);
                        conn.Open();
                        requestproc.ExecuteNonQuery();
                        conn.Close();
                        String res = Convert.ToString(status.Value);
                        if (res == "Reject")
                            Response.Write("<div class='error'>" + res + "</div>");
                        else
                            Response.Write("<div class='success'>" + res + "</div>");

                    }
                }
            }
        }
    }
}