using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class Studenthome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }



        private void Redirectid(string url)
        {
            // Retrieve user ID from the cookie
            HttpCookie userIdCookie = Request.Cookies["UserID"];
            if (userIdCookie != null)
            {
                int userId = Convert.ToInt32(userIdCookie.Value);
                Response.Redirect($"{url}?userID={userId}");
            }
        }


        

        protected void ReqCou(object sender, EventArgs e)
        {
            Response.Redirect("RequiredCourses.aspx");

        }

        protected void OptCou(object sender, EventArgs e)
        {
            Response.Redirect("OptionalCourses.aspx");

        }

        protected void AvaiCou(object sender, EventArgs e)
        {
            Response.Redirect("AvailableCourses.aspx");

        }

        protected void MissCou(object sender, EventArgs e)
        {
            Response.Redirect("MissingCourses.aspx");

        }

        protected void CredHrReq(object sender, EventArgs e)
        {
            Response.Redirect("CreditHourRequest.aspx");

        }

        protected void CouReq(object sender, EventArgs e)
        {
            Response.Redirect("CourseRequest.aspx");

        }

        protected void Mahmool(object sender, EventArgs e)
        {
            Response.Redirect("AddPhoneNumber.aspx");

        }

        protected void Bye(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");

        }
    }
}