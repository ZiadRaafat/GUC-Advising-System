using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class Studentcourserequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void comment_TextChanged(object sender, EventArgs e)
        {

        }

        protected void courseReq(object sender, EventArgs e)
        {
            try
            {
                string r = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection c = new SqlConnection(r);
                c.Open();
                String coursetype = ctype.Text;
                String cmt = comment.Text;
                HttpCookie userIdCookie = Request.Cookies["userID"];
                int studid = Convert.ToInt32(userIdCookie.Value);
                int crsID;

                if (string.IsNullOrWhiteSpace(cmt) || string.IsNullOrWhiteSpace(coursetype) ||
                    string.IsNullOrWhiteSpace(cid.Text))
                {
                    Label2.Text = "Please fill in all the required fields.";
                    return; // Exit the method if any input is empty
                }


                if (int.TryParse(cid.Text, out crsID) == false)
                {
                    Label2.Text = ("Please enter a valid course ID.");
                    return;

                }

                crsID = Int16.Parse(cid.Text);

                SqlCommand AP = new SqlCommand("Procedures_StudentSendingCourseRequest", c);
                AP.Parameters.Add(new SqlParameter("@StudentID", studid));
                AP.Parameters.Add(new SqlParameter("@courseID", crsID));
                AP.Parameters.Add(new SqlParameter("@type", ctype));
                AP.Parameters.Add(new SqlParameter("@comment", cmt));
                AP.CommandType = System.Data.CommandType.StoredProcedure;


                AP.ExecuteNonQuery();
                c.Close();
            }

            catch(Exception ex)
            {
                Label2.Text = ("Error");

            }

            Label2.Text = ("You have sent a request successfully.");


        }

        protected void goBack(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}