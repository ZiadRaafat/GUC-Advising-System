using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class Studentcredithoursrequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void chReq(object sender, EventArgs e)
        {
            try
            {
                string r = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection c = new SqlConnection(r);
                c.Open();
                String coursetype = type.Text;
                String cmt = comment.Text;
                HttpCookie userIdCookie = Request.Cookies["userID"];
                int studid = Convert.ToInt32(userIdCookie.Value);
                int credhrs;

                if (string.IsNullOrWhiteSpace(cmt) || string.IsNullOrWhiteSpace(coursetype) ||
                    string.IsNullOrWhiteSpace(ch.Text))
                {
                    Label2.Text = "Please fill in all the required fields.";
                    return; // Exit the method if any input is empty
                }


                if (int.TryParse(ch.Text, out credhrs) == false)
                {
                    Label2.Text = ("Please enter a valid credit hours number.");
                    return;

                }

                credhrs = Int16.Parse(ch.Text);



                SqlCommand AP = new SqlCommand("Procedures_StudentSendingCHRequest", c);
                AP.Parameters.Add(new SqlParameter("@StudentID", studid));
                AP.Parameters.Add(new SqlParameter("@credit_hours", credhrs));
                AP.Parameters.Add(new SqlParameter("@type", coursetype));
                AP.Parameters.Add(new SqlParameter("@comment", cmt));
                AP.CommandType = System.Data.CommandType.StoredProcedure;


                AP.ExecuteNonQuery();
                c.Close();
            }
            catch (Exception ex)
            {
                Label2.Text = ("Please enter the correct credentials.");
                return;

            }
            Label2.Text = ("You have sent a request successfully.");



        }

        protected void goBack(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}